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
                foreach (var inputitem in node.GetInputComponents())
                {
                    InputComponent p = inputitem.Clone() as InputComponent;
                    p.MyShell = node;
                    this.PropertyStack.Children.Add(p);
                }
            }
            if (node.GetOutputComponents()!=null)
            {
                foreach (var outputitem in node.GetOutputComponents())
                {
                    OutputComponent p = outputitem.Clone() as OutputComponent;
                    p.MyShell = node;
                    this.PropertyStack.Children.Add(p);
                }
            }

        }


    }
}
