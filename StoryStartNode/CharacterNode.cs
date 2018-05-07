﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodeBase;
using NodeComponentSets;

namespace StoryStartNode
{
    public class CharacterNode : NodeBase.NodeBase
    {
        public override string NodeLable =>"角色";

        public override string ShortTag => "CC";

        public override string LongTag => "CharacterNode";

        public override NodeBase.NodeBase CreateSelf()
        {
            CharacterNode node = new CharacterNode();
            return node;
        }

        protected override List<InputComponent> AddInputComponent()
        {
            //角色节点没有输入端
            return null;
        }

        protected override List<OutputComponent> AddOutputComponent()
        {
            List<OutputComponent> temp = new List<OutputComponent>();
            temp.Add(new CharactersOutputComponent());
            return temp;
        }
    }
}
