namespace SSLine
{
    using DisplayLabelEnum;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
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

        private object _startComponent;

        /// <summary>
        /// �����ӵ���ʼ����
        /// </summary>
        public object StartComponent
        {
            get { return _startComponent; }
            set { _startComponent = value; }
        }

        private object _endComponent;

        /// <summary>
        /// �����ӵ��յ����
        /// </summary>
        public object EndComponent
        {
            get { return _endComponent; }
            set { _endComponent = value; }
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
            //�Ҽ��˵�

            ContextMenu contextMenu = new ContextMenu();
            MenuItem changelinecolor = new MenuItem();
            changelinecolor.Header = ContextMenuLabelEnum.�ı���ɫ;
            MenuItem changelinestroke = new MenuItem();
            changelinestroke.Header = ContextMenuLabelEnum.�ı��߿�;
            MenuItem deleteline = new MenuItem(); 
             deleteline.Header = ContextMenuLabelEnum.ɾ��;

            contextMenu.Items.Add(changelinecolor);
            contextMenu.Items.Add(changelinestroke);
            contextMenu.Items.Add(deleteline);

            this.ContextMenu = contextMenu;
        }

        #endregion

    }
}
