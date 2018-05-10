using ISSCommand;
using SSLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NodeBase
{
    public class CreateLineCommand : ISSCommand.ISSCommand
    {
        private ArrowLineWithText _arrowLineWithText = null;

        private InputComponent _input = null;

        private Canvas _canvas = null;
        private OutputComponent _out = null;
        public CreateLineCommand(ArrowLineWithText arrowLineWithText,Canvas canvas)
        {
            this._canvas = canvas;
            this._arrowLineWithText = arrowLineWithText;
            this._input = this._arrowLineWithText.EndComponent as InputComponent;
            this._out = this._arrowLineWithText.StartComponent as OutputComponent;
            
        }

        public void Execute()
        {
            // 只要把线添加到容器中就可以了

            //判断当前两个组件是否已经存在链接

            // 判断组件中是否已经存在该线实例，如果有，那么忽略
            bool haslineInInput = false;
            foreach (var item in this._input.GetLines())
            {
                if (this._arrowLineWithText==item)
                {
                    haslineInInput = true;
                }
            }

            bool haslineInOut = false;
            foreach (var item in this._out.GetLines())
            {
                if (this._arrowLineWithText==item)
                {
                    haslineInOut = true;
                }
            }

            if (haslineInInput==false)
            {
                this._input.AddNewLine(this._arrowLineWithText);
            }
            if (haslineInOut==false)
            {
                this._out.AddNewLine(this._arrowLineWithText);
            }

            //output组件要注册到input组件中，以获得通知
            //todo:注册之前是否要进行某些判断呢？

            this._out.RegiseterComponent(this._input);
            this._input.AddNotifier(this._out);

            //进行通知
            this._input.NotifyUpdate();
            this._out.NotifyUpdate();

            //判断是否在画布中已经存在
            bool hasInCanvas = false;
            foreach (var item in this._canvas.Children)
            {
                if (item is ArrowLineWithText)
                {
                   if ((ArrowLineWithText)item== this._arrowLineWithText )
                    {
                        hasInCanvas = true;
                    }
                }
            }

            if (hasInCanvas==false)
            {
                this._canvas.Children.Add(this._arrowLineWithText);
            }
        }

        public void Undo()
        {
            //组件取消通知
            this._out.LogoutComponent(this._input);
            this._input.RemoveNotifier(this._out);
            //更新
           
            this._input.MyShell.Process();

            this._input.DeleteLineByInstance(this._arrowLineWithText);
            this._out.DeleteLineByInstance(this._arrowLineWithText);
            this._canvas.Children.Remove(this._arrowLineWithText);
            //要从画布中也要删除
        }
    }
}
