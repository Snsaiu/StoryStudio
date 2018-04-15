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
    /// Interaction logic for FloatAttrUI.xaml
    /// </summary>
    public partial class FloatAttrUI : UserControl
    {
        public FloatAttrUI()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置或者获得浮点型组件Ui的显示标签
        /// </summary>
        public string FloatUILabel { get => this.FloatLabel.Text; set => this.FloatLabel.Text = value; }

        /// <summary>
        /// 设置或者获得浮点型组件ui的显示内容
        /// </summary>
        public string FloatUIContent { get => this.FloatContent.Text; set => this.FloatContent.Text = value; }


        /// <summary>
        /// 检测文本是否使数字
        /// </summary>
        /// <param name="text">检测文本</param>
        /// <returns>若是数字返回false,否则返回true</returns>
        private bool validateFloatValue(string text)
        {
            string reg = "[^0-9.-]+";
            Regex regex = new Regex(reg);
            bool result = regex.IsMatch(text);
            return result;
        }

        private void StrContent_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            e.Handled = validateFloatValue(e.Text);

        }

        private void FloatContent_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
               
            {
               
                String text = (String)e.DataObject.GetData(typeof(String));
               
                if (validateFloatValue(text))                 
                { e.CancelCommand(); }            
            }       
            else { e.CancelCommand(); }
        }
    }
}
