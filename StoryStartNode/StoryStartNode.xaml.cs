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

      
        /// <summary>
        /// 设置节点的位置，获得节点的当前位置
        /// </summary>
        public Point Position
        {
            set { Canvas.SetLeft(this, value.X);
                     Canvas.SetTop(this, value.Y);}

            get { return Position; }
        }

        public string ShortTag { get => "SS";  }
        public string LongTag { get => "StoryStart";  }
        public IEnumerable<INodeBase> Next { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

        public void CreateSelf(Canvas canvas)
        {
            StoryStartNode temp = new StoryStartNode();
            canvas.Children.Add(temp);
            Random r = new Random();
            Canvas.SetLeft(temp,500+r.Next(50,100));
            Canvas.SetTop(temp, 300+r.Next(50,100));
        }


        public void UpdateData(StoryStartNode node)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(INodeBase node)
        {
            throw new NotImplementedException();
        }
    }
}
