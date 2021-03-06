﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for p_IntAttrUI.xaml
    /// </summary>
    public partial class p_IntAttrUI : UserControl
    {
        private IntAttr _intattr;
        public p_IntAttrUI(IntAttr intAttr)
        {
            InitializeComponent();

            this._intattr = intAttr;
            this.IntContent.TextChanged += (s, e) => {

                int _res = 0;
                if (int.TryParse(this.IntContent.Text,out _res))
                {
                    this._intattr.UpdateUiContent(_res);
                }


                 };
        }


        /// <summary>
        /// 设置或者获得属性ui是否可编辑
        /// </summary>
        public bool CanEdit { get => this.IntContent.IsEnabled; set => this.IntContent.IsEnabled = value; }

        /// <summary>
        /// 设置或者获得整型组件Ui的显示标签
        /// </summary>
        public string IntUILabel { get => this.IntLabel.Text; set => this.IntLabel.Text = value; }

        /// <summary>
        /// 设置或者获得整型组件ui的显示内容
        /// </summary>
        public string IntUIContent { get => this.IntContent.Text; set => this.IntContent.Text = value; }



        private void IntContent_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))

            {

                String text = (String)e.DataObject.GetData(typeof(String));

                if (ValidateIntValue(text))
                { e.CancelCommand(); }
            }
            else { e.CancelCommand(); }
        }

        private void IntContent_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = ValidateIntValue(e.Text);
        }

        private bool ValidateIntValue(string text)
        {
            string reg = "[^0-9-]+";
            Regex regex = new Regex(reg);
            bool result = regex.IsMatch(text);
            return result;
        }
    }
}
