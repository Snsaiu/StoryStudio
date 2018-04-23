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

namespace HelpMenu
{
    [ExportMenuPlugin(PluginType = "HelpMenu")]
    public class HelpMenu : IFillMenuUI.IFillMenuUI
    {
        public bool Draw(Menu parentMenu)
        {
            try
            {
                MenuItem helpMenu = new MenuItem();
                helpMenu.Header = MenuDisplayLabel.帮助;

                // add children menu

                // add send feedback

                SSMenuItem.SSMenuItem sendfeedbackMenu = new SendFaceBackMenuItem();
                helpMenu.Items.Add(sendfeedbackMenu);

                // add technical support

                SSMenuItem.SSMenuItem technicalsupportMenu = new TechnicalSupportMenuItem();
                helpMenu.Items.Add(technicalsupportMenu);

                // about

                SSMenuItem.SSMenuItem aboutMenu = new AboutMenuItem();
                helpMenu.Items.Add(aboutMenu);

                parentMenu.Items.Add(helpMenu);
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("load help menu error");
                throw;
            }
        }
    }
}
