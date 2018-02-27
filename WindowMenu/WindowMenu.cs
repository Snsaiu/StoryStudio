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
                windowMenu.Header = "Window";
               
                // add children menus

                // add 'story board '
                MenuItem storyboardMenu = new MenuItem();
                storyboardMenu.Header = "Stroy Studio";
                windowMenu.Items.Add(storyboardMenu);


                // add 'Dope Sheet'

                // add 'story Editor'

                // add 'node Edior'

                // add 'outline '

                // add 'restore '

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
