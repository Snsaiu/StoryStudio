using IFillMenuUI;
using IUsableData;
using MefExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NodesMenu
{
    [ExportMenuPlugin(PluginType = "FileMenu")]
    public class NodeMenu : IFillMenuUI.IFillMenuUI
    {
        public bool Draw(StackPanel parent, IUsableData.IUsableData data)
        {
            throw new NotImplementedException();
        }
    }
}
