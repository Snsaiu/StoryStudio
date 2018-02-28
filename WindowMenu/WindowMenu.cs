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
                windowMenu.Header = "_Window";
               
                // add children menus

                // add 'story board '
                MenuItem storyboardMenu = new MenuItem();
                storyboardMenu.Header = "_Stroy Board";
                windowMenu.Items.Add(storyboardMenu);


                // add 'Dope Sheet'

                MenuItem dopesheepMenu = new MenuItem();
                dopesheepMenu.Header = "_Dope Sheet";
                windowMenu.Items.Add(dopesheepMenu);

                // add 'story Editor'

                MenuItem storyeditorMenu = new MenuItem();
                storyeditorMenu.Header = "_Story Editor";
                windowMenu.Items.Add(storyeditorMenu);

                // add 'node Editor'

                MenuItem nodeediorMenu = new MenuItem();
                nodeediorMenu.Header = "_Node Editor";
                windowMenu.Items.Add(nodeediorMenu);

                // add 'outline '

                MenuItem outlineMenu = new MenuItem();
                outlineMenu.Header = "_OutLine";
                windowMenu.Items.Add(outlineMenu);

                // add 'restore '

                MenuItem restoreMenu = new MenuItem();
                restoreMenu.Header = "_Restore";
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
