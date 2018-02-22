using IFillMenuUI;
using IUsableData;
using MefExport;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EditMenu
{
    [ExportMenuPlugin(PluginType ="EditMenu")]
    public class EditMenu : IFillMenuUI.IFillMenuUI
    {
        public bool Draw(StackPanel parent, IUsableData.IUsableData data)
        {
            throw new NotImplementedException();
        }
    }
}
