using IFillNode;
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
    public class ExportNodePluginAttribute:ExportAttribute
    {
        public ExportNodePluginAttribute():base(typeof(IFillNode.IFillNode))
        {

        }

        public string PluginType { get; set; }

    }
}
