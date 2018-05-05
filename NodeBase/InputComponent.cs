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
                item.EndPoint = this.TranslatePoint(new Point(10,0), this.canvas);
            }
        }

        protected override void ClickEvent(object sender, RoutedEventArgs e)
        {
            // todo:完成输入节点点击事件
 
            // 根据条件创建线的起点

            //创建线工厂
            SSLineFactoryAbs sSLineFactory = new DefaultLineFactory();
            ArrowLineWithText arrowLineWithText = null;

            //判断当前是否有线需要被连接，如果已经有线正在被连接，那么不创建线
            if (LineTracker.CanCreateLine==false)
            {

                // todo:应该要加个判断，判断当前node的类型，

                //判断 是能否进行连接
                if (LineTracker.StoreLineObj!=null)
                {
                    if (LineTracker.StoreLineObj.StartComponent is NodeComponentBase)
                    {
                        NodeComponentBase temp = LineTracker.StoreLineObj.StartComponent as NodeComponentBase;
                        //todo判断节点类型以确定是否能够连接
                        //判断节点类型,只有相同类型的才能 连接
                        if (temp.Type==this.Type)
                        {
                            //输出段的线才能连接到输入端
                            if (temp.IOType==BaseTypeEnum.IOTypeEnum.output)
                            {
                                //取消事件关注
                                this.canvas.MouseMove -= LineTracker.StoreLineObj.MoveEndWithMouse;

                                //加入容器中
                                this.AddNewLine(LineTracker.StoreLineObj);

                                // 恢复线的事件
                                LineTracker.StoreLineObj.IsHitTestVisible = true;

                                //初始化线追踪器
                                LineTracker.CanCreateLine = true;
                                LineTracker.StoreLineObj = null;
                            }

                        }

                    } 
                }

                return;
            }

            if (this.IOType==BaseTypeEnum.IOTypeEnum.input)
            {
                // 角色
                if (this.Type == BaseTypeEnum.NodeType.characterType)
                {
                 arrowLineWithText =  sSLineFactory.CreateCharacterLine();
                    LineTracker.CanCreateLine = false;
                    LineTracker.StoreLineObj = arrowLineWithText;
                    arrowLineWithText.EndComponent = this;
                }
                //事件
                else if (this.Type==BaseTypeEnum.NodeType.eventType)
                {
                    arrowLineWithText = sSLineFactory.CreateEventLine();
                    LineTracker.CanCreateLine = false;
                    LineTracker.StoreLineObj = arrowLineWithText;
                    arrowLineWithText.EndComponent = this;
                }
                // note
                else if(this.Type==BaseTypeEnum.NodeType.noteType)
                {
                    // todo
                    LineTracker.CanCreateLine = false;
                    LineTracker.StoreLineObj = arrowLineWithText;
                    arrowLineWithText.EndComponent = this;
                }
         
                 Point p = Mouse.GetPosition(this.canvas);
                arrowLineWithText.StartPoint = p;
                //线的末端已经链接到组件，进行赋值
                arrowLineWithText.EndPointConnected = true;
                // 忽略线事件
                arrowLineWithText.IsHitTestVisible = false;
                canvas.Children.Add(arrowLineWithText);
                //  arrowLineWithText.SetValue(Canvas.LeftProperty, p.X);
                //   arrowLineWithText.SetValue(Canvas.TopProperty, p.Y);


                canvas.MouseMove += arrowLineWithText.MoveStartWithMouse;

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
