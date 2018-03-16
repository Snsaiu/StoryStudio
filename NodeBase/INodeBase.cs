using SSBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NodeBase
{
    public  interface INodeBase 
    {
         IEnumerable<INodeBase> Next { get; set; }
         Point Position { get; set; }
          void UpdateData(INodeBase node);
          void DataChanged();
        
    }
}
