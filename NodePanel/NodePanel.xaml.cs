using BaseTypeEnum;
using IPanelBase;
using SSBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NodePanel
{
    /// <summary>
    /// Interaction logic for NodePanel.xaml
    /// </summary>
    public partial class NodePanel : UserControl,IPanelBase.IPanelBase
    {

        /// <summary>
        /// determain current canvas can mose position
        /// </summary>
        private bool _canMove = false;

        private Point captureElementPoint;

        TranslateTransform totalTranslate = new TranslateTransform();
        TranslateTransform tempTranslate = new TranslateTransform();
        ScaleTransform totalScale = new ScaleTransform();

        private double _scaleLevel = 1;

        /// <summary>
        /// when mouse left down ,record current mouse position
        /// </summary>
        private Point _moveStartPoint;

        public NodePanel()
        {
            InitializeComponent();


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
               var targetElement = e.Source as IInputElement;
                //if (e.ClickCount == 2 && targetElement is NodeBase)
                //{

                //    this.eventAggregator.GetEvent<SendNodeObjectEvent>().Publish(((NodeBase)targetElement));
                //}

                targetElement = e.Source as IInputElement;
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

                var targetElement = Mouse.Captured as UIElement;
                if (e.LeftButton == MouseButtonState.Pressed && targetElement != null && this._canMove)
                {
                    var pCanvas = e.GetPosition(this.NodeCanvas);
                    // set finall position
                    Canvas.SetLeft(targetElement, (pCanvas.X - captureElementPoint.X));
                    Canvas.SetTop(targetElement, (pCanvas.Y - captureElementPoint.Y));
                    Console.WriteLine("level  " + this._scaleLevel);
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
                        Console.WriteLine(newTop.ToString());
                        Console.WriteLine(newLeft.ToString());

                        item.SetValue(Canvas.LeftProperty, newLeft);
                        item.SetValue(Canvas.TopProperty, newTop);
                        //if (item is NodeBase)
                        //{
                        //    NodeBase nodeTemp = item as NodeBase;
                        //    nodeTemp.SetPosition(newLeft, newTop);
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
                Mouse.Capture(null);
                this.NodeCanvas.Cursor = null;
                this._canMove = false;
                Point endMovePosition = e.GetPosition(this.NodeCanvas);
                totalTranslate.X += (endMovePosition.X - this._moveStartPoint.X) / this._scaleLevel;
                totalTranslate.Y += (endMovePosition.Y - this._moveStartPoint.Y) / this._scaleLevel;
            };

        }

        public string PanelLabel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public BaseTypeEnum.BaseTypeEnum BaseType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
    }
    
}
