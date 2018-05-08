using BaseTypeEnum;
using NodeComponentSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryStartNode
{
    public class EventCharacterOutputComponent : OutputComponent
    {
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
