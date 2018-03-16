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
using IPanelBase;

using NodePanel;

namespace IPanelContainer
{
    /// <summary>
    /// Interaction logic for PanelContainer.xaml
    /// </summary>
    public partial class PanelContainer : UserControl,IPanelContainer
    {
    
        private Dictionary<string, UIElement> _panelsDictionary = null;
        private UIElement _activityPanel = null;
        
        public PanelContainer()
        {
            
            InitializeComponent();

            this._panelsDictionary = new Dictionary<string, UIElement>();

            ///here need use plugin add panel
            this.TagList.ItemsSource = this._panelsDictionary;

            this.TagList.SelectionChanged += ((o, e) =>
            {
                int index = this.TagList.SelectedIndex;

                string key = this._panelsDictionary.ElementAt(index).Key;

                this.ActivityPanel(key);
             
            });
        }



        public void ActivityPanel(string PanelName)
        {
            if (this._panelsDictionary.ContainsKey(PanelName))
            {
                this.Container.Children.Clear();
                UIElement panel = this._panelsDictionary[PanelName];
                this.Container.Children.Add(panel);
                this._activityPanel = panel;
            }
    
        }

        public bool AddNewPanel(string PanelName, UIElement panel)
        {
            if (this._panelsDictionary.ContainsKey(PanelName))
            {
                return false;
            }
            else
            {
                this._panelsDictionary.Add(PanelName, panel);
                return true;
            }
        }

        public UIElement GetActivityPanel()
        {    
                return this._activityPanel;
        }

        public List<UIElement> GetChildren()
        {
            List<UIElement> list = new List<UIElement>();
            foreach (var item in this._panelsDictionary.Keys)
            {
                list.Add(this._panelsDictionary[item]);
            }
            return list;
        }
    }
}
