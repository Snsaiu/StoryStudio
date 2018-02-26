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
    [ExportMenuPlugin(PluginType = "FileMenu")]
    public class WindowMenu : IFillMenuUI.IFillMenuUI
    {
        public bool Draw(StackPanel parent, IUsableData.IUsableData data)
        {
            try
            {
                Menu menuContainer = new Menu();
                MenuItem windowMenu = new MenuItem();
                windowMenu.Header = "Window";
                menuContainer.Items.Add(windowMenu);

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
                parent.Children.Add(menuContainer);

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
