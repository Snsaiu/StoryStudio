using BaseTypeEnum;
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

namespace CCPropertyPanel
{
    /// <summary>
    /// Interaction logic for CCPropertyPanel.xaml
    /// </summary>
    public partial class CCPropertyPanel : UserControl,IPanelBase.IPanelBase, IJoinGlobalTracker.IJoinGlobalTracker
    {
        public CCPropertyPanel()
        {
            InitializeComponent();
        }

        public string PanelLabel =>"角色属性面板";

        public string ShortName => "CCPP";

        public string LongName => "CCPropertyPanel";

        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public BaseTypeEnum.BaseTypeEnum BaseType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        private bool _isactivity = false;

        public bool IsActivity { get => _isactivity; set => this._isactivity = value; }

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
            return gt.RemovePanelByShortName("CCPP");
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
