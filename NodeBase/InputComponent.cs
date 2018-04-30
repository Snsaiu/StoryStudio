using SSLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace NodeBase
{
    public abstract class InputComponent:NodeComponentBase
    {
        private Canvas canvas = null;
        public InputComponent()
        {
            GlobalTracker.GlobalTracker globalTracker = GlobalTracker.GlobalTracker.GetInstance();
           this.canvas= globalTracker.GetNodeCanvas();
        }
        public override void NotifyMove()
        {
            foreach (var item in this.GetLines())
            {
                item.StartPoint = this.TranslatePoint(new Point(), this.canvas);
            }
        }

        protected override void ClickEvent(object sender, RoutedEventArgs e)
        {
            // todo:完成输入节点点击事件
            // 根据条件创建线的起点

            //创建线工厂
            SSLineFactoryAbs sSLineFactory = new DefaultLineFactory();
            ArrowLineWithText arrowLineWithText = null;


            if (this.IOType==BaseTypeEnum.IOTypeEnum.input)
            {
                // 角色
                if (this.Type == BaseTypeEnum.NodeType.characterType)
                {
                 arrowLineWithText =  sSLineFactory.CreateCharacterLine();

                }
                //事件
                else if (this.Type==BaseTypeEnum.NodeType.eventType)
                {
                    arrowLineWithText = sSLineFactory.CreateEventLine();
                }
                // note
                else if(this.Type==BaseTypeEnum.NodeType.noteType)
                {

                }
         
                 Point p = Mouse.GetPosition(this.canvas);

                arrowLineWithText.StartPoint = p;
                arrowLineWithText.EndPoint = new Point(90, 0);
                arrowLineWithText.StrokeThickness = 1;
                arrowLineWithText.Stroke = Brushes.Red;
                canvas.Children.Add(arrowLineWithText);
                //  arrowLineWithText.SetValue(Canvas.LeftProperty, p.X);
                //   arrowLineWithText.SetValue(Canvas.TopProperty, p.Y);


              //  canvas.MouseMove += (s, m) => { arrowLineWithText.EndPoint = m.GetPosition(canvas); };

                this.AddNewLine(arrowLineWithText);
                //ArrowLineWithText a = new ArrowLineWithText();
                //a.Text = "hello";
                //a.StartPoint = new Point(50, 60);
                //a.EndPoint = new Point(100, 400);
                //a.Stroke = Brushes.Red;
                //a.StrokeThickness = 1;
                //this.GetCanvas.Children.Add(a);
                //a.SetValue(Canvas.LeftProperty, (double)50);
                //a.SetValue(Canvas.TopProperty, (double)60);


            }


            





        }
    }
}
