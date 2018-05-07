using BaseTypeEnum;
using NodeComponentSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryStartNode
{
    class EventEventOutputComponent : OutputComponent
    {
        public override string Label => "事件";

        public override string ShortName => "SEO";

        public override string LongName => "StartEventOutput";

        public override NodeType Type => NodeType.eventType;

        public override IOTypeEnum IOType => IOTypeEnum.output;

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
