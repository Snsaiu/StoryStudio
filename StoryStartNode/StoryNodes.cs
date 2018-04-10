using IFillNode;
using MefExport;
using NodeBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryStartNode
{
    [ExportNodePlugin(PluginType = "storynode")]
    public class StoryNodes : IFillNode.IFillNode
    {
        private List<INodeBase> nodelist = null;

        public StoryNodes()
        {
            this.nodelist = new List<INodeBase>();
        }
        public List<INodeBase> Draw()
        {
            this.nodelist.Add(new StoryStartNode());

            //todo:以后新增加的node都在这里添加

            return this.nodelist;
            
        }
    }
}
