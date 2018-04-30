using BaseTypeEnum;
using NodeBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryStartNode
{
    public class CharactersOutputComponent : OutputComponent
    {
        public override string Label => "角色";

        public override string ShortName => "COC";

        public override string LongName => "CharactersOutputComponent";

      

        public override NodeType Type =>NodeType.characterType;

        public override IOTypeEnum IOType => IOTypeEnum.output;

        protected override bool SetAttributes()
        {
            try
            {
                this.AddStringAttr("ccoutputname", "角色姓名", "", false,true);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
