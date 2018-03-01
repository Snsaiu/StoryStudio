using IFillPanelUI;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MefExport
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class,AllowMultiple =false)]
    public class ExportPanelPluginAttribute:ExportAttribute
    {
        public ExportPanelPluginAttribute():base(typeof(IFillPanelUI.IFillPanelUI))
        {

        }
        public string PluginType { get; set; }
    }
}
