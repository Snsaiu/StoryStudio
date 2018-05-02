namespace SSLine
{
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    /// ����֮�����ͷ��ֱ��
    /// </summary>
    public class ArrowLine : ArrowBase
    {
        #region Fields

        /// <summary>
        /// ������
        /// </summary>
        public static readonly DependencyProperty EndPointProperty = DependencyProperty.Register(
            "EndPoint",
            typeof(Point),
            typeof(ArrowLine),
            new FrameworkPropertyMetadata(default(Point), FrameworkPropertyMetadataOptions.AffectsMeasure));

        /// <summary>
        /// �߶�
        /// </summary>
        private readonly LineSegment lineSegment = new LineSegment();

        #endregion Fields

        #region Properties

        /// <summary>
        /// ������
        /// </summary>
        public Point EndPoint
        {
            get { return (Point)this.GetValue(EndPointProperty); }
            set { this.SetValue(EndPointProperty, value); }
        }

        /// <summary>
        /// �����ߵ���ʼ�Ƿ��Ѿ����ӵ������
        /// </summary>
        private bool _startPointConnected=false;

        /// <summary>
        /// ���û��߻���ߵ���ʼ�Ƿ��Ѿ����ӵ������
        /// </summary>
        public bool StartPointConnected
        {
            get { return _startPointConnected; }
            set { _startPointConnected = value; }
        }

        /// <summary>
        /// �����ߵ��յ��Ƿ��Ѿ����ӵ������
        /// </summary>
        private bool _endPointConnected=false;

        /// <summary>
        /// ���û��߻���ߵ��յ��Ƿ��Ѿ����ӵ������
        /// </summary>
        public bool EndPointConnected
        {
            get { return _endPointConnected; }
            set { _endPointConnected = value; }
        }




        #endregion Properties

        #region Protected Methods

        /// <summary>
        /// ���Figure
        /// </summary>
        /// <returns>PathSegment����</returns>
        protected override PathSegmentCollection FillFigure()
        {
            this.lineSegment.Point = this.EndPoint;
            return new PathSegmentCollection
            {
                this.lineSegment
            };
        }

        /// <summary>
        /// ��ȡ��ʼ��ͷ���Ľ�����
        /// </summary>
        /// <returns>��ʼ��ͷ���Ľ�����</returns>
        protected override Point GetStartArrowEndPoint()
        {
            return this.EndPoint;
        }

        /// <summary>
        /// ��ȡ������ͷ���Ŀ�ʼ��
        /// </summary>
        /// <returns>������ͷ���Ŀ�ʼ��</returns>
        protected override Point GetEndArrowStartPoint()
        {
            return this.StartPoint;
        }

        /// <summary>
        /// ��ȡ������ͷ���Ľ�����
        /// </summary>
        /// <returns>������ͷ���Ľ�����</returns>
        protected override Point GetEndArrowEndPoint()
        {
            return this.EndPoint;
        }

        #endregion  Protected Methods

    }
}
