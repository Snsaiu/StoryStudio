using IPanelBase;
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

namespace NodePanel
{
    /// <summary>
    /// Interaction logic for NodePanel.xaml
    /// </summary>
    public partial class NodePanel : UserControl,IPanelBase.IPanelBase
    {
        public NodePanel()
        {
            InitializeComponent();
        }

        public string PanelLabel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void SetPanelFloat(UIElement parent)
        {
            throw new NotImplementedException();
        }

        public void SetPanelNoFloat(UIElement parent)
        {
            throw new NotImplementedException();
        }
    }
}
