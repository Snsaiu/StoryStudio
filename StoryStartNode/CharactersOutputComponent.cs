using BaseTypeEnum;
using NodeBase;
using System;
using System.Collections.Generic;

namespace StoryStartNode
{

    /// <summary>
    /// 角色输出组件
    /// </summary>
    public class CharactersOutputComponent : OutputComponent
    {
        public CharactersOutputComponent(NodeBase.NodeBase node) : base(node)
        {
        }

        public override string Label => "角色";

        public override string ShortName => "COC";

        public override string LongName => "CharactersOutputComponent";

      

        public override NodeType Type =>NodeType.characterType;

        public override IOTypeEnum IOType => IOTypeEnum.output;

        /// <summary>
        /// 因为是角色节点，没有输入，所以不要处理
        /// </summary>
        /// <param name="component"></param>
        public override void Process(NodeComponentBase component)
        {
            return;
        }

        protected override bool SetAttributes()
        {
            try
            {
                this.AddStringAttr("ccname", "姓名", "", false, true);
                this.AddIntAttr("ccage", "年龄", 18, true);
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
