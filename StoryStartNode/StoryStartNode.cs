using NodeBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryStartNode
{
    public class StoryStartNode : INodeBase
    {
        public IEnumerable<INodeBase> Next { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public System.Windows.Point Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void DataChanged()
        {
            throw new NotImplementedException();
        }

        public void UpdateData(INodeBase node)
        {
            throw new NotImplementedException();
        }
    }
}
