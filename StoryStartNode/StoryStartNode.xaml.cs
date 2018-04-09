using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NodeBase;

namespace StoryStartNode
{
    /// <summary>
    /// Interaction logic for StoryStartNode.xaml
    /// </summary>
    public partial class StoryStartNode : UserControl, INodeBase
    {
        public StoryStartNode()
        {
            InitializeComponent();
        }

        public IEnumerable<INodeBase> Next { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// 设置节点的位置，获得节点的当前位置
        /// </summary>
        public Point Position
        {
            set { Canvas.SetLeft(this, value.X);
                     Canvas.SetTop(this, value.Y);}

            get { return Position; }
        }

        public bool CaptureMe()
        {
            return this.CaptureMouse();
        }

        public void DataChanged()
        {
            throw new NotImplementedException();
        }

        public void ReleaseMe()
        {
            this.ReleaseMouseCapture();
        }

        public void UpdateData(INodeBase node)
        {
            throw new NotImplementedException();
        }

    }
}
