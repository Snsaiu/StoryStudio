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

namespace NodeBase
{
    /// <summary>
    /// Interaction logic for NodeComponentBase.xaml
    /// </summary>
    public abstract partial class NodeComponentBase : UserControl
    {
        public NodeComponentBase()
        {
            //InitializeComponent();
            this.LoadViewFromUri("/NodeBase;component/nodecomponentbase.xaml");
          
            // 初始化属性容器
            this._stringAttrs = new List<StringAttr>();
            this._intAttrs = new List<IntAttr>();
            this._boolAttrs = new List<BoolAttr>();
            this._listAttrs = new List<ListAttr>();
            this._mulitSelectAttrs = new List<MulitSelectAttr>();

            //添加属性
            this.SetAttributes();
            this.IOComponentBtn.Click += ClickEvent;

            // 添加组件显示名称
            if (String.IsNullOrEmpty(this.Label))
            {
                this.IOComponentBtn.Content = "X";
            }
            else
            {
                this.IOComponentBtn.Content = this.Label;
            }
        }

        /// <summary>
        /// 组件点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected abstract void ClickEvent(object sender, RoutedEventArgs e);
  



        /// <summary>
        /// 组件显示标签
        /// </summary>
        public abstract string Label { get; }

        /// <summary>
        /// 组件短名
        /// </summary>
        public abstract string ShortName { get; }

        /// <summary>
        /// 组件长名
        /// </summary>
        public abstract string LongName { get; }

        /// <summary>
        /// 组件类型
        /// </summary>
        public abstract string Type { get; }

        /// <summary>
        /// 存放字符串属性
        /// </summary>
        private List<StringAttr> _stringAttrs = null;

        /// <summary>
        /// 存放数字属性
        /// </summary>
        private List<IntAttr> _intAttrs = null;

        /// <summary>
        /// 存放bool属性
        /// </summary>
        private List<BoolAttr> _boolAttrs = null;

        /// <summary>
        /// 存放单选列表属性
        /// </summary>
        private List<ListAttr> _listAttrs = null;

        /// <summary>
        /// 存放多选列表属性
        /// </summary>
        private List<MulitSelectAttr> _mulitSelectAttrs = null;


        /// <summary>
        /// 添加一个新的字符串属性到字符串属性容器中
        /// </summary>
        /// <param name="name">属性的唯一标识名</param>
        /// <param name="displayname">属性显示名称</param>
        /// <param name="defalultvalue">属性默认值</param>
        /// <param name="hascontent">true：启用大面积输入框</param>
        /// <param name="displayOnNode">true:属性显示在Node面板中</param>
        /// <returns>若添加成功返回true，否则返回false</returns>
        protected bool AddStringAttr(string name,string displayname,string defalultvalue,bool hascontent,bool displayOnNode)
        {
            if (this._stringAttrs!=null)
            {
                //判断name是否有冲突
                foreach (var item in this._stringAttrs)
                {
                    if (item.Name==name)
                    {
                        return false;
                    }
                }

                // 添加新属性到容器中
                this._stringAttrs.Add(new StringAttr() { Name = name, DisplayName = displayname, DefaultValue = defalultvalue, HasContent = hascontent,DisplayOnNode=displayOnNode });
                return true;
            
            }
            return false;
        }



        /// <summary>
        /// 添加属性到组件中
        /// </summary>
        /// <returns>若添加成功返回true，否则返回false</returns>
        protected abstract bool SetAttributes();

    }

}
