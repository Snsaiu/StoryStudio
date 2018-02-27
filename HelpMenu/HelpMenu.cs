using IFillMenuUI;
using IUsableData;
using MefExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HelpMenu
{
    [ExportMenuPlugin(PluginType = "FileMenu")]
    public class HelpMenu : IFillMenuUI.IFillMenuUI
    {
        public bool Draw(Menu parentMenu)
        {
            // todo;
            return true;
        }
    }
}
