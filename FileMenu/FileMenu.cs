﻿using IFillMenuUI;
using IUsableData;
using MefExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FileMenu
{
    [ExportMenuPlugin(PluginType ="FileMenu")]
    public class FileMenu : IFillMenuUI.IFillMenuUI
    {
        public bool Draw(StackPanel parent, IUsableData.IUsableData data)
        {
            throw new NotImplementedException();
        }
    }
}
