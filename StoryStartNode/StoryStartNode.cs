using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodeBase;

namespace StoryStartNode
{
    public class StoryStartNode : NodeBase.NodeBase
    {

        public override string ShortTag => "SS";

        public override string LongTag =>"StoryStartNode";

        public override NodeBase.NodeBase CreateSelf()
        {
            StoryStartNode s = new StoryStartNode();
            return s;
        }
    }
}
