using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CameraTake.View
{
    /// <summary>
    /// Interaction logic for CameraTakeView.xaml
    /// </summary>
    public partial class CameraTakeView : Window
    {

        #region Fields
        ///鼠标原始位置
        private Point _oriMousePosition;

        /// <summary>
        /// 画布
        /// </summary>
        private InkCanvas _inkcanvas;

        /// <summary>
        /// 鼠标和画布的插值
        /// </summary>
        private Point _distance;
        /// <summary>
        /// 判断鼠标中键当前状态
        /// </summary>
        private bool _middleMouseDown = false;
        #endregion

        public CameraTakeView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 缩放比例
        /// </summary>
        private double rate = 1;

        private void ink_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Point center = e.GetPosition(this.canvascontainer);
            if (e.Delta>0)
            {
                this.rate *=1.08;
               
                ScaleTransform st = new ScaleTransform(this.rate, this.rate, center.X,center.Y);
                this._inkcanvas.RenderTransform = st;

            }
            else
            {
                if (this.rate<=1)
                {
                    return;
                }
                this.rate /= 1.08;
                ScaleTransform st = new ScaleTransform(this.rate, this.rate, center.X, center.Y);
                this._inkcanvas.RenderTransform = st;
            }
        }

        /// <summary>
        /// 窗口尺寸改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inkwindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            RectangleGeometry _rg = new RectangleGeometry(new Rect( 0, 0, this.inkwindow.ActualWidth - 20, this.inkwindow.ActualHeight - 20));
            this.canvascontainer.Clip = _rg;
        }

        /// <summary>
        /// 鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ink_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

            ///计算鼠标和画布的距离插值
           this. _distance = new Point();

            ///鼠标中键按下
            ///当鼠标中键被按下的时候，要记录当前鼠标的位置
            if (e.MiddleButton== MouseButtonState.Pressed)
            {
                _oriMousePosition = e.GetPosition(this.canvascontainer);
                this._middleMouseDown = true;

                double _ink_x = Canvas.GetLeft(this._inkcanvas);
                double _ink_y = Canvas.GetTop(this._inkcanvas);
                //因为画布的中心点在左上角，和鼠标有插值，所以要计算插值
                this._distance.X = this._oriMousePosition.X - _ink_x;
                this._distance.Y = this._oriMousePosition.Y - _ink_y;
            }
          
        }

        /// <summary>
        /// 鼠标移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ink_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
          

            //判断鼠标中键标记是否为true
            if (this._middleMouseDown==true)
            {
                Point _mousepoint = e.GetPosition(this.canvascontainer);
                double _x = Canvas.GetLeft(this._inkcanvas);
                double _y = Canvas.GetTop(this._inkcanvas);
                Point p = new Point(_mousepoint.X - this._distance.X, _mousepoint.Y - this._distance.Y);
                Canvas.SetLeft(this._inkcanvas, p.X);
                Canvas.SetTop(this._inkcanvas, p.Y);
                return;
            
            }

        }

        /// <summary>
        /// 新建图层命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewCanvasEvent(object sender, RoutedEventArgs e)
        {
            this._inkcanvas = new InkCanvas();
            Canvas.SetLeft(this._inkcanvas, 0);
            Canvas.SetTop(this._inkcanvas, 0);
            
            //todo:这里可以设置宽和高

            this._inkcanvas.Height = 350;
            this._inkcanvas.Width = 600;

            this._inkcanvas.MouseWheel += ink_MouseWheel;
            this._inkcanvas.MouseMove += ink_MouseMove;
            this._inkcanvas.PreviewMouseUp += ink_PreviewMouseUp; ;

            this._inkcanvas.PreviewMouseDown += ink_PreviewMouseDown;

            this.canvascontainer.Children.Add(this._inkcanvas);
        }

        /// <summary>
        /// 鼠标抬起事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ink_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            ///鼠标中键抬起
            if (e.MiddleButton==MouseButtonState.Released)
            {
                this._middleMouseDown = false;
            }
        }

        /// <summary>
        /// 橡皮擦功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EraseByPointEvent(object sender, RoutedEventArgs e)
        {
            this._inkcanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }

        /// <summary>
        /// 画笔事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PenEvent(object sender, RoutedEventArgs e)
        {
            this._inkcanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        /// <summary>
        /// 画笔颜色事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PenColorEvent(object sender, RoutedEventArgs e)
        {
            ColorDialog _c = new ColorDialog();
            if (_c.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                this._inkcanvas.DefaultDrawingAttributes.Color = System.Windows.Media.Color.FromArgb(_c.Color.A, _c.Color.R, _c.Color.G, _c.Color.B);

            }
        }
    }
}
