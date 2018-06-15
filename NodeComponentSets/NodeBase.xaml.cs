using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Reflection;
using System.IO.Packaging;
using System.Windows.Markup;
using DisplayLabelEnum;
using System.Windows.Media;
using CameraTake.View;

namespace NodeBase
{
    /// <summary>
    /// Interaction logic for NodeBase.xaml
    /// </summary>
    public abstract partial class NodeBase : UserControl
    {
        /// <summary>
        /// 输入组件集
        /// </summary>
        private List<InputComponent> _inputs = null;

        /// <summary>
        /// 输出组件集
        /// </summary>
        private List<OutputComponent> _outputs = null;

        public NodeBase()
        {
            // InitializeComponent();
            this.LoadViewFromUri("/NodeBase;component/nodebase.xaml");

            //装配组件
            this.RigComponent();

            //右键菜单
            this.CreateContextMenu();

            //双击事件
            this.MouseDoubleClick += (s, e) => { this.SendToPanel(); };
            // 绑定事件
            this.MouseMove += NodeBase_MouseMove;
            // 显示Nodelabel
            if (this.NodeLable=="")
            {
                this.nodelabel.Text = "未定义节点名称";
            
            }
            else
            {
                this.nodelabel.Text = this.NodeLable;
            }
        }

        /// <summary>
        /// 创建右键菜单
        /// </summary>
        private void CreateContextMenu()
        {
            ContextMenu contextMenu = new ContextMenu();

            MenuItem drawTakemenu = new MenuItem();
            drawTakemenu.Header = ContextMenuLabelEnum.绘制分镜;
            drawTakemenu.Click += (s, e) =>
            {
                CameraTakeView _v = new CameraTakeView();
                _v.ShowDialog();
            };

            MenuItem editmenu = new MenuItem();
            editmenu.Header = ContextMenuLabelEnum.编辑;
            MenuItem deletemenu = new MenuItem();
            deletemenu.Header = ContextMenuLabelEnum.删除;
            MenuItem focusmenu = new MenuItem();
            focusmenu.Header = ContextMenuLabelEnum.聚焦;
            MenuItem asTakemenu = new MenuItem();
            //作为镜头是一个checkbox，根据是否勾选来判断是否作为镜头，
            //作为镜头的特点就是节点的背景色会发生改变
            CheckBox _c = new CheckBox();

            //如果被勾选
            _c.Checked += (s, e) => {
                //转换背景边框的颜色
                this.nodeborder.BorderBrush= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE93939"));

                // todo:应该将设为镜头的节点放到一个容器当中去
            };


            // 如果取消勾选
            _c.Unchecked += (s, e) =>
            {
                //还原背景边框的颜色
                this.nodeborder.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF259AFD"));
                //todo:容器中要剔除该节点

            };
            _c.Content = ContextMenuLabelEnum.作为镜头;
            asTakemenu.Header = _c;
            contextMenu.Items.Add(asTakemenu);
            contextMenu.Items.Add(drawTakemenu);
            contextMenu.Items.Add(editmenu);
            contextMenu.Items.Add(deletemenu);
            contextMenu.Items.Add(focusmenu);

            //todo:这里可以添加一个扩张

            this.ContextMenu = contextMenu;
        }


