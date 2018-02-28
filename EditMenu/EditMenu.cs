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
        public bool Draw(Menu parentMenu)
        {
            try
            {
          
                MenuItem editMenu = new MenuItem();
                editMenu.Header = "_Edit";

                //  add children menus

                // add 'undo'

                MenuItem undoMenu = new MenuItem();
                undoMenu.Header = "_Undo";
                editMenu.Items.Add(undoMenu);

                // add "redo"

                MenuItem redoMenu = new MenuItem();
                redoMenu.Header = "_Redo";
                editMenu.Items.Add(redoMenu);

                // add 'delete'

                MenuItem deleteMenu = new MenuItem();
                deleteMenu.Header = "_Delete";
                editMenu.Items.Add(deleteMenu);

                parentMenu.Items.Add(editMenu);


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
