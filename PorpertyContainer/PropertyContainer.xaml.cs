using NodeBase;
using System;
using System.Windows;
using System.Windows.Controls;

namespace PorpertyContainer
{
    /// <summary>
    /// Interaction logic for PropertyContainer.xaml
    /// </summary>
    public partial class PropertyContainer : UserControl, IPanelBase.IPanelBase, IJoinGlobalTracker.IJoinGlobalTracker
    {

        public void Join()
        {
            GlobalTracker.GlobalTracker gt = GlobalTracker.GlobalTracker.GetInstance();
            gt.AddPanelInstance(this);
        }

        public bool Quit()
        {
            GlobalTracker.GlobalTracker gt = GlobalTracker.GlobalTracker.GetInstance();
            return gt.RemovePanelByShortName("CP");
        }
        public PropertyContainer()
        {
            InitializeComponent();
            PropertyPanel p = new PropertyPanel();
            GlobalTracker.GlobalTracker.GetInstance().PropertyPanel = p;
            this.PriPropertyGrid.Children.Add(p);
        }



        private bool _isactivity = false;

        public bool IsActivity { get => _isactivity; set => this._isactivity = value; }

        public string PanelLabel => "属性面板";
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public global::BaseTypeEnum.BaseTypeEnum BaseType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string ShortName => "PCP";

        public string LongName => "PropertyContainerPanel";

        public bool FindDataByTag(string tag, out object resource)
        {
            throw new NotImplementedException();
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
