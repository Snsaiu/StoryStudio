using IFillMenuUI;
using IUsableData;
using MefExport;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EditMenu
{
    [ExportMenuPlugin(PluginType ="EditMenu")]
    public class EditMenu : IFillMenuUI.IFillMenuUI
    {
        public bool Draw(StackPanel parent, IUsableData.IUsableData data)
        {
            try
            {
                Menu menuContainer = new Menu();
                MenuItem editMenu = new MenuItem();
                editMenu.Header = "Edit";
                menuContainer.Items.Add(editMenu);
                // add children menus
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("load edit menu error");
                return false;

            }
        }
    }
}
