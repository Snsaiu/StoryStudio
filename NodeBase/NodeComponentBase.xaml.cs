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
            this._floatAttrs = new List<FloatAttr>();
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
        /// 获得字符串属性集合
        /// </summary>
        /// <returns>返回字符串集合如果存在，否则返回Null</returns>
        public List<StringAttr> GetStringAttrSet()
        {
            if (this._stringAttrs!=null)
            {
                return this._stringAttrs;
            }
            return null;
        }

        /// <summary>
        /// 存放数字属性
        /// </summary>
        private List<IntAttr> _intAttrs = null;

        /// <summary>
        /// 获得Int属性集合
        /// </summary>
        /// <returns>返回int集合如果存在，否则返回Null</returns>
        public List<IntAttr> GetIntAttrSet()
        {
            if (this._intAttrs != null)
            {
                return this._intAttrs;
            }
            return null;
        }

        /// <summary>
        /// 存放浮点型数字属性
        /// </summary>
        private List<FloatAttr> _floatAttrs = null;

        /// <summary>
        /// 获得浮点型属性集合
        /// </summary>
        /// <returns>返回浮点型数字集合如果存在，否则返回null</returns>
        public List<FloatAttr> GetFloatAttrSet()
        {
            if (this._floatAttrs!=null)
            {
                return this._floatAttrs;
            }
            return null;
        }


        /// <summary>
        /// 存放bool属性
        /// </summary>
        private List<BoolAttr> _boolAttrs = null;

        /// <summary>
        /// 获得bool属性集合
        /// </summary>
        /// <returns>返回bool集合如果存在，否则返回null</returns>
        public List<BoolAttr> GetBoolAttrSet()
        {
            if (this._boolAttrs!=null)
            {
                return this._boolAttrs;
            }
            return null;
        }

        /// <summary>
        /// 存放单选列表属性
        /// </summary>
        private List<ListAttr> _listAttrs = null;
        
        /// <summary>
        /// 获得单选集合列表集合
        /// </summary>
        /// <returns>返回单选列表集合如果存在，否则返回null</returns>
        public List<ListAttr> GetListAttrSet()
        {
            if (this._listAttrs!=null)
            {
                return this._listAttrs;
            }
            return null;
        }


        /// <summary>
        /// 存放多选列表属性
        /// </summary>
        private List<MulitSelectAttr> _mulitSelectAttrs = null;

        /// <summary>
        /// 获得多选集合列表集合
        /// </summary>
        /// <returns>返回多选列表集合如果存在，否则返回null</returns>
        public List<MulitSelectAttr> GetMulitSelectAttrSet()
        {
            if (this._mulitSelectAttrs!=null)
            {
                return this._mulitSelectAttrs;
            }
            return null;
        }
   

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
       /// 添加一个新的浮点型属性到浮点型属性容器中
       /// </summary>
       /// <param name="name">属性的唯一标识名</param>
       /// <param name="displayname">属性显示名称</param>
       /// <param name="defalutvalue">属性默认值</param>
       /// <param name="displayOnNode">true：属性显示在node面板中</param>
       /// <returns>若添加成功返回true，否则返回false</returns>
        protected bool AddFloatAttr(string name,string displayname,float defalutvalue,bool displayOnNode)
        {
            if (this._floatAttrs!=null)
            {
                foreach (var item in this._floatAttrs)
                {
                    if (item.Name==name)
                    {
                        return false;
                    }

                }
                this._floatAttrs.Add(new FloatAttr() { Name = name, DisplayName = displayname, DefaultValue = defalutvalue, DisplayOnNode = displayOnNode });
                return true;
            }

            return false;
        }

        /// <summary>
        /// 添加一个新的整型属性到容器中
        /// </summary>
        /// <param name="name">属性的唯一标识名</param>
        /// <param name="displayname">属性显示名称</param>
        /// <param name="defaultvalue">属性默认值</param>
        /// <param name="displayonNode">true：属性显示在node面板中</param>
        /// <returns>若添加成功返回true，否则返回false</returns>
        protected bool AddIntAttr(string name,string displayname,int defaultvalue,bool displayOnNode)
        {
            if (this._floatAttrs!=null)
            {
                foreach (var item in this._intAttrs)
                {
                    if (item.Name==name)
                    {
                        return false;
                    }
                }
                this._intAttrs.Add(new IntAttr() { Name = name, DisplayName = displayname, DefaultValue = defaultvalue, DisplayOnNode = displayOnNode });
                return true;
            }

            return false;
        }

        /// <summary>
        /// 添加一个新的bool属性到容器中
        /// </summary>
        /// <param name="name">属性的唯一标识名</param>
        /// <param name="displayname">属性显示名称</param>
        /// <param name="defalutvalue">属性默认值</param>
        /// <param name="displayOnNode">true：属性显示在node面板中</param>
        /// <returns>若添加成功返回true，否则返回false</returns>
        protected bool AddBoolAttr(string name,string displayname,bool defalutvalue,bool displayOnNode)
        {
            if (this._boolAttrs!=null)
            {
                foreach (var item in this._boolAttrs)
                {
                    if (item.Name==name)
                    {
                        return false;
                    }
                }
                this._boolAttrs.Add(new BoolAttr() { Name = name, DisplayName = displayname, DefaultValue = defalutvalue, DisplayOnNode = displayOnNode });
                return true;
            }

            return false;
        }

        /// <summary>
        /// 添加一个新的单选列表到属性容器中
        /// </summary>
        /// <param name="name">属性的唯一标识名</param>
        /// <param name="displayname">属性显示名称</param>
        /// <param name="value">单选列表内容</param>
        /// <param name="defaultindex">单选列表默认值</param>
        /// <param name="displayOnNode">true：属性显示在node面板中</param>
        /// <returns>若添加成功返回true，否则返回false</returns>
        protected bool AddListAttr(string name,string displayname, List<string> value, int defaultindex,bool displayOnNode)
        {
            if (this._listAttrs!=null)
            {
                foreach (var item in this._listAttrs)
                {
                    if (item.Name==name)
                    {
                        return false;
                    }
                    this._listAttrs.Add(new ListAttr() { Name = name, DisplayName = displayname, Value = value, DefaultIndex = defaultindex, DisplayOnNode = displayOnNode });
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 添加一个新的多选列表到属性容器中
        /// </summary>
        /// <param name="name">属性的唯一标识名</param>
        /// <param name="displayname">属性显示名称</param>
        /// <param name="value">多选列表内容</param>
        /// <param name="defaultindexs">多选列表默认值</param>
        /// <param name="displayOnNode">true：属性显示在node面板中</param>
        /// <returns>若添加成功返回true，否则返回false</returns>
        protected bool AddMultiSelectAttr(string name,string displayname,List<string> value,List<int> defaultindexs,bool displayOnNode)
        {

            if (this._mulitSelectAttrs!=null)
            {
                foreach (var item in this._mulitSelectAttrs)
                {
                    if (item.Name==name)
                    {
                        return false;
                    }
                }
                this._mulitSelectAttrs.Add(new MulitSelectAttr() { Name = name, DisplayName = displayname, Value = value, DefaultIndexs = defaultindexs, DisplayOnNode = displayOnNode });
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
