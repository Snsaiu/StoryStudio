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

        public override string ShortName => "CIC";

        public override string LongName => "CharactersInputComponent";



        public override global::BaseTypeEnum.NodeType Type => BaseTypeEnum.NodeType.characterType;

        public override global::BaseTypeEnum.IOTypeEnum IOType => BaseTypeEnum.IOTypeEnum.input;

        protected override bool SetAttributes()
        {
            try
            {
                this.AddStringAttr("ccinputname", "角色姓名", "", false,true);
                this.AddFloatAttr("ccinputheight", "角色身高", 1.8f, true);
                this.AddBoolAttr("ccbool", "bool类型", true, true);
                this.AddListAttr("cclist", "单选框", new List<string>() { "heloo", "fdhkfh", "fhjdhf" }, 2, true);
                this.AddMultiSelectAttr("ccmultilist", "多选", new List<string>() { "dfd", "fdfdfd", "ssss" }, new List<string>() { "dfd", "fdfdfd" }, true);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
