using GlobalTracker;
using ISSCommand;
using NodeBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SSNodeButton
{
    public class AddNodeCommand : ISSCommand.ISSCommand
    {
        /// <summary>
        /// 节点实例
        /// </summary>
        private NodeBase.NodeBase _lastNode = null;

        /// <summary>
        /// 节点存放的面板实例
        /// </summary>
        private Canvas _canvas = null;

        /// <summary>
        /// 存储已经删除的node
        /// </summary>

        public AddNodeCommand(NodeBase.NodeBase node,Canvas canvas)
        {
   
            this._lastNode = node;
            this._canvas = canvas;
        }



        public void Execute()
        {
            //在执行之前，应该已经创建好node，Execture做的只是把node显示到画布上    

             this._canvas.Children.Add(this._lastNode);
            Canvas.SetLeft(this._lastNode, this._lastNode.Position.X);
            Canvas.SetTop(this._lastNode, this._lastNode.Position.Y);
          
        }

        public void Undo()
        {
            this._canvas.Children.RemoveAt(this._canvas.Children.Count - 1);

            //this._canvas.Children.Clear();
        }
    }
}
