using NodeBase;
using NodeComponentSets;
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

        public override string ShortName => "CC";

        public override string LongName => "CharactersInputComponent";



        public override global::BaseTypeEnum.NodeType Type => BaseTypeEnum.NodeType.characterType;

        public override global::BaseTypeEnum.IOTypeEnum IOType => BaseTypeEnum.IOTypeEnum.input;

        public override void Process(NodeComponentBase component)
        {
            Console.WriteLine(component.GetStringAttrSet());
        }

        protected override bool SetAttributes()
        {
            try
            {
                this.AddMultiSelectAttr("ccinputlist", "输入角色", new List<string>() , null, true);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
