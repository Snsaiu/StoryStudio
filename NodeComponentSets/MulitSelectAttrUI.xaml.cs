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
    /// Interaction logic for MulitSelectAttrUI.xaml
    /// </summary>
    public partial class MulitSelectAttrUI : UserControl
    {
        public MulitSelectAttrUI(NodeComponentBase Component)
        {
            InitializeComponent();
            this.MultiSelectContent.SelectionChanged += (s, e) => { Component.NotifyUpdate(); };
        }

        public MulitSelectAttrUI()
        {

        }
        /// <summary>
        /// 设置或者获得属性ui是否能被编辑，通常输入属性不应该可编辑，输出组件可以编辑
        /// </summary>
        public bool CanEdit { get=>this.MultiSelectContent.IsEnabled; set=>this.MultiSelectContent.IsEnabled=value; }

        /// <summary>
        /// 设置或者获得多选组件Ui的显示标签
        /// </summary>
        public string MultiSelectUILabel { get => this.MultiSelectLabel.Text; set => this.MultiSelectLabel.Text = value; }

        /// <summary>
        /// 设置或者获得多选列表
        /// </summary>
        public List<string> MulitListUIContent { get => this.MultiSelectContent.ItemsSource as List<string>; set => this.MultiSelectContent.ItemsSource = value; }

        /// <summary>
        /// 设置或者获得多选列表所选的索引号
        /// </summary>
        public List<string> DefaultIndexs { get {

                return this.MultiSelectContent.SelectedItems as List<string>;
            }
            set {

                if (value!=null)
                {
                    foreach (var item in value)
                    {
                        this.MultiSelectContent.SelectedItems.Add(item);
                    }
                }

            } }


    }
}
