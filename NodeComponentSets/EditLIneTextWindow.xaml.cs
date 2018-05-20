using System.Windows;

namespace NodeBase
{
    /// <summary>
    /// Interaction logic for EditLIneTextWindow.xaml
    /// </summary>
    public partial class EditLIneTextWindow : Window
    {
       
        private ArrowLineWithText.ArrowLineWithText _lineWithText;
        public EditLIneTextWindow(ArrowLineWithText.ArrowLineWithText lineWithText)
        {
            InitializeComponent();

            this._lineWithText = lineWithText;
            // 获得数据
            this.contentTxt.Text = this._lineWithText.Text;
        }

        /// <summary>
        /// 确定按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            this._lineWithText.Text = this.contentTxt.Text;
            this.Close();
        }

        /// <summary>
        /// 取消按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
