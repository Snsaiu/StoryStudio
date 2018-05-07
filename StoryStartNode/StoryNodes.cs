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
        private List<NodeBase.NodeBase> nodelist = null;

        public StoryNodes()
        {
            this.nodelist = new List<NodeBase.NodeBase>();
        }
        public List<NodeBase.NodeBase> Draw()
        {
            this.nodelist.Add(new StoryStartNode());
            this.nodelist.Add(new CharacterNode());
            //todo:以后新增加的node都在这里添加

            return this.nodelist;
            
        }
    }
}
