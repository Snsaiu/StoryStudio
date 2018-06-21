using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodeBase;

namespace StoryStartNode
{
    /// <summary>
    /// 发展节点
    /// </summary>
    public class StoryDevelopmentNode : NodeBase.NodeBase
    {
        public override string NodeLable => "发展";

        public override string ShortTag => "SD";

        public override string LongTag =>"StoryDevelopmentNode";

        public override NodeBase.NodeBase CreateSelf()
        {
            StoryDevelopmentNode _s = new StoryDevelopmentNode();
            return _s;
        }

        protected override List<InputComponent> AddInputComponent()
        {
            List<InputComponent> temp = new List<InputComponent>();
            temp.Add(new CharactersInputComponent(this));
            temp.Add(new EventEventInputComponent(this));
            return temp;
        }

        protected override List<OutputComponent> AddOutputComponent()
        {
            List<OutputComponent> temp = new List<OutputComponent>();
            temp.Add(new EventCharacterOutputComponent(this));
            temp.Add(new EventEventOutputComponent(this));
            return temp;
        }
    }
}
