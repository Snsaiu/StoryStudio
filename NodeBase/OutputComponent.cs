using GlobalTracker;
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
    public abstract class OutputComponent : NodeComponentBase
    {

        private Canvas canvas = null;
        public OutputComponent()
        {
            GlobalTracker.GlobalTracker globalTracker = GlobalTracker.GlobalTracker.GetInstance();
            this.canvas = globalTracker.GetNodeCanvas();
        }

        public override void NotifyMove()
        {
            foreach (var item in this.GetLines())
            {
                item.StartPoint = this.TranslatePoint(new Point(10,15), this.canvas);
            }
        }
        protected override void ClickEvent(object sender, RoutedEventArgs e)
        {

            // todo:完成输入节点点击事件
            // 根据条件创建线的起点

            if (LineTracker.CanCreateLine==false)
            {
                //判断是否可以进行连接
                if (LineTracker.StoreLineObj.EndComponent is NodeComponentBase)
                {
                    NodeComponentBase temp = LineTracker.StoreLineObj.EndComponent as NodeComponentBase;
                    // 判断组件类型是否能够连接

                    if (temp.Type==this.Type)
                    {
                        if (temp.IOType==BaseTypeEnum.IOTypeEnum.input)
                        {
                            this.canvas.MouseMove -= LineTracker.StoreLineObj.MoveStartWithMouse;

                            this.AddNewLine(LineTracker.StoreLineObj);

                            LineTracker.StoreLineObj.IsHitTestVisible = true;

                            LineTracker.CanCreateLine = true;
                            LineTracker.StoreLineObj = null;
                        }
                    }

                }
                return;
            }



            //创建线工厂
            SSLineFactoryAbs sSLineFactory = new DefaultLineFactory();
            ArrowLineWithText arrowLineWithText = null;


            if (this.IOType == BaseTypeEnum.IOTypeEnum.output)
            {
                // 角色
                if (this.Type == BaseTypeEnum.NodeType.characterType)
                {
                    arrowLineWithText = sSLineFactory.CreateCharacterLine();
                    LineTracker.CanCreateLine = false;
                    LineTracker.StoreLineObj = arrowLineWithText;
                    arrowLineWithText.StartComponent = this;
                }
                //事件
                else if (this.Type == BaseTypeEnum.NodeType.eventType)
                {
                    arrowLineWithText = sSLineFactory.CreateEventLine();
                    LineTracker.CanCreateLine = false;
                    LineTracker.StoreLineObj = arrowLineWithText;
                    arrowLineWithText.StartComponent = this;
                }
                // note
                else if (this.Type == BaseTypeEnum.NodeType.noteType)
                {
                    // todo
                    LineTracker.CanCreateLine = false;
                    LineTracker.StoreLineObj = arrowLineWithText;
                    arrowLineWithText.StartComponent = this;
                }

                Point p = Mouse.GetPosition(this.canvas);
                arrowLineWithText.StartPoint = p;
                //线的起始已经链接到组件，进行赋值
                arrowLineWithText.StartPointConnected = true;      
                // 忽略线事件
                arrowLineWithText.IsHitTestVisible = false;
                canvas.Children.Add(arrowLineWithText);
                //  arrowLineWithText.SetValue(Canvas.LeftProperty, p.X);
                //   arrowLineWithText.SetValue(Canvas.TopProperty, p.Y);


                canvas.MouseMove += arrowLineWithText.MoveEndWithMouse;
               
      

                canvas.MouseRightButtonDown += (s, m) =>
                {

                    //删除线
                    this.canvas.Children.Remove(LineTracker.StoreLineObj);
                    //可以重新创建线
                    LineTracker.CanCreateLine = true;
                };

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
