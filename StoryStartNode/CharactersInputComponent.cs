using NodeBase;
using System;
using System.Collections.Generic;

namespace StoryStartNode
{
    public class CharactersInputComponent : InputComponent
    {
        public CharactersInputComponent(NodeBase.NodeBase node) : base(node)
        {
        }

        public override string Label => "角色";

        public override string ShortName => "CC";

        public override string LongName => "CharactersInputComponent";

       

        public override global::BaseTypeEnum.NodeType Type => BaseTypeEnum.NodeType.characterType;

        public override global::BaseTypeEnum.IOTypeEnum IOType => BaseTypeEnum.IOTypeEnum.input;

        public override void Process(NodeComponentBase component)
        {
            if (component!=null)
            {
                foreach (var item in component.GetStringAttrSet())
                {
                    if (item.Name== "ccname")
                    {
                        Console.WriteLine(item.AttrUI.StrUIContent);
                    }
                }  
            }
            
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
