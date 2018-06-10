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
                    if (inputitem.GetStringAttrSet()!=null)
                    {
                        foreach (var stringAttrItem in inputitem.GetStringAttrSet())
                        {
                            P_StringAttrUI stringAttrUI = new P_StringAttrUI(stringAttrItem);
                            stringAttrUI.StrUILabel = stringAttrItem.DisplayName;
                            stringAttrUI.StrUIContent = stringAttrItem.DefaultValue;
                            P_BoolAttriUI p_BoolAttri = new P_BoolAttriUI();
                            p_BoolAttri.BoolUILabel = "ddd";
                            p_BoolAttri.BoolUIContent = true;
                            this.PropertyStack.Children.Add(p_BoolAttri);
                            this.PropertyStack.Children.Add(stringAttrUI);
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
                    if (outputitem.GetStringAttrSet() != null)
                    {
                        foreach (var stringAttrItem in outputitem.GetStringAttrSet())
                        {
                            P_StringAttrUI stringAttrUI = new P_StringAttrUI(stringAttrItem);
                            stringAttrUI.StrUILabel = stringAttrItem.DisplayName;
                            stringAttrUI.StrUIContent = stringAttrItem.DefaultValue;
                            this.PropertyStack.Children.Add(stringAttrUI);
                        }

                        foreach (var intAttrItem in outputitem.GetIntAttrSet())
                        {
                            p_IntAttrUI p_IntAttrUI = new p_IntAttrUI(intAttrItem);
                            p_IntAttrUI.IntUILabel = intAttrItem.DisplayName;
                            p_IntAttrUI.IntUIContent = intAttrItem.DefaultValue.ToString();
                            this.PropertyStack.Children.Add(p_IntAttrUI);

                        }

                        foreach (var floatAttrItem in outputitem.GetFloatAttrSet())
                        {
                            P_FloatAttrUI p_FloatAttrUI = new P_FloatAttrUI(floatAttrItem);
                            p_FloatAttrUI.FloatUILabel = floatAttrItem.DisplayName;
                            p_FloatAttrUI.FloatUIContent = floatAttrItem.DefaultValue.ToString();
                            this.PropertyStack.Children.Add(p_FloatAttrUI);
                        }

                        foreach (var listAttrItem in outputitem.GetListAttrSet())
                        {
                            P_ListAttrUI p_ListAttrUI = new P_ListAttrUI(listAttrItem);
                            p_ListAttrUI.ListUILabel = listAttrItem.DisplayName;
                            p_ListAttrUI.ListUIContent = listAttrItem.Value;
                            p_ListAttrUI.DefaultIndex = listAttrItem.DefaultIndex;
                            this.PropertyStack.Children.Add(p_ListAttrUI);
                        }

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
