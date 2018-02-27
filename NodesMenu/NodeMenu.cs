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

namespace NodesMenu
{
    [ExportMenuPlugin(PluginType = "NodeMenu")]
    public class NodeMenu : IFillMenuUI.IFillMenuUI
    {
        public bool Draw(Menu parentMenu)
        {
            try
            {
                MenuItem nodeMenu = new MenuItem();
                nodeMenu.Header = "Nodes";
                parentMenu.Items.Add(nodeMenu);

                // add storystart
                MenuItem storystartNode = new MenuItem();
                storystartNode.Header = "_Story Start Node";
                nodeMenu.Items.Add(storystartNode);

                // add mainplot

                MenuItem mainplotNode = new MenuItem();
                mainplotNode.Header = "_Main Plot Node";
                nodeMenu.Items.Add(mainplotNode);

                // add minorplot

                MenuItem minorplotNode = new MenuItem();
                minorplotNode.Header = "_Minor Plot Node";
                nodeMenu.Items.Add(minorplotNode);

                // add character

                MenuItem characterNode = new MenuItem();
                characterNode.Header = "_Character Node";
                nodeMenu.Items.Add(characterNode);


                
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
