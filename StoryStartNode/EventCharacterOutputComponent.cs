using BaseTypeEnum;
using NodeBase;
using System;
using System.Collections.Generic;

namespace StoryStartNode
{
    /// <summary>
    /// 事件 角色输出组件
    /// </summary>
    public class EventCharacterOutputComponent : OutputComponent
    {
        public EventCharacterOutputComponent(NodeBase.NodeBase node) : base(node)
        {
        }

        public override string Label => "角色";

        public override string ShortName => "SCCO";

        public override string LongName => "StartCharacterOuput";

        public override NodeType Type => NodeType.characterType;

        public override IOTypeEnum IOType => IOTypeEnum.output;

        public override void Process(NodeComponentBase component)
        {
            Console.WriteLine(component.GetStringAttrSet());
        }

        protected override bool SetAttributes()
        {
            try
            {
                this.AddMultiSelectAttr("ccoutputlist", "输出角色", new List<string>(), null, true);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
