using PorpertyContainer;
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
