﻿using BaseTypeEnum;
using GlobalTracker;
using IJoinGlobalTracker;
using MenuPluginManager;
using SSBase;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Menu
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl,IPanelBase.IPanelBase, IJoinGlobalTracker.IJoinGlobalTracker
    {

        public void Join()
        {
            GlobalTracker.GlobalTracker gt = GlobalTracker.GlobalTracker.GetInstance();
            gt.AddPanelInstance(this);
        }

        public bool Quit()
        {
            GlobalTracker.GlobalTracker gt = GlobalTracker.GlobalTracker.GetInstance();
            return gt.RemovePanelByShortName("SBP");
        }
        public bool IsActivity { get => IsActivity; set => IsActivity = value; }

        public Menu()
        {
            InitializeComponent();

            System.Windows.Controls.Menu MainMenu = new System.Windows.Controls.Menu();
            MainMenu.Background =new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF28292A"));
            MainMenu.Foreground = System.Windows.Media.Brushes.White;
            this.MenuStackPanel.Children.Add(MainMenu);
            // here load plugin
            MenuPluginManager.MenuPluginManager pluginManager = new MenuPluginManager.MenuPluginManager(MainMenu);
            pluginManager.InstallPlugin();

        }

        public string PanelLabel => "菜单";
        public int Id { get; set; }
        public BaseTypeEnum.BaseTypeEnum BaseType { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public string ShortName => "Menu";

        public string LongName => "Menu";

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
