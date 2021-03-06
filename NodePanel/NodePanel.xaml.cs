﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace NodePanel
{
    /// <summary>
    /// Interaction logic for NodePanel.xaml
    /// </summary>
    public partial class NodePanel : UserControl,IPanelBase.IPanelBase, IJoinGlobalTracker.IJoinGlobalTracker
    {
        
        /// <summary>
        /// determain current canvas can mose position
        /// </summary>
        private bool _canMove = false;

        /// <summary>
        /// 捕获的节点保存在该字段中
        /// </summary>
        private NodeBase.NodeBase targetElement = null;

      
        /// <summary>
        /// 鼠标点击到Node后，鼠标位置与Node左上角的差值
        /// </summary>
        private Point _nodeMouseDistance;

        TranslateTransform totalTranslate = new TranslateTransform();
        TranslateTransform tempTranslate = new TranslateTransform();
        ScaleTransform totalScale = new ScaleTransform();

        private double _scaleLevel = 1;

        /// <summary>
        /// when mouse left down ,record current mouse position
        /// </summary>
        private Point _moveStartPoint;

        /// <summary>
        /// 获得节点编辑器的画布
        /// </summary>
        public Canvas GetCanvas { get { return this.NodeCanvas; } }

        public NodePanel()
        {
            InitializeComponent();

            GlobalTracker.GlobalTracker g = GlobalTracker.GlobalTracker.GetInstance();
            g.SetNodeCanvas(this.GetCanvas);


            // todo 
            //ArrowLineWithText a = new ArrowLineWithText();
            //a.Text = "hello";
            //a.StartPoint = new Point(50, 60);
            //a.EndPoint = new Point(100, 400);
            //a.Stroke = Brushes.Red;
            //a.StrokeThickness = 1;
            //this.GetCanvas.Children.Add(a);
            //a.SetValue(Canvas.LeftProperty, (double)50);
            //a.SetValue(Canvas.TopProperty, (double)60);




            // node panel mousewheel event ,it can scale node panel size 
            this.NodeCanvas.MouseWheel += (s, e) =>
            {

                Point scaleCenter = e.GetPosition(this.NodeCanvas);

                if (e.Delta > 0)
                {
                    this._scaleLevel *= 1.08;
                    ScaleTransform st = new ScaleTransform(this._scaleLevel, this._scaleLevel, this.ActualWidth / 2, this.ActualHeight / 2);
                    this.NodeCanvas.RenderTransform = st;
                }
                else
                {
                    if (this._scaleLevel <= 1.08)
                    {
                        return;
                    }
                    this._scaleLevel /= 1.08;
                    ScaleTransform st = new ScaleTransform(this._scaleLevel, this._scaleLevel, this.ActualWidth / 2, this.ActualHeight / 2);
                    this.NodeCanvas.RenderTransform = st;

                }

                totalScale.ScaleX = this._scaleLevel;
                totalScale.ScaleY = this._scaleLevel;

            };




            // when mouse left buttom down will call this method
            // it will set _canMove value change to true
            this.NodeCanvas.MouseLeftButtonDown += (s, e) =>
            {
                //  if double click send node data to detail panel
                if (e.Source is NodeBase.NodeBase)
                {
                    targetElement = e.Source as NodeBase.NodeBase;
                    targetElement.CaptureMe();
                    // 计算鼠标与节点右上角距离差值
                    var pCanvas = e.GetPosition(this.NodeCanvas);
                    //   this._nodeMouseDistance.X = pCanvas.X - targetElement.Position.X;
                    //  this._nodeMouseDistance.Y = pCanvas.Y - targetElement.Position.Y;
                    this._nodeMouseDistance.X = pCanvas.X - Canvas.GetLeft(targetElement);
                    this._nodeMouseDistance.Y = pCanvas.Y - Canvas.GetTop(targetElement);
                }
                else
                {
                    targetElement = null;
                }
                //if (e.ClickCount == 2 && targetElement is NodeBase)
                //{

                //    this.eventAggregator.GetEvent<SendNodeObjectEvent>().Publish(((NodeBase)targetElement));
                //}
                //if (targetElement is NodeBase)
                //{
                //    captureElementPoint = e.GetPosition(targetElement);
                //    this._captureNode = targetElement as NodeBase;
                //    this._captureNode.CaptureMouse();
                //}
                this._canMove = true;
                this.NodeCanvas.Cursor = Cursors.Hand;
                this._moveStartPoint = e.GetPosition(null);

            };

            // when mouse move and the _canMove is true ,it will move node panel
            this.NodeCanvas.MouseMove += (s, e) =>
            {

                if (e.LeftButton == MouseButtonState.Pressed && targetElement != null && this._canMove)
                {
                    var pCanvas = e.GetPosition(this.NodeCanvas);
                    // set finall position
                   targetElement.Position = new Point(pCanvas.X-this._nodeMouseDistance.X, pCanvas.Y-this._nodeMouseDistance.Y);
                    Canvas.SetLeft(targetElement, targetElement.Position.X);
                    Canvas.SetTop(targetElement, targetElement.Position.Y);
                   //Canvas.SetLeft(targetElement as StoryStartNode.StoryStartNode, (pCanvas.X - captureElementPoint.X));
                   // Canvas.SetTop(targetElement as StoryStartNode.StoryStartNode, (pCanvas.Y - captureElementPoint.Y));
                  //  Console.WriteLine("level  " + this._scaleLevel);
                    return;
                }

                // publish event 
                string[] p = new string[2];
                p[0] = e.GetPosition(this.NodeCanvas).X.ToString("0.");
                p[1] = e.GetPosition(this.NodeCanvas).Y.ToString("0.");

              

                if (e.LeftButton == MouseButtonState.Pressed && this._canMove)
                {
                    double deltaV = e.GetPosition(null).Y - this._moveStartPoint.Y;

                    double deltaH = e.GetPosition(null).X - this._moveStartPoint.X;

                    foreach (UIElement item in this.NodeCanvas.Children)
                    {
                        double newTop = deltaV + (double)item.GetValue(Canvas.TopProperty);
                        double newLeft = deltaH + (double)item.GetValue(Canvas.LeftProperty);
                  
                      

                        item.SetValue(Canvas.LeftProperty, newLeft);
                        item.SetValue(Canvas.TopProperty, newTop);

                        if (item is NodeBase.NodeBase)
                        {
                            (item as NodeBase.NodeBase).NodeBase_MouseMove(s, e);
                        }
                       
                        //if (item is INodeBase)
                        //{
                        //    INodeBase nodeTemp = item as INodeBase;
                        //    nodeTemp.Position = new Point(newLeft,newTop);                        
                        //}

                        //this.HorScrollbarValue = newLeft;
                        //this.VerScrollbarValue = newTop;

                        this._moveStartPoint = e.GetPosition(null);
                        e.Handled = true;
                    }
                }

            };
            // when mouse left buttom up ,_canMove if false ,so user can node move node panel
            this.NodeCanvas.MouseLeftButtonUp += (s, e) =>
            {
               
                // 判断当前是否已经捕获到节点，如果捕获到节点，要释放
                if(this.targetElement!=null)
                {
                    targetElement.ReleaseMe();
                }

                this.NodeCanvas.Cursor = null;
                this._canMove = false;
                //Point endMovePosition = e.GetPosition(this.NodeCanvas);
                //totalTranslate.X += (endMovePosition.X - this._moveStartPoint.X) / this._scaleLevel;
                //totalTranslate.Y += (endMovePosition.Y - this._moveStartPoint.Y) / this._scaleLevel;
            };

        }


        public string PanelLabel => "节点编辑器";
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public BaseTypeEnum.BaseTypeEnum BaseType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string ShortName => "NEP";

        public string LongName => "NodeEditPanel";

        private bool _isactivity = false;

        public bool IsActivity { get => _isactivity; set => this._isactivity = value; }

        public bool FindDataByTag(string tag, out object resource)
        {
            throw new NotImplementedException();
        }

        public void SetPanelFloat(UIElement parent)
        {
            throw new NotImplementedException();
        }

        public void SetPanelNoFloat(UIElement parent)
        {
            throw new NotImplementedException();
        }

        public void Join()
        {
            GlobalTracker.GlobalTracker gt = GlobalTracker.GlobalTracker.GetInstance();
            gt.AddPanelInstance(this);
        }

        public bool Quit()
        {
            GlobalTracker.GlobalTracker gt = GlobalTracker.GlobalTracker.GetInstance();
            return gt.RemovePanelByShortName("CP");
        }
    }
    

  

}
