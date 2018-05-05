using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodeBase;
using NodeComponentSets;

namespace StoryStartNode
{
    public class StoryStartNode : NodeBase.NodeBase
    {

        public override string ShortTag => "SS";

        public override string LongTag =>"StoryStartNode";

        public override string NodeLable => "起始";

        public override NodeBase.NodeBase CreateSelf()
        {
            StoryStartNode s = new StoryStartNode();
            return s;
        }

        protected override List<InputComponent> AddInputComponent()
        {
            List<InputComponent> temp = new List<InputComponent>();
            temp.Add(new CharactersInputComponent());
            return temp;
        }

        protected override List<OutputComponent> AddOutputComponent()
        {
            List<OutputComponent> temp = new List<OutputComponent>();
            temp.Add(new CharactersOutputComponent());
            return temp;
        }
    }
}
