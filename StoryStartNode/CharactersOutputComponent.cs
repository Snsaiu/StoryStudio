using BaseTypeEnum;
using NodeBase;
using NodeComponentSets;
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

        public override void Process(NodeComponentBase component)
        {
            Console.WriteLine(component.GetStringAttrSet());
        }

        protected override bool SetAttributes()
        {
            try
            {
                this.AddStringAttr("ccinputname", "姓名", "", false, true);
                this.AddIntAttr("ccinputage", "年龄", 18, true);
                this.AddFloatAttr("ccinputheight", "角色身高", 1.8f, true);
                this.AddBoolAttr("ccmain", "主角色彩", true, true);
                this.AddListAttr("ccsex", "性别", new List<string>() { "男", "女", "其他" }, 0, true);
                this.AddListAttr("cctypelist", "角色类型", new List<string>() { "二足", "四足", "植物" }, 0, true);
                this.AddStringAttr("ccdescription", "角色描述", "", true, true);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
