using NodeBase;
using System;
using System.Collections.Generic;
using System.Windows;

namespace StoryStartNode
{
    /// <summary>
    /// 角色输入节点组件
    /// </summary>
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
            // 该组件是输入节点，可以获得上游组件

            List<string> _names = new List<string>();
       
            foreach (var item in this.MyNotifiers)
            {
                if (item.GetStringAttrSet()!=null)
                {
                    foreach (var data in item.GetStringAttrSet())
                    {
                        if (data.Name=="ccname")
                        {
                            _names.Add(data.DefaultValue);
                        }
                    }

                }

            }

            //

            if (this.GetMulitSelectAttrSet()!=null)
            {
                foreach (var item in this.GetMulitSelectAttrSet())
                {
                    if (item.Name== "ccinputlist")
                    {
                        item.UpdateList (_names);
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
