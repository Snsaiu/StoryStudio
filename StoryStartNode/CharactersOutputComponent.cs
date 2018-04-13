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

        public override string Type => "input";

        protected override bool SetAttributes()
        {
            try
            {
                this.AddStringAttr("ccname", "角色姓名", "", false);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
