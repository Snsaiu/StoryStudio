using SSBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace NodeBase
{
    public  interface INodeBase 
    {
         IEnumerable<INodeBase> Next { get; set; }
        /// <summary>
        /// 设置或获得当前node的位置
        /// </summary>
         Point Position { get; set; }
          void UpdateData(INodeBase node);
        /// <summary>
        /// 当node的数据发生变化时调用此函数
        /// </summary>
          void DataChanged();
        /// <summary>
        /// 使鼠标捕获到选中的node
        /// </summary>
        /// <returns></returns>
        bool CaptureMe();
        /// <summary>
        /// 使鼠标不在捕获到选中的node
        /// </summary>
        void ReleaseMe();
        /// <summary>
        /// node的短名
        /// </summary>
        string ShortTag { get;  }
        /// <summary>
        /// node的全名
        /// </summary>
        string LongTag { get; }
        
        
    }
}