        private void SendToPanel()
        {
            (GlobalTracker.GlobalTracker.GetInstance().PropertyPanel as PropertyPanel).ParseNode(this);
        }
        /// <summary>
        /// 组装组件
        /// </summary>
        private void RigComponent()
        {
            this._inputs = this.AddInputComponent();
            this._outputs = this.AddOutputComponent();

            if (this._inputs!=null)
            {
                for (int i = 0; i < this._inputs.Count; i++)
                {
                    this.inputgrid.ColumnDefinitions.Add(new ColumnDefinition());
                    Viewbox v = new Viewbox();
                    v.Child = this._inputs[i];
                    this.inputgrid.Children.Add(v);
                    Grid.SetColumn(v, i);
                    
                    //输入组件 显示

                    //判断Node是否显示string类型组件
                    foreach (var item in this._inputs[i].GetStringAttrSet())
                    {
                        if (item.DisplayOnNode)
                        {
                            StringAttrUI stringAttrUI = new StringAttrUI(this._inputs[i]);
                            stringAttrUI.StrUILabel = item.DisplayName;
                            stringAttrUI.StrUIContent = item.DefaultValue;
                            item.SetUi(stringAttrUI);
                            stringAttrUI.CanEdit = false;
                            stringAttrUI.StrContent.PreviewKeyDown += (s, e) => { item.DefaultValue = stringAttrUI.StrUIContent; };
                            stringAttrUI.StrContent.TextChanged += (s, e) => { item.DefaultValue = stringAttrUI.StrUIContent; };
                            this.componentstack.Children.Add(stringAttrUI);
                        }
                    }
                    // 判断node是否显示int类型组件
                    foreach (var item in this._inputs[i].GetIntAttrSet())
                    {
                        if (item.DisplayOnNode)
                        {
                          
                            IntAttrUI intAttr = new IntAttrUI(this._inputs[i]);
                            intAttr.IntUILabel = item.DisplayName;
                            item.SetUi(intAttr);
                            intAttr.CanEdit = false;
                            intAttr.IntContent.PreviewKeyDown += (s, e) => { item.DefaultValue =int.Parse( intAttr.IntUIContent); };
                            intAttr.IntContent.TextChanged += (s, e) => { item.DefaultValue = int.Parse(intAttr.IntUIContent); };
                            intAttr.IntUIContent = item.DefaultValue.ToString();
                            this.componentstack.Children.Add(intAttr);
                        }
                    }
                    // 判断node是否显示float类型组件
                    foreach (var item in this._inputs[i].GetFloatAttrSet())
                    {
                        if (item.DisplayOnNode)
                        {
                            FloatAttrUI floatAttrUI = new FloatAttrUI(this._inputs[i]);
                            floatAttrUI.FloatUILabel = item.DisplayName;
                            item.SetUi(floatAttrUI);
                            floatAttrUI.CanEdit = false;
                            floatAttrUI.FloatContent.PreviewKeyDown += (s, e) => { item.DefaultValue = float.Parse(floatAttrUI.FloatUIContent); };
                            floatAttrUI.FloatContent.TextChanged += (s, e) => { item.DefaultValue = float.Parse(floatAttrUI.FloatUIContent); };
                            floatAttrUI.FloatUIContent = item.DefaultValue.ToString();
                            this.componentstack.Children.Add(floatAttrUI);
                        }
                    }

                    // 判断node是否显示单选类型组件
                    foreach (var item in this._inputs[i].GetListAttrSet())
                    {
                        if (item.DisplayOnNode)
                        {
                            ListAttrUI listAttrUI = new ListAttrUI(this._inputs[i]);
                            listAttrUI.ListUILabel = item.DisplayName;
                            listAttrUI.CanEdit = true;
                            item.SetUi(listAttrUI);
                            listAttrUI.ListContent.SelectionChanged += (s, e) => { item.DefaultIndex = listAttrUI.DefaultIndex; };
                            listAttrUI.ListUIContent = item.Value;
                            listAttrUI.DefaultIndex = item.DefaultIndex;
                            this.componentstack.Children.Add(listAttrUI);
                        }
                    }

                    // 判断Node是否显示多选类型组件
                    foreach (var item in this._inputs[i].GetMulitSelectAttrSet())
                    {
                        if (item.DisplayOnNode)
                        {
                            MulitSelectAttrUI MulitSelectAttrUI = new MulitSelectAttrUI(this._inputs[i]);
                            MulitSelectAttrUI.MultiSelectUILabel = item.DisplayName;
                            MulitSelectAttrUI.MulitListUIContent = item.Value;
                            MulitSelectAttrUI.DefaultIndexs = item.DefaultItems;
                            item.SetUi(MulitSelectAttrUI);
                            MulitSelectAttrUI.CanEdit = false;
                            MulitSelectAttrUI.MultiSelectContent.SelectionChanged += (s, e) => {  item.DefaultItems = MulitSelectAttrUI.DefaultIndexs; };
                            this.componentstack.Children.Add(MulitSelectAttrUI);
                        }
                    }

                    //判断是否显示Bool类型组件
                    foreach (var item in this._inputs[i].GetBoolAttrSet())
                    {
                        if (item.DisplayOnNode)
                        {
                            BoolAttrUI boolAttrUI = new BoolAttrUI(this._inputs[i]);
                            boolAttrUI.BoolUILabel = item.DisplayName;
                            item.SetUi(boolAttrUI);
                            boolAttrUI.CanEdit = true;
                            boolAttrUI.BoolContent.Click += (s, e) => { item.DefaultValue = boolAttrUI.BoolUIContent; };
                            boolAttrUI.BoolUIContent = item.DefaultValue;
                            this.componentstack.Children.Add(boolAttrUI);
                        }
                    }

                }
            }

            if (this._outputs!=null)
            {

                for (int i = 0; i < this._outputs.Count; i++)
                {
                    this.outputgrid.ColumnDefinitions.Add(new ColumnDefinition());
                    Viewbox v = new Viewbox();
                    v.Child = this._outputs[i];
                    this.outputgrid.Children.Add(v);
                    Grid.SetColumn(v, i);

                    // 输出组件显示
                    //判断Node是否显示string类型组件
                    foreach (var item in this._outputs[i].GetStringAttrSet())
                    {
                        if (item.DisplayOnNode)
                        {
                            StringAttrUI stringAttrUI = new StringAttrUI(this._outputs[i]);
                            stringAttrUI.StrUILabel = item.DisplayName;
                            stringAttrUI.StrUIContent = item.DefaultValue;
                            item.SetUi(stringAttrUI);
                            stringAttrUI.StrContent.PreviewKeyDown += (s, e) => { item.DefaultValue = stringAttrUI.StrUIContent;};
                            stringAttrUI.StrContent.TextChanged += (s, e) => { item.DefaultValue = stringAttrUI.StrUIContent; };
                            this.componentstack.Children.Add(stringAttrUI);
                        }
                    }
                    // 判断node是否显示int类型组件
                    foreach (var item in this._outputs[i].GetIntAttrSet())
                    {
                        if (item.DisplayOnNode)
                        {

                            IntAttrUI intAttr = new IntAttrUI(this._outputs[i]);
                            intAttr.IntUILabel = item.DisplayName;
                            item.SetUi(intAttr);
                            intAttr.IntContent.PreviewKeyDown += (s, e) => { item.DefaultValue = int.Parse( intAttr.IntUIContent); };
                            intAttr.IntContent.TextChanged += (s, e) => { item.DefaultValue = int.Parse(intAttr.IntUIContent); };
                            intAttr.IntUIContent = item.DefaultValue.ToString();
                            this.componentstack.Children.Add(intAttr);
                        }
                    }
                    // 判断node是否显示float类型组件
                    foreach (var item in this._outputs[i].GetFloatAttrSet())
                    {
                        if (item.DisplayOnNode)
                        {
                            FloatAttrUI floatAttrUI = new FloatAttrUI(this._outputs[i]);
                            floatAttrUI.FloatUILabel = item.DisplayName;
                            item.SetUi(floatAttrUI);
                            floatAttrUI.FloatContent.PreviewKeyDown += (s, e) => { item.DefaultValue = float.Parse(floatAttrUI.FloatUIContent); };
                            floatAttrUI.FloatContent.TextChanged += (s, e) => { item.DefaultValue = float.Parse(floatAttrUI.FloatUIContent); };
                            floatAttrUI.FloatUIContent = item.DefaultValue.ToString();
                            this.componentstack.Children.Add(floatAttrUI);
                        }
                    }

                    // 判断node是否显示单选类型组件
                    foreach (var item in this._outputs[i].GetListAttrSet())
                    {
                        if (item.DisplayOnNode)
                        {
                            ListAttrUI listAttrUI = new ListAttrUI(this._outputs[i]);
                            listAttrUI.ListUILabel = item.DisplayName;
                            item.SetUi(listAttrUI);
                            listAttrUI.ListContent.SelectionChanged += (s, e) => { item.DefaultIndex = listAttrUI.DefaultIndex; };
                            listAttrUI.ListUIContent = item.Value;
                            listAttrUI.DefaultIndex = item.DefaultIndex;
                            this.componentstack.Children.Add(listAttrUI);
                        }
                    }

                    // 判断Node是否显示多选类型组件
                    foreach (var item in this._outputs[i].GetMulitSelectAttrSet())
                    {
                        if (item.DisplayOnNode)
                        {
                            MulitSelectAttrUI MulitSelectAttrUI = new MulitSelectAttrUI(this._outputs[i]);
                            MulitSelectAttrUI.MultiSelectUILabel = item.DisplayName;
                            MulitSelectAttrUI.MulitListUIContent = item.Value;
                            item.SetUi(MulitSelectAttrUI);
                            MulitSelectAttrUI.DefaultIndexs = item.DefaultItems;
                            item.SetUi(MulitSelectAttrUI);
                            MulitSelectAttrUI.MultiSelectContent.SelectionChanged += (s, e) => {  item.DefaultItems = MulitSelectAttrUI.DefaultIndexs; };

                            this.componentstack.Children.Add(MulitSelectAttrUI);
                        }
                    }

                    //判断是否显示Bool类型组件
                    foreach (var item in this._outputs[i].GetBoolAttrSet())
                    {
                        if (item.DisplayOnNode)
                        {
                            BoolAttrUI boolAttrUI = new BoolAttrUI(this._outputs[i]);
                            boolAttrUI.BoolUILabel = item.DisplayName;
                            item.SetUi(boolAttrUI);
                            boolAttrUI.BoolContent.Click += (s, e) => { item.DefaultValue = boolAttrUI.BoolUIContent; };
                            boolAttrUI.BoolUIContent = item.DefaultValue;
                            this.componentstack.Children.Add(boolAttrUI);
                        }
                    }
                }
            }
        }

