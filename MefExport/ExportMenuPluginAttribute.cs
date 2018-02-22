using IFillMenuUI;
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
    public class ExportMenuPluginAttribute:ExportAttribute
    {
        public ExportMenuPluginAttribute():base(typeof(IFillMenuUI.IFillMenuUI))
        {

        }
        public string PluginType { get; set; }
    }
}
