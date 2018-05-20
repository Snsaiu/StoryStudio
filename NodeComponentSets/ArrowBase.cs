using DisplayLabelEnum;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
namespace NodeBase
{


    /// <summary>
    /// ��ͷ����
    /// </summary>
    public abstract class ArrowBase : Shape
    {
        #region Fields

        #region DependencyProperty

        /// <summary>
        /// ��ͷ���߼нǵ���������
        /// </summary>
        public static readonly DependencyProperty ArrowAngleProperty = DependencyProperty.Register(
            "ArrowAngle",
            typeof(double),
            typeof(ArrowBase),
            new FrameworkPropertyMetadata(45.0, FrameworkPropertyMetadataOptions.AffectsMeasure));

        /// <summary>
        /// ��ͷ���ȵ���������
        /// </summary>
        public static readonly DependencyProperty ArrowLengthProperty = DependencyProperty.Register(
            "ArrowLength",
            typeof(double),
            typeof(ArrowBase),
            new FrameworkPropertyMetadata(12.0, FrameworkPropertyMetadataOptions.AffectsMeasure));

        /// <summary>
        /// ��ͷ���ڶ˵���������
        /// </summary>
        public static readonly DependencyProperty ArrowEndsProperty = DependencyProperty.Register(
            "ArrowEnds",
            typeof(ArrowEnds),
            typeof(ArrowBase),
            new FrameworkPropertyMetadata(ArrowEnds.End, FrameworkPropertyMetadataOptions.AffectsMeasure));

        /// <summary>
        /// ��ͷ�Ƿ�պϵ���������
        /// </summary>
        public static readonly DependencyProperty IsArrowClosedProperty = DependencyProperty.Register(
            "IsArrowClosed",
            typeof(bool),
            typeof(ArrowBase),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsMeasure));

        /// <summary>
        /// ��ʼ��
        /// </summary>
        public static readonly DependencyProperty StartPointProperty = DependencyProperty.Register(
            "StartPoint",
            typeof(Point),
            typeof(ArrowBase),
            new FrameworkPropertyMetadata(default(Point), FrameworkPropertyMetadataOptions.AffectsMeasure));

        #endregion DependencyProperty

        /// <summary>
        /// ������״(������ͷ�;�����״)
        /// </summary>
        private readonly PathGeometry geometryWhole = new PathGeometry();

        /// <summary>
        /// ��ȥ��ͷ��ľ�����״
        /// </summary>
        private readonly PathFigure figureConcrete = new PathFigure();

        /// <summary>
        /// ��ʼ���ļ�ͷ�߶�
        /// </summary>
        private readonly PathFigure figureStart = new PathFigure();

        /// <summary>
        /// �������ļ�ͷ�߶�
        /// </summary>
        private readonly PathFigure figureEnd = new PathFigure();

        #endregion Fields

        #region Constructor

        /// <summary>
        /// ���캯��
        /// </summary>
        protected ArrowBase()
        {

            //�Ҽ��˵�
            ContextMenu contextMenu = new ContextMenu();
            MenuItem changelinecolor = new MenuItem();
            changelinecolor.Click += (s, e) => { this.SetStrokeColor(); };
            changelinecolor.Header = ContextMenuLabelEnum.�ı���ɫ;
            MenuItem changelinestroke = new MenuItem();
            changelinestroke.Header = ContextMenuLabelEnum.�ı��߿�;
            MenuItem deleteline = new MenuItem();
            deleteline.Click += (s, e) => { this.DeleteLine(); };
            deleteline.Header = ContextMenuLabelEnum.ɾ��;

            contextMenu.Items.Add(changelinecolor);
            contextMenu.Items.Add(changelinestroke);
            contextMenu.Items.Add(deleteline);

            this.ContextMenu = contextMenu;


            var polyLineSegStart = new PolyLineSegment();
            this.figureStart.Segments.Add(polyLineSegStart);

            var polyLineSegEnd = new PolyLineSegment();
            this.figureEnd.Segments.Add(polyLineSegEnd);

            this.geometryWhole.Figures.Add(this.figureConcrete);
            this.geometryWhole.Figures.Add(this.figureStart);
            this.geometryWhole.Figures.Add(this.figureEnd);

        }

        #endregion Constructor

        #region Properties


        public abstract  Point EndPoint { get; set; }

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

        /// <summary>
        /// �����ߵ���ʼ�Ƿ��Ѿ����ӵ������
        /// </summary>
        private bool _startPointConnected = false;

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
        private bool _endPointConnected = false;

        /// <summary>
        /// ���û��߻���ߵ��յ��Ƿ��Ѿ����ӵ������
        /// </summary>
        public bool EndPointConnected
        {
            get { return _endPointConnected; }
            set { _endPointConnected = value; }
        }

        /// <summary>
        /// ��ͷ���߼н�
        /// </summary>
        public double ArrowAngle
        {
            get { return (double)this.GetValue(ArrowAngleProperty); }
            set { this.SetValue(ArrowAngleProperty, value); }
        }

        /// <summary>
        /// ��ͷ���ߵĳ���
        /// </summary>
        public double ArrowLength
        {
            get { return (double)this.GetValue(ArrowLengthProperty); }
            set { this.SetValue(ArrowLengthProperty, value); }
        }

