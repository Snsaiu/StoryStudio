using System.Windows;
using System.Windows.Controls;

namespace Menu
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl,IPanelBase.IPanelBase
    {
        public Menu()
        {
            InitializeComponent();
        }

        public string PanelLabel { get; set; }
        public int Id { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public global::BaseTypeEnum.BaseTypeEnum BaseType { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public bool FindDataByTag(string tag, out object resource)
        {
            throw new System.NotImplementedException();
        }

        public void SetPanelFloat(UIElement parent)
        {
            // todo: need implement;
        }

        public void SetPanelNoFloat(UIElement parent)
        {
            // todo: need implement;
        }
    }
}
