using System.Windows;
using System.Windows.Controls;
using System;
using NodePanel;

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

            //add menu ui

            Menu.Menu menu = new Menu.Menu();
            menu.SetValue(Grid.RowProperty, 0);
            menu.SetValue(Grid.ColumnSpanProperty, 3);
       
            this.MainGrid.Children.Add(menu);

            // add node panel ui

            NodePanel.NodePanel nodePanel = new NodePanel.NodePanel();
            nodePanel.SetValue(Grid.RowProperty, 1);
            nodePanel.SetValue(Grid.ColumnProperty, 1);
            nodePanel.HorizontalAlignment = HorizontalAlignment.Stretch;
            nodePanel.VerticalAlignment = VerticalAlignment.Stretch;
            this.MainGrid.Children.Add(nodePanel);

            
        }


    }
}
