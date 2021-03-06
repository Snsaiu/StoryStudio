﻿using System;
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

namespace NodeBase
{
    /// <summary>
    /// Interaction logic for P_BoolAttriUI.xaml
    /// </summary>
    public partial class P_BoolAttriUI : UserControl
    {

        private BoolAttr _attr = null;
        public P_BoolAttriUI(BoolAttr boolAttr)
        {
            InitializeComponent();

            this._attr = boolAttr;
        
            this.BoolContent.Click += BoolContent_Click;
        }

        private void BoolContent_Click(object sender, RoutedEventArgs e)
        {
            this._attr.UpdateUiContent(this.BoolUIContent);
        }

        /// <summary>
        /// 设置或者获得属性ui是否可用
        /// </summary>
        public bool CanEdit { get => this.BoolContent.IsEnabled; set => this.BoolContent.IsEnabled = value; }
        /// <summary>
        /// 设置或者获得bool组件Ui的显示标签
        /// </summary>
        public string BoolUILabel { get => this.BoolLabel.Text; set => this.BoolLabel.Text = value; }

        /// <summary>
        /// 设置或者获得bool组件ui的显示内容
        /// </summary>
        public bool? BoolUIContent { get => this.BoolContent.IsChecked; set => this.BoolContent.IsChecked = value; }
    }
}
