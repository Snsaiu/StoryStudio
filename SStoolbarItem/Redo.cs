﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using MefExport;
using SSButtonBase;

namespace SStoolbarItem
{

    public class Redo : SSButtonBase.SSButtonBase
    {
        protected override object DisplayLabel()
        {
            return "重做";
        }

        protected override void DoubleClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void OnceClick(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
