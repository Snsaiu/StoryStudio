using PorpertyContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DefaultPanelSets
{
    [MefExport.ExportPanelPlugin(PluginType = "PropertyPanel")]
    public class DefaultPropertyPanel : IFillPanelUI.IFillPanelUI
    {
        public UIElement Draw()
        {
            PropertyContainer propertyContainer = new PropertyContainer();
            return propertyContainer;
        }
    }
}
