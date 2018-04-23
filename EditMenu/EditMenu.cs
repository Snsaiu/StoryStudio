using DisplayLabelEnum;
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
                editMenu.Header = MenuDisplayLabel.编辑;

                //  add children menus

                // add 'undo'

                SSMenuItem.SSMenuItem undoMenu = new UndoMenuItem();
                editMenu.Items.Add(undoMenu);

                // add "redo"

                SSMenuItem.SSMenuItem redoMenu = new RedoMenuItem();
                editMenu.Items.Add(redoMenu);

                // add 'delete'

                SSMenuItem.SSMenuItem deleteMenu = new DeleteMenuItem();
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
