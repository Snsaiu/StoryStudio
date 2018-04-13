using NodeBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryStartNode
{
    public class CharactersInputComponent : InputComponent
    {
        public override string Label => "角色";

        public override string ShortName => "CIC";

        public override string LongName => "CharactersInputComponent";

        public override string Type => "input";

        protected override bool SetAttributes()
        {
            try
            {
                this.AddStringAttr("ccinputname", "角色姓名", "", false,true);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
