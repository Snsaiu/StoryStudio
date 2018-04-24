using MefExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SStoolbarItem
{
    [ExportToolBarPlugin(PluginType = "SStoolbarItem")]
    public class DefaultToolBarSets : IFillToolBar.IFillToolBar
    {
        public bool Draw(ToolBar toolBar)
        {
            try
            {

                toolBar.Items.Add(new New());
                toolBar.Items.Add(new Open());
                toolBar.Items.Add(new Save());
                toolBar.Items.Add(new SaveAs());
                toolBar.Items.Add(new Undo());

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
