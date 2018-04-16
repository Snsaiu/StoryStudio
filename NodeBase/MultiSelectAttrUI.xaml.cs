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
    /// Interaction logic for MultiSelectAttrUI.xaml
    /// </summary>
    public partial class MultiSelectAttrUI : UserControl
    {
        public MultiSelectAttrUI()
        {
            InitializeComponent();
        }

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


                foreach (var item in value)
                {
                    this.MultiSelectContent.SelectedItems.Add(item);
                }

            } }


    }
}
