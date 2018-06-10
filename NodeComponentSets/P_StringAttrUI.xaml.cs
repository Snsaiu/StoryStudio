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
    /// Interaction logic for P_StringAttrUI.xaml
    /// </summary>
    public partial class P_StringAttrUI : UserControl
    {

        private StringAttr _stringattr = null;
       
        public P_StringAttrUI(StringAttr stringAttr)
        {
            InitializeComponent();
            this._stringattr = stringAttr;

            this.StrContent.TextChanged += (s, e) => { this._stringattr.UpdateUiContent(this.StrContent.Text); };
        }



        /// <summary>
        /// 设置或者获得属性ui是否可编辑
        /// </summary>
        public bool CanEdit { get => this.StrContent.IsEnabled; set => this.StrContent.IsEnabled = value; }

        /// <summary>
        /// 设置或者获得字符串组件Ui的显示标签
        /// </summary>
        public string StrUILabel { get => this.StrLabel.Text; set => this.StrLabel.Text = value; }

        /// <summary>
        /// 设置或者获得字符串组件ui的显示内容
        /// </summary>
        public string StrUIContent { get => this.StrContent.Text; set => this.StrContent.Text = value; }
    }
}
