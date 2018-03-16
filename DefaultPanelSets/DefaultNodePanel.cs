using IFillPanelUI;
using MefExport;
using NodePanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DefaultPanelSets
{
    [ExportPanelPlugin(PluginType ="NodePanel")]
    public class DefaultNodePanel : IFillPanelUI.IFillPanelUI
    {
        public UIElement Draw()
        {
            NodePanel.NodePanel nodePanel = new NodePanel.NodePanel();
            return nodePanel ;

        }
    }
}
