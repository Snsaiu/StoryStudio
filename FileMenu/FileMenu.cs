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
             
                fileMenu.Header = "_File";
                parentMenu.Items.Add(fileMenu);
                // add children menus

                // add 'new item'

                MenuItem newMenu = new MenuItem();
                newMenu.Header = "_New";
                newMenu.Background= new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF28292A"));
                newMenu.Foreground = Brushes.White;
                fileMenu.Items.Add(newMenu);

                //add 'open ' item

                MenuItem openMenu = new MenuItem();
                openMenu.Header = "_Open";
                fileMenu.Items.Add(openMenu);

                // add 'save' item

                MenuItem saveMenu = new MenuItem();
                saveMenu.Header = "_Save";
                fileMenu.Items.Add(saveMenu);

                // add 'save as' item
                MenuItem saveasMenu = new MenuItem();
                saveasMenu.Header = "Save as";
                fileMenu.Items.Add(saveasMenu);

                // add 'exit' item

                MenuItem exitMenu = new MenuItem();
                exitMenu.Header = "_Exit";


              
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
