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
                helpMenu.Header = "_Help";

                // add children menu

                // add send feedback

                MenuItem sendfeedbackMenu = new MenuItem();
                sendfeedbackMenu.Header = "_Send Feedback";
                helpMenu.Items.Add(sendfeedbackMenu);

                // add technical support

                MenuItem technicalsupportMenu = new MenuItem();
                technicalsupportMenu.Header = "_Technical Support";
                helpMenu.Items.Add(technicalsupportMenu);

                // about

                MenuItem aboutMenu = new MenuItem();
                aboutMenu.Header = "_About";
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
