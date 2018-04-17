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

namespace SSLine
{
    /// <summary>
    /// Interaction logic for EditLIneTextWindow.xaml
    /// </summary>
    public partial class EditLIneTextWindow : Window
    {
        private ArrowLineWithText _lineWithText;
        public EditLIneTextWindow(ArrowLineWithText lineWithText)
        {
            InitializeComponent();

            this._lineWithText = lineWithText;
            // 获得数据
            this.contentTxt.Text = this._lineWithText.Text;
        }
    }
}
