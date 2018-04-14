﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Reflection;
using System.IO.Packaging;
using System.Windows.Markup;

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

                    //判断是否Node显示组件
                    foreach (var item in this._inputs[i].GetStringAttrSet())
                    {
                        if (item.DisplayOnNode)
                        {
                            StringAttrUI stringAttrUI = new StringAttrUI();
                            stringAttrUI.StrUILabel = item.DisplayName;
                            stringAttrUI.StrUIContent = item.DefaultValue;
                            this.componentstack.Children.Add(stringAttrUI);
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


        /// <summary>
        /// 设置节点的位置，获得节点的当前位置
        /// </summary>
        public Point Position
        {
            set
            {
                Canvas.SetLeft(this, value.X);
                Canvas.SetTop(this, value.Y);
            }

            get { return new Point(Canvas.GetLeft(this),Canvas.GetTop(this)); }
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
            canvas.Children.Add(temp);
            Random r = new Random();
            Canvas.SetLeft(temp, 500 + r.Next(50, 100));
            Canvas.SetTop(temp, 300 + r.Next(50, 100));
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