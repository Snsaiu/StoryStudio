using NodeListPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DefaultPanelSets
{
    [MefExport.ExportPanelPlugin(PluginType = "NodeList")]
    public class DefaultNodeList : IFillPanelUI.IFillPanelUI
    {
        public UIElement Draw()
        {
            NodeListPanel.NodeListPanel nodeListPanel = new NodeListPanel.NodeListPanel();
            return nodeListPanel;
        }
    }
}
