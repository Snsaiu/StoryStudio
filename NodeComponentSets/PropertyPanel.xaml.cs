using System.Windows.Controls;

namespace NodeBase
{
    /// <summary>
    /// Interaction logic for EventPropertyPanel.xaml
    /// </summary>
    public partial class PropertyPanel : UserControl
    {
        public PropertyPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 解析节点并显示
        /// </summary>
        /// <param name="node"></param>
        public void ParseNode(NodeBase node)
        {
            if (node.GetInputComponents()!=null)
            {
                this.PropertyStack.Children.Clear();
                foreach (var inputitem in node.GetInputComponents())
                {
                    //InputComponent p = inputitem.Clone() as InputComponent;
                    //p.MyShell = node;
                    //this.PropertyStack.Children.Add(p);
                    ///字符串类型数据
                    if (inputitem.GetStringAttrSet()!=null)
                    {
                        foreach (var stringAttrItem in inputitem.GetStringAttrSet())
                        {
                            P_StringAttrUI stringAttrUI = new P_StringAttrUI(stringAttrItem);
                            stringAttrUI.StrUILabel = stringAttrItem.DisplayName;
                            stringAttrUI.StrUIContent = stringAttrItem.DefaultValue;
                            this.PropertyStack.Children.Add(stringAttrUI);
                        }
                    }
                    //bool类型数据

                    if (inputitem.GetBoolAttrSet()!=null)
                    {
                        foreach (var boolAttrItem in inputitem.GetBoolAttrSet())
                        {
                            P_BoolAttriUI boolAttrUI = new P_BoolAttriUI(boolAttrItem);
                            boolAttrUI.BoolUILabel = boolAttrItem.DisplayName;
                            boolAttrUI.BoolUIContent = boolAttrUI.BoolUIContent;
                            this.PropertyStack.Children.Add(boolAttrUI);
                        }
                    }

                    //单选列表类型数据
                    if (inputitem.GetListAttrSet()!=null)
                    {
                        foreach (var singlelistitem in inputitem.GetListAttrSet())
                        {
                            P_ListAttrUI listAttriUI = new P_ListAttrUI(singlelistitem);
                            listAttriUI.ListUILabel = singlelistitem.DisplayName;
                            listAttriUI.DefaultIndex = singlelistitem.DefaultIndex;
                            listAttriUI.ListUIContent = singlelistitem.Value;
                            this.PropertyStack.Children.Add(listAttriUI);
                        }
                    }

                    // 多选列表类型数据
                    if (inputitem.GetMulitSelectAttrSet()!=null)
                    {
                        foreach (var mulAttr in inputitem.GetMulitSelectAttrSet())
                        {
                            P_MulitSelectAttrUI mulAttriUI = new P_MulitSelectAttrUI(mulAttr);
                            mulAttriUI.MultiSelectUILabel = mulAttr.DisplayName;
                            mulAttriUI.MulitListUIContent = mulAttr.Value;
                            mulAttriUI.DefaultIndexs = mulAttr.DefaultItems;
                            this.PropertyStack.Children.Add(mulAttriUI);
                        }
                    }

                    // int类型的数据
                    if (inputitem.GetIntAttrSet()!=null)
                    {
                        foreach (var intAttr in inputitem.GetIntAttrSet())
                        {
                            p_IntAttrUI intattrui = new p_IntAttrUI(intAttr);
                            intattrui.IntUILabel = intAttr.DisplayName;
                            intattrui.IntUIContent = intAttr.DefaultValue.ToString();
                            this.PropertyStack.Children.Add(intattrui);

                        }
                    }

                    // float类型的数据
                    if (inputitem.GetFloatAttrSet()!=null)
                    {
                        foreach (var floatAttr in inputitem.GetFloatAttrSet())
                        {
                            P_FloatAttrUI floatAttrUI = new P_FloatAttrUI(floatAttr);
                            floatAttrUI.FloatUILabel = floatAttr.DisplayName;
                            floatAttrUI.FloatUIContent = floatAttr.DefaultValue.ToString();
                            this.PropertyStack.Children.Add(floatAttrUI);
                        }
                    }



                }
            }
            if (node.GetOutputComponents()!=null)
            {
                this.PropertyStack.Children.Clear();
                //foreach (var outputitem in node.GetOutputComponents())
                //{
                //    OutputComponent p = outputitem.Clone() as OutputComponent;
                //    p.MyShell = node;
                //    this.PropertyStack.Children.Add(p);
                //}

                foreach (var outputitem in node.GetOutputComponents())
                {
                    //InputComponent p = inputitem.Clone() as InputComponent;
                    //p.MyShell = node;
                    //this.PropertyStack.Children.Add(p);

                    //布尔类型数据

                    if (outputitem.GetBoolAttrSet()!=null)
                    {
                        foreach (var boolAttr in outputitem.GetBoolAttrSet())
                        {
                            P_BoolAttriUI p_BoolAttriUI = new P_BoolAttriUI(boolAttr);
                            p_BoolAttriUI.BoolUILabel = boolAttr.DisplayName;
                            p_BoolAttriUI.BoolUIContent = boolAttr.DefaultValue;
                            this.PropertyStack.Children.Add(p_BoolAttriUI);

                        }
                    }

                    //字符串类型数据
                    if (outputitem.GetStringAttrSet() != null)
                    {
                        foreach (var stringAttrItem in outputitem.GetStringAttrSet())
                        {
                            P_StringAttrUI stringAttrUI = new P_StringAttrUI(stringAttrItem);
                            stringAttrUI.StrUILabel = stringAttrItem.DisplayName;
                            stringAttrUI.StrUIContent = stringAttrItem.DefaultValue;
                            this.PropertyStack.Children.Add(stringAttrUI);
                        }
                    }

                    //int 类型数据
                    if (outputitem.GetIntAttrSet()!=null)
                    {
                        foreach (var intAttrItem in outputitem.GetIntAttrSet())
                        {
                            p_IntAttrUI p_IntAttrUI = new p_IntAttrUI(intAttrItem);
                            p_IntAttrUI.IntUILabel = intAttrItem.DisplayName;
                            p_IntAttrUI.IntUIContent = intAttrItem.DefaultValue.ToString();
                            this.PropertyStack.Children.Add(p_IntAttrUI);

                        }
                    }


                    //float类型数据
                    if (outputitem.GetFloatAttrSet()!=null)
                    {
                        foreach (var floatAttrItem in outputitem.GetFloatAttrSet())
                        {
                            P_FloatAttrUI p_FloatAttrUI = new P_FloatAttrUI(floatAttrItem);
                            p_FloatAttrUI.FloatUILabel = floatAttrItem.DisplayName;
                            p_FloatAttrUI.FloatUIContent = floatAttrItem.DefaultValue.ToString();
                            this.PropertyStack.Children.Add(p_FloatAttrUI);
                        }
                    }

                    //列表数据类型
                    if (outputitem.GetListAttrSet()!=null)
                    {
                        foreach (var listAttrItem in outputitem.GetListAttrSet())
                        {
                            P_ListAttrUI p_ListAttrUI = new P_ListAttrUI(listAttrItem);
                            p_ListAttrUI.ListUILabel = listAttrItem.DisplayName;
                            p_ListAttrUI.ListUIContent = listAttrItem.Value;
                            p_ListAttrUI.DefaultIndex = listAttrItem.DefaultIndex;
                            this.PropertyStack.Children.Add(p_ListAttrUI);
                        }
                    }

                    //多选列表数据
                    if (outputitem.GetMulitSelectAttrSet()!=null)
                    {
                        foreach (var multiAttriItem in outputitem.GetMulitSelectAttrSet())
                        {
                            P_MulitSelectAttrUI p_MulitSelectAttrUI = new P_MulitSelectAttrUI(multiAttriItem);
                            p_MulitSelectAttrUI.MultiSelectUILabel = multiAttriItem.DisplayName;
                            p_MulitSelectAttrUI.MulitListUIContent = multiAttriItem.Value;
                            p_MulitSelectAttrUI.DefaultIndexs = multiAttriItem.DefaultItems;
                            this.PropertyStack.Children.Add(p_MulitSelectAttrUI);

                        }
                    }

                  
                    
                }
            }

        }


    }
}
