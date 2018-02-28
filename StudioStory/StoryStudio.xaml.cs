using System.Windows;
using System.Windows.Controls;
using System;

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
            menu.SetValue(Grid.ColumnSpanProperty, 2);
            this.MainGrid.Children.Add(menu);


            // add node panel ui
        }


    }
}