        public void NodeBase_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //判断一下是否有输入组件

            if (this._inputs!=null)
            {
                foreach (var item in this._inputs)
                {
                    item.NotifyMove();
                }
            }

            if (this._outputs!=null)
            {
                foreach (var item in this._outputs)
                {
                    item.NotifyMove();
                }
            }

        }


        /// <summary>
        /// 添加输入组件
        /// </summary>
        /// <returns>输入组件实例清单</returns>
        protected abstract List<InputComponent> AddInputComponent();

        /// <summary>
        /// 添加输出的组件
        /// </summary>
        /// <returns>输出组件实例清单</returns>
        protected abstract List<OutputComponent> AddOutputComponent();


        private Point _position;

        /// <summary>
        /// 设置节点的位置，获得节点的当前位置
        /// </summary>
        public Point Position
        {
            get => this._position;
            set => this._position = value;
        }

        /// <summary>
        /// 获得node显示名称
        /// </summary>
        public abstract string NodeLable { get; }

        /// <summary>
        /// 获得Node短名
        /// </summary>
        public abstract string ShortTag { get; }

        /// <summary>
        /// 获得node长名
        /// </summary>
        public abstract string LongTag { get;}

        /// <summary>
        /// 当前节点的下一群节点对象
        /// </summary>
        private List<NodeBase> _next;

