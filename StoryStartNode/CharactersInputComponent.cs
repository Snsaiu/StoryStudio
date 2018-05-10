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

                List<string> _nameset = new List<string>();

                foreach (var item in component.GetStringAttrSet())
                {
                    //获取姓名
                    if (item.Name== "ccname")
                    {
                        _nameset.Add(item.DefaultValue);
                    }
                    // todo 添加新的内容
                }

                foreach (var item in this.GetMulitSelectAttrSet())
                {
                    if (item.Name== "ccinputlist")
                    {
                        List<string> orinameset = item.DefaultItems;

                        //初始化的时候可能没有赋初值，所以要进行判断
                        if (orinameset==null)
                        {
                            item.UpdateUiContent(_nameset);
                        }
                        else
                        {
                            orinameset.AddRange(_nameset);

                            item.UpdateUiContent(orinameset);
                        }

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
