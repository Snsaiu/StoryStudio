namespace SSLine
{
    using System.Windows;
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

        /// <summary>
        /// 保存线的起始是否已经链接到组件上
        /// </summary>
        private bool _startPointConnected=false;

        /// <summary>
        /// 设置或者获得线的起始是否已经链接到组件上
        /// </summary>
        public bool StartPointConnected
        {
            get { return _startPointConnected; }
            set { _startPointConnected = value; }
        }

        /// <summary>
        /// 保存线的终点是否已经链接到组件上
        /// </summary>
        private bool _endPointConnected=false;

        /// <summary>
        /// 设置或者获得线的终点是否已经链接到组件上
        /// </summary>
        public bool EndPointConnected
        {
            get { return _endPointConnected; }
            set { _endPointConnected = value; }
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

        #endregion  Protected Methods

    }
}