        /// <summary>
        /// 保存或者添加下一群节点
        /// </summary>
        public List<NodeBase> Next
        {
            get { return _next; }
            set { _next = value; }
        }

        /// <summary>
        /// 使鼠标捕获自己
        /// </summary>
        /// <returns></returns>
        public bool CaptureMe()
        {
            return this.CaptureMouse();
        }

        /// <summary>
        /// 当数据发生变化时，通知其他的节点
        /// </summary>
        public void DataChanged()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 使鼠标不在捕获自己
        /// </summary>
        public void ReleaseMe()
        {
            this.ReleaseMouseCapture();
        }

        /// <summary>
        /// 创建一个自己的实例
        /// </summary>
        /// <returns>返回自己的实例</returns>
        public abstract NodeBase CreateSelf();

        /// <summary>
        /// 当点击生成节点的按钮时，确定节点的生成位置
        /// </summary>
        /// <param name="canvas">节点所在画布容器实例</param>
        public void SetMyInitialPositon(Canvas canvas)
        {
            NodeBase temp = CreateSelf();
          //  canvas.Children.Add(temp);
            Random r = new Random();
            double _left =500+r.Next(0,100);
            double _top = 300 + r.Next(0, 100);
            //Canvas.SetLeft(temp, 500 + _left);
            //Canvas.SetTop(temp, 300 + _top);
            GlobalTracker.GlobalTracker.GetInstance().LastNode = temp;
            //存储位置到自己本身
            temp.Position = new Point(_left, _top);
           
        }

