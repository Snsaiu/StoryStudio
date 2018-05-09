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
    /// Interaction logic for ListAttrUI.xaml
    /// </summary>
    public partial class ListAttrUI : UserControl
    {
        public ListAttrUI(NodeComponentBase Component)
        {
            InitializeComponent();
            this.ListContent.SelectionChanged += (s, e) => { Component.NotifyUpdate(); };
        }

        /// <summary>
        /// 设置或者获得整型组件Ui的显示标签
        /// </summary>
        public string ListUILabel { get => this.ListLabel.Text; set => this.ListLabel.Text = value; }

        /// <summary>
        /// 设置或者获得单选列表
        /// </summary>
        public List<string> ListUIContent { get=>this.ListContent.ItemsSource as List<string>; set=>this.ListContent.ItemsSource=value; }

        /// <summary>
        /// 设置或者获得单选列表所选的索引号
        /// </summary>
        public int DefaultIndex { get => this.ListContent.SelectedIndex;set=>this.ListContent.SelectedIndex = value; }

        
    }
}
