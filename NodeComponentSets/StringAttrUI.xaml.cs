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

namespace NodeComponentSets
{
    /// <summary>
    /// Interaction logic for StringAttrUI.xaml
    /// </summary>
    public partial class StringAttrUI : UserControl
    {
        public StringAttrUI(NodeComponentBase Component)
        {
            //InitializeComponent();
            this.LoadViewFromUri("/NodeComponentSets;component/stringattrui.xaml");

            this.StrContent.LostFocus += (s, e) => { Component.NotifyUpdate(); };
        }

        /// <summary>
        /// 设置或者获得字符串组件Ui的显示标签
        /// </summary>
        public string StrUILabel { get=>this.StrLabel.Text; set=> this.StrLabel.Text=value; }

        /// <summary>
        /// 设置或者获得字符串组件ui的显示内容
        /// </summary>
        public string StrUIContent { get=>this.StrContent.Text; set=>this.StrContent.Text=value; }
    }
}
