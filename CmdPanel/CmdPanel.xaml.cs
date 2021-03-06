﻿using GlobalTracker;
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

namespace CmdPanel
{
    /// <summary>
    /// Interaction logic for CmdPanel.xaml
    /// </summary>
    public partial class CmdPanel : UserControl, IPanelBase.IPanelBase, IJoinGlobalTracker.IJoinGlobalTracker
    {
        public CmdPanel()
        {
            InitializeComponent();
        }

        private bool _isactivity = false;

        public bool IsActivity { get => _isactivity; set => this._isactivity = value; }

        public string PanelLabel => "命令面板";

        public string ShortName => "CP";

        public string LongName => "CmdPanel";

        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public global::BaseTypeEnum.BaseTypeEnum BaseType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

    }
}
