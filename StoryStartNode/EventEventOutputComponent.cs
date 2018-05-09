using BaseTypeEnum;
using NodeBase;
using System;

namespace StoryStartNode
{
    class EventEventOutputComponent : OutputComponent
    {
        public EventEventOutputComponent(NodeBase.NodeBase node) : base(node)
        {
        }

        public override string Label => "事件";

        public override string ShortName => "SEO";

        public override string LongName => "StartEventOutput";

        public override NodeType Type => NodeType.eventType;

        public override IOTypeEnum IOType => IOTypeEnum.output;

        public override void Process(NodeComponentBase component)
        {
            Console.WriteLine(component.GetStringAttrSet());
        }

        protected override bool SetAttributes()
        {
            try
            {
                this.AddStringAttr("starteventoutputsummary", "事件摘要", "", false, true);
                this.AddStringAttr("starteventoutputdescription", "事件描述", "", true, true);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
