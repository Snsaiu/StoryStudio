using BaseTypeEnum;
using NodeBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryStartNode
{
    /// <summary>
    /// 事件输入组件
    /// </summary>
    public class EventEventInputComponent : InputComponent
    {
        public EventEventInputComponent(NodeBase.NodeBase node) : base(node)
        {
        }

        public override string Label => "输入事件";

        public override string ShortName => "SEI";

        public override string LongName =>"StartEventInput";

        public override NodeType Type => NodeType.eventType;

        public override IOTypeEnum IOType => IOTypeEnum.input;

        public override void Process(NodeComponentBase component)
        {
          
        }

        protected override bool SetAttributes()
        {
            
            try
            {
                this.AddStringAttr("eventinputsummary", "事件摘要", "", false, true);
                this.AddStringAttr("eventinputsummary", "事件描述", "", true, true);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
