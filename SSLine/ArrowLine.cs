namespace SSLine
{
    using DisplayLabelEnum;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;

    /// <summary>
    /// 两点之间带箭头的直线
    /// </summary>
    public class ArrowLine : ArrowBase
    {
        #region Fields

        /// <summary>
        /// 结束点
        /// </summary>
        public static readonly DependencyProperty EndPointProperty = DependencyProperty.Register(
            "EndPoint",
            typeof(Point),
            typeof(ArrowLine),
            new FrameworkPropertyMetadata(default(Point), FrameworkPropertyMetadataOptions.AffectsMeasure));

        /// <summary>
        /// 线段
        /// </summary>
        private readonly LineSegment lineSegment = new LineSegment();

        #endregion Fields

        #region Properties

        /// <summary>
        /// 结束点
        /// </summary>
        public Point EndPoint
        {
            get { return (Point)this.GetValue(EndPointProperty); }
            set { this.SetValue(EndPointProperty, value); }
        }

        private object _startComponent;

        /// <summary>
        /// 线连接的起始对象
        /// </summary>
        public object StartComponent
        {
            get { return _startComponent; }
            set { _startComponent = value; }
        }

        private object _endComponent;

        /// <summary>
        /// 线连接的终点对象
        /// </summary>
        public object EndComponent
        {
            get { return _endComponent; }
            set { _endComponent = value; }
        }





        #endregion Properties

        #region Protected Methods

        /// <summary>
        /// 填充Figure
        /// </summary>
        /// <returns>PathSegment集合</returns>
        protected override PathSegmentCollection FillFigure()
        {
            this.lineSegment.Point = this.EndPoint;
            return new PathSegmentCollection
            {
                this.lineSegment
            };
        }

        /// <summary>
        /// 获取开始箭头处的结束点
        /// </summary>
        /// <returns>开始箭头处的结束点</returns>
        protected override Point GetStartArrowEndPoint()
        {
            return this.EndPoint;
        }

        /// <summary>
        /// 获取结束箭头处的开始点
        /// </summary>
        /// <returns>结束箭头处的开始点</returns>
        protected override Point GetEndArrowStartPoint()
        {
            return this.StartPoint;
        }

        /// <summary>
        /// 获取结束箭头处的结束点
        /// </summary>
        /// <returns>结束箭头处的结束点</returns>
        protected override Point GetEndArrowEndPoint()
        {
            return this.EndPoint;
        }

        public override void MoveStartWithMouse(object sender, MouseEventArgs e)
        {
            if (this.StartPointConnected==false)
            {
                this.StartPoint = e.GetPosition(sender as Canvas);
            }
        }

        public override void MoveEndWithMouse(object sender, MouseEventArgs e)
        {
            if (this.EndPointConnected==false)
            {
                this.EndPoint=e.GetPosition(sender as Canvas);
            }
        }

        #endregion  Protected Methods


        #region Public Method
        public ArrowLine()
        {
            //右键菜单

            ContextMenu contextMenu = new ContextMenu();
            MenuItem changelinecolor = new MenuItem();
            changelinecolor.Header = ContextMenuLabelEnum.改变颜色;
            MenuItem changelinestroke = new MenuItem();
            changelinestroke.Header = ContextMenuLabelEnum.改变线宽;
            MenuItem deleteline = new MenuItem(); 
             deleteline.Header = ContextMenuLabelEnum.删除;

            contextMenu.Items.Add(changelinecolor);
            contextMenu.Items.Add(changelinestroke);
            contextMenu.Items.Add(deleteline);

            this.ContextMenu = contextMenu;
        }

        #endregion

    }
}
