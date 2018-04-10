using System.Windows;
using System.Windows.Controls;
using System;
using NodePanel;
using IPanelContainer;
using PanelPluginManager;
using CmdPanel;
using GlobalTracker;

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

            globalTracker.AddPanelInstance(menu);


            var panelPluginManager = new PanelPluginManager.PanelPluginManager();

            // add left panel ui

            PanelContainer leftpanel = new PanelContainer();
            panelPluginManager.InstallPlugin(leftpanel);
            leftpanel.SetValue(Grid.RowProperty, 1);
            leftpanel.SetValue(Grid.ColumnProperty, 0);
            this.MainGrid.Children.Add(leftpanel);
           

          

            // add  panel ui


            PanelContainer mainPanel = new PanelContainer();

            panelPluginManager.InstallPlugin(mainPanel);

            mainPanel.SetValue(Grid.RowProperty, 1);
            mainPanel.SetValue(Grid.ColumnProperty, 1);
            mainPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
            mainPanel.VerticalAlignment = VerticalAlignment.Stretch;
            this.MainGrid.Children.Add(mainPanel);

            // add  panel ui

            PanelContainer propertyPanel = new PanelContainer();
            panelPluginManager.InstallPlugin(propertyPanel);
            propertyPanel.SetValue(Grid.RowProperty, 1);
            propertyPanel.SetValue(Grid.ColumnProperty, 2);
            propertyPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
            propertyPanel.VerticalAlignment = VerticalAlignment.Stretch;
            this.MainGrid.Children.Add(propertyPanel);

            // add cmd panel

            CmdPanel.CmdPanel cmdPanel = new CmdPanel.CmdPanel();
            cmdPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
            cmdPanel.SetValue(Grid.RowProperty, 2);
            cmdPanel.SetValue(Grid.ColumnProperty, 0);
            cmdPanel.SetValue(Grid.ColumnSpanProperty, 3);
            this.MainGrid.Children.Add(cmdPanel);

        }


    }
}