        /// <summary>
        /// ��ͷ���ڶ�
        /// </summary>
        public ArrowEnds ArrowEnds
        {
            get { return (ArrowEnds)this.GetValue(ArrowEndsProperty); }
            set { this.SetValue(ArrowEndsProperty, value); }
        }

        /// <summary>
        /// ��ͷ�Ƿ�պ�
        /// </summary>
        public bool IsArrowClosed
        {
            get { return (bool)this.GetValue(IsArrowClosedProperty); }
            set { this.SetValue(IsArrowClosedProperty, value); }
        }

        /// <summary>
        /// ��ʼ��
        /// </summary>
        public Point StartPoint
        {
            get { return (Point)this.GetValue(StartPointProperty); }
            set { this.SetValue(StartPointProperty, value); }
        }

        /// <summary>
        /// ������״
        /// </summary>
        protected override Geometry DefiningGeometry
        {
            get
            {
                this.figureConcrete.StartPoint = this.StartPoint;

                // ��վ�����״,�����ظ����
                this.figureConcrete.Segments.Clear();
                var segements = this.FillFigure();
                if (segements != null)
                {
                    foreach (var segement in segements)
                    {
                        this.figureConcrete.Segments.Add(segement);
                    }
                }

                // ���ƿ�ʼ���ļ�ͷ
                if ((this.ArrowEnds & ArrowEnds.Start) == ArrowEnds.Start)
                {
                    this.CalculateArrow(this.figureStart, this.GetStartArrowEndPoint(), this.StartPoint);
                }

                // ���ƽ������ļ�ͷ
                if ((this.ArrowEnds & ArrowEnds.End) == ArrowEnds.End)
                {
                    this.CalculateArrow(this.figureEnd, this.GetEndArrowStartPoint(), this.GetEndArrowEndPoint());
                }

                return this.geometryWhole;
            }
        }

        #endregion Properties

        #region Protected Methods

        /// <summary>
        /// ��ȡ������״�ĸ�����ɲ���
        /// </summary>
        /// <returns>PathSegment����</returns>
        protected abstract PathSegmentCollection FillFigure();

        /// <summary>
        /// ��ȡ��ʼ��ͷ���Ľ�����
        /// </summary>
        /// <returns>��ʼ��ͷ���Ľ�����</returns>
        protected abstract Point GetStartArrowEndPoint();

        /// <summary>
        /// ��ȡ������ͷ���Ŀ�ʼ��
        /// </summary>
        /// <returns>������ͷ���Ŀ�ʼ��</returns>
        protected abstract Point GetEndArrowStartPoint();

        /// <summary>
        /// ��ȡ������ͷ���Ľ�����
        /// </summary>
        /// <returns>������ͷ���Ľ�����</returns>
        protected abstract Point GetEndArrowEndPoint();

        #endregion  Protected Methods

        #region Private Methods

        /// <summary>
        /// ����������֮��������ͷ
        /// </summary>
        /// <param name="pathfig">��ͷ���ڵ���״</param>
        /// <param name="startPoint">��ʼ��</param>
        /// <param name="endPoint">������</param>
        private void CalculateArrow(PathFigure pathfig, Point startPoint, Point endPoint)
        {
            var polyseg = pathfig.Segments[0] as PolyLineSegment;
            if (polyseg != null)
            {
                var matx = new Matrix();
                Vector vect = startPoint - endPoint;

                // ��ȡ��λ����
                vect.Normalize();
                vect *= this.ArrowLength;

                // ��ת�нǵ�һ��
                matx.Rotate(this.ArrowAngle / 2);

                // �����ϰ�μ�ͷ�ĵ�
                pathfig.StartPoint = endPoint + (vect * matx);

                polyseg.Points.Clear();
                polyseg.Points.Add(endPoint);

                matx.Rotate(-this.ArrowAngle);

                // �����°�μ�ͷ�ĵ�
                polyseg.Points.Add(endPoint + (vect * matx));
            }

            pathfig.IsClosed = this.IsArrowClosed;
        }

        #endregion Private Methods

        #region Public Methods

        /// <summary>
        /// �ߵ���ʼ�˸�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public abstract void MoveStartWithMouse(object sender, MouseEventArgs e);

        /// <summary>
        /// �ߵ�ĩ�˸�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public abstract void MoveEndWithMouse(object sender, MouseEventArgs e);


        /// <summary>
        /// �����ߵ���ɫ
        /// </summary>
        /// <param name="brush"></param>
        public virtual void SetStrokeColor()
        {
            {
                System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();
                if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    System.Drawing.SolidBrush sb = new System.Drawing.SolidBrush(colorDialog.Color);
                    SolidColorBrush solidColorBrush = new SolidColorBrush(Color.FromArgb(sb.Color.A, sb.Color.R, sb.Color.G, sb.Color.B));
                    //�������������
                    CommandManager.CommandManager commandManager = CommandManager.CommandManager.GetInstance();
                    ISSCommand.ISSCommand setLineColorCommand = new SetLineColorCommand(this, solidColorBrush);

                    commandManager.ExecuteCommand(setLineColorCommand);
                }
            }

        }


        /// <summary>
        /// ɾ����
        /// </summary>
        public virtual void DeleteLine()
        {
            CommandManager.CommandManager commandManager = CommandManager.CommandManager.GetInstance();
            DeleteLineCommand deleteLineCommand = new DeleteLineCommand(this);
            commandManager.ExecuteCommand(deleteLineCommand);
            //DeleteLineCommand
        }

        #endregion





    }
}
