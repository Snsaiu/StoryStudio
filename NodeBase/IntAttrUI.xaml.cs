using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for IntAttrUI.xaml
    /// </summary>
    public partial class IntAttrUI : UserControl
    {
        public IntAttrUI()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 设置或者获得整型组件Ui的显示标签
        /// </summary>
        public string FloatUILabel { get => this.IntLabel.Text; set => this.IntLabel.Text = value; }

        /// <summary>
        /// 设置或者获得整型组件ui的显示内容
        /// </summary>
        public string FloatUIContent { get => this.IntContent.Text; set => this.IntContent.Text = value; }



        private void IntContent_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))

            {

                String text = (String)e.DataObject.GetData(typeof(String));

                if (ValidateIntValue(text))
                { e.CancelCommand(); }
            }
            else { e.CancelCommand(); }
        }

        private void IntContent_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = ValidateIntValue(e.Text);
        }

        private bool ValidateIntValue(string text)
        {
            string reg = "[^0-9-]+";
            Regex regex = new Regex(reg);
            bool result = regex.IsMatch(text);
            return result;
        }
    }
}
