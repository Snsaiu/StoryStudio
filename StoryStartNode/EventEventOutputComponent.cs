using BaseTypeEnum;
using NodeBase;
using System;

namespace StoryStartNode
{
    class EventEventOutputComponent : OutputComponent
    {
        /// <summary>
        /// 事件输出组件
        /// </summary>
        /// <param name="node"></param>
        public EventEventOutputComponent(NodeBase.NodeBase node) : base(node)
        {
        }

        public override string Label => "输出事件";

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
                this.AddStringAttr("eventoutputsummary", "事件摘要", "", false, true);
                this.AddStringAttr("eventoutputdescription", "事件描述", "", true, true);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
