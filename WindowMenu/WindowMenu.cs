using DisplayLabelEnum;
using IFillMenuUI;
using IUsableData;
using MefExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WindowMenu
{
    [ExportMenuPlugin(PluginType = "WindowMenu")]
    public class WindowMenu : IFillMenuUI.IFillMenuUI
    {
        public bool Draw(Menu parentMenu)
        {
            try
            {
             
                MenuItem windowMenu = new MenuItem();
                windowMenu.Header = MenuDisplayLabel.窗口;
               
                // add children menus

                // add 'story board '
                SSMenuItem.SSMenuItem storyboardMenu = new StoryBoardMenuItem();
                windowMenu.Items.Add(storyboardMenu);


                // add 'Dope Sheet'

                SSMenuItem.SSMenuItem dopesheepMenu = new DopeSheetMenuItem();
                windowMenu.Items.Add(dopesheepMenu);

                // add 'story Editor'

                SSMenuItem.SSMenuItem storyeditorMenu = new StoryEditorMenuItem();
                windowMenu.Items.Add(storyeditorMenu);

                // add 'node Editor'

                SSMenuItem.SSMenuItem nodeediorMenu = new NodeEditorMenuItem();
                windowMenu.Items.Add(nodeediorMenu);

                // add 'outline '

                SSMenuItem.SSMenuItem outlineMenu = new OutLineMenuItem();
                windowMenu.Items.Add(outlineMenu);

                // add 'restore '

                SSMenuItem.SSMenuItem restoreMenu = new RestoreMenuItem();
                windowMenu.Items.Add(restoreMenu);

                parentMenu.Items.Add(windowMenu);
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("load window menu error");
                return false;
                
            }
        }
    }
}
