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
                nodeMenu.Header = MenuDisplayLabel.节点;
                parentMenu.Items.Add(nodeMenu);

                // add storystart
                SSMenuItem.SSMenuItem storystartNode = new PreludeMenuItem();
                nodeMenu.Items.Add(storystartNode);

                // add minorplot

                SSMenuItem.SSMenuItem minorplotNode = new DevelopMenuItem();
                nodeMenu.Items.Add(minorplotNode);

                // add mainplot

                SSMenuItem.SSMenuItem mainplotNode = new ClimaxMenuItem();
                nodeMenu.Items.Add(mainplotNode);

                SSMenuItem.SSMenuItem endingNode = new EndingMenuItem();
                nodeMenu.Items.Add(endingNode);

                // add character

                SSMenuItem.SSMenuItem characterNode = new CharacterMenuItem();
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
