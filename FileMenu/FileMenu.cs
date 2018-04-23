using DisplayLabelEnum;
using MefExport;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FileMenu
{
    /// <summary>
    /// register filemenu 
    /// </summary>
    [ExportMenuPlugin(PluginType ="FileMenu")]
    public class FileMenu : IFillMenuUI.IFillMenuUI
    {
        public bool Draw(Menu parentMenu)
        {
            try
            {
          
                MenuItem fileMenu = new MenuItem();
             
                fileMenu.Header = MenuDisplayLabel.文件;
                parentMenu.Items.Add(fileMenu);
                // add children menus

                // add 'new item'

                SSMenuItem.SSMenuItem newMenu = new NewMenuItem();
                fileMenu.Items.Add(newMenu);

                //add 'open ' item

                SSMenuItem.SSMenuItem openMenu = new OpenMenuItem();
                fileMenu.Items.Add(openMenu);

                // add 'save' item

                SSMenuItem.SSMenuItem saveMenu = new SaveMenuItem();
                fileMenu.Items.Add(saveMenu);

                // add 'save as' item
                SSMenuItem.SSMenuItem saveasMenu = new SaveAsMenuItem();
                fileMenu.Items.Add(saveasMenu);

                // add 'exit' item

                SSMenuItem.SSMenuItem exitMenu = new ExitMenuItem();          
                fileMenu.Items.Add(exitMenu);


                // add to panel
          
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("load file menu error");
                return false;
            }
        }
    }
}