        /// <summary>
        /// 获得节点的所有输入组件
        /// </summary>
        /// <returns></returns>
        public List<InputComponent> GetInputComponents()
        {
            return this._inputs;
        }

        /// <summary>
        /// 设置节点的所有输入组件
        /// </summary>
        /// <param name="inputComponents"></param>
        public void UpdateInputComponents(List<InputComponent> inputComponents)
        {
            
                this._inputs.Clear();
            this._inputs = inputComponents;

        }

        /// <summary>
        /// 设置节点的所有输出组件
        /// </summary>
        /// <param name="outputComponents"></param>
        public void UpdateOutputComponents(List<OutputComponent> outputComponents)
        {
            this._outputs.Clear();
            this._outputs = outputComponents;
        }

        /// <summary>
        /// 获得节点所有输出组件
        /// </summary>
        /// <returns></returns>
        public List<OutputComponent> GetOutputComponents()
        {
            return this._outputs;
        }

        /// <summary>
        /// 节点处理事务
        /// </summary>
        public virtual void Process()
        {
            if (this.GetInputComponents()!=null)
            {
                foreach (var item in this.GetInputComponents())
                {
                    item.NotifyUpdate();
                }
            }

            if (this.GetOutputComponents()!=null)
            {
                foreach (var item in this.GetOutputComponents())
                {
                    item.NotifyUpdate();
                }
            }

        }


    }

    static class Extension
    {
        public static void LoadViewFromUri(this UserControl userControl, string baseUri)
        {
            try
            {
                var resourceLocater = new Uri(baseUri, UriKind.Relative);
                var exprCa = (PackagePart)typeof(Application).GetMethod("GetResourceOrContentPart", BindingFlags.NonPublic | BindingFlags.Static).Invoke(null, new object[] { resourceLocater });
                var stream = exprCa.GetStream();
                var uri = new Uri((Uri)typeof(BaseUriHelper).GetProperty("PackAppBaseUri", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null, null), resourceLocater);
                var parserContext = new ParserContext
                {
                    BaseUri = uri
                };
                typeof(XamlReader).GetMethod("LoadBaml", BindingFlags.NonPublic | BindingFlags.Static).Invoke(null, new object[] { stream, parserContext, userControl, true });
            }
            catch (Exception)
            {
                //log
            }
        }
    }
}
