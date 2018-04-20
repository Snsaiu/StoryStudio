using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using MefExport;
namespace SStoolbarItem
{
    [ExportToolBarPlugin(PluginType = "SStoolbarItem")]
    public class Redo : IFillToolBar.IFillToolBar
    {
      
        public bool Draw(ToolBar toolBar)
        {
            try
            {
                Button redobtn = new Button();
                redobtn.Content = "redo";
                redobtn.Foreground = Brushes.White;
                toolBar.Items.Add(redobtn);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }
    }
}
