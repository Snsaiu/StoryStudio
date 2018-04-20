using GlobalTracker;
using IJoinGlobalTracker;
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

namespace ToolBarPanel
{
    /// <summary>
    /// Interaction logic for ToolBarPanel.xaml
    /// </summary>
    public partial class ToolBarPanel : UserControl,IPanelBase.IPanelBase, IJoinGlobalTracker.IJoinGlobalTracker
    {
     
        public ToolBarPanel()
        {
            InitializeComponent();
          
        }

        public ToolBar toolbar { get=>this.tb; }

        public string PanelLabel =>"工具栏";

        public string ShortName => "TBP";

        public string LongName => "ToolBarPanel";

        public bool IsActivity { get => IsActivity; set => IsActivity = value; }
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public global::BaseTypeEnum.BaseTypeEnum BaseType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool FindDataByTag(string tag, out object resource)
        {
            throw new NotImplementedException();
        }

        public void Join()
        {
            GlobalTracker.GlobalTracker gt = GlobalTracker.GlobalTracker.GetInstance();
            gt.AddPanelInstance(this);
        }

        public bool Quit()
        {
            GlobalTracker.GlobalTracker gt = GlobalTracker.GlobalTracker.GetInstance();
            return gt.RemovePanelByShortName("TBP");
        }

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
