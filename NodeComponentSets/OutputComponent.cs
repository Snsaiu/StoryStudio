using GlobalTracker;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NodeBase
{
    public abstract class OutputComponent : NodeComponentBase
    {

        private Canvas canvas = null;

  
        public OutputComponent(NodeBase node):base(node)
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
                ArrowLine line = LineTracker.StoreLineObj as ArrowLine;

                //判断是否可以进行连接
                if (line.EndComponent is NodeComponentBase)
                {
                    NodeComponentBase temp = line.EndComponent as NodeComponentBase;
                    // 判断组件类型是否能够连接

                    //判断当前两个组件是否已经存在链接

                    if (this.RegistedComponents!=null)
                    {
                        foreach (var item in this.RegistedComponents)
                        {
                            if (item==temp)
                            {
                                return;
                            }
                        }
                    }


                    if (temp.Type==this.Type)
                    {
                        if (temp.IOType==BaseTypeEnum.IOTypeEnum.input)
                        {
                            this.canvas.MouseMove -= line.MoveStartWithMouse;
                            line.StartComponent = this;
                            CommandManager.CommandManager commandManager = CommandManager.CommandManager.GetInstance();
                            CreateLineCommand createLineCommand = new CreateLineCommand(line, this.canvas);
                            commandManager.ExecuteCommand(createLineCommand);

                            line.IsHitTestVisible = true;

                            LineTracker.CanCreateLine = true;
                            LineTracker.StoreLineObj = null;

                            //加入命令 要保存线实例 命令要保证组件(节点移动要带动线的移动)
                        
                        //CreateLineCommand createLineCommand=new CreateLineCommand()


                        }
                    }

                }
                return;
            }



            //创建线工厂
            SSLineFactoryAbs sSLineFactory = new DefaultLineFactory();
            ArrowBase arrowLineWithText = null;


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
                    this.canvas.Children.Remove(LineTracker.StoreLineObj as ArrowLine);
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
