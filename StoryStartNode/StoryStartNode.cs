﻿using System.Collections.Generic;
using NodeBase;

namespace StoryStartNode
{
    public class StoryStartNode : NodeBase.NodeBase
    {

        public override string ShortTag => "SS";

        public override string LongTag =>"StoryStartNode";

        public override string NodeLable => "序幕";

        public override NodeBase.NodeBase CreateSelf()
        {
            StoryStartNode s = new StoryStartNode();
            return s;
        }

        public override void Process()
        {

            //两个都要判断，因为数据需要传到必须要有两个端点

            if (this.GetInputComponents()!=null && this.GetOutputComponents()!=null)
            {
                foreach (var item in this.GetInputComponents())
                {
                    if (item.ShortName=="CC")
                    {
                        foreach (var attr in item.GetMulitSelectAttrSet())
                        {
                            if (attr.Name== "ccinputlist")
                            {
                                System.Console.WriteLine(attr.DefaultItems);
                            }
                        } 
                    }

                }
            }
        }

        protected override List<InputComponent> AddInputComponent()
        {
            List<InputComponent> temp = new List<InputComponent>();
            temp.Add(new CharactersInputComponent(this));
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
