﻿using IFillNode;
using MefExport;
using NodeBase;
using System.Collections.Generic;


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
            this.nodelist.Add(new StoryDevelopmentNode());
            //todo:以后新增加的node都在这里添加

            return this.nodelist;
            
        }


    }
}
