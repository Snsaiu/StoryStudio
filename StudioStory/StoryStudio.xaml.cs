using System.Windows;
using System.Windows.Controls;

namespace StudioStory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 实例化globaltracker
            GlobalTracker.GlobalTracker globalTracker = GlobalTracker.GlobalTracker.GetInstance();

            //add menu ui

            Menu.Menu menu = new Menu.Menu();
            menu.SetValue(Grid.RowProperty, 0);
            menu.SetValue(Grid.ColumnSpanProperty, 3);
       
            this.MainGrid.Children.Add(menu);


            var panelPluginManager = new PanelPluginManager.PanelPluginManager();
            panelPluginManager.InstallPlugin();

            // add left panel ui


            // add  panel ui
            PanelContainer.PanelContainer leftpanel = new PanelContainer.PanelContainer("leftpanel");
            PanelContainer.PanelContainer mainPanel = new PanelContainer.PanelContainer("mainpanel");
            PanelContainer.PanelContainer propertyPanel = new PanelContainer.PanelContainer("rightpanel");

            foreach (var item in globalTracker.GetPanels())
            {
                leftpanel.AddNewPanel(item.PanelLabel, item as UIElement);
                mainPanel.AddNewPanel(item.PanelLabel, item as UIElement);
                propertyPanel.AddNewPanel(item.PanelLabel, item as UIElement);

            }

            //panelPluginManager.InstallPlugin(leftpanel);
            leftpanel.SetValue(Grid.RowProperty, 1);
            leftpanel.SetValue(Grid.ColumnProperty, 0);
            this.MainGrid.Children.Add(leftpanel);
           
  

            //panelPluginManager.InstallPlugin(mainPanel);

            mainPanel.SetValue(Grid.RowProperty, 2);
            mainPanel.SetValue(Grid.ColumnProperty, 1);
            mainPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
            mainPanel.VerticalAlignment = VerticalAlignment.Stretch;
            this.MainGrid.Children.Add(mainPanel);

          

          
            //panelPluginManager.InstallPlugin(propertyPanel);
            propertyPanel.SetValue(Grid.RowProperty, 2);
            propertyPanel.SetValue(Grid.ColumnProperty, 2);
            propertyPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
            propertyPanel.VerticalAlignment = VerticalAlignment.Stretch;
            this.MainGrid.Children.Add(propertyPanel);

            // add cmd panel

            CmdPanel.CmdPanel cmdPanel = new CmdPanel.CmdPanel();
            cmdPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
            cmdPanel.SetValue(Grid.RowProperty, 3);
            cmdPanel.SetValue(Grid.ColumnProperty, 0);
            cmdPanel.SetValue(Grid.ColumnSpanProperty, 3);
            this.MainGrid.Children.Add(cmdPanel);


            //加载Node

            NodePluginManager.NodePluginManager nodePluginManager= new NodePluginManager.NodePluginManager(globalTracker.GetPanelByShorName("NLP") as NodeListPanel.NodeListPanel);
            nodePluginManager.InstallPlugin();


        }


    }
}
