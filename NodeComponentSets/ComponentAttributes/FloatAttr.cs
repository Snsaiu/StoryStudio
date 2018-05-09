using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeBase
{
  public class FloatAttr
    {
        /// <summary>
        /// 唯一标识名
        /// </summary>
        public string Name { get; set; }
  
        /// <summary>
        /// 属性显示名
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 属性默认值
        /// </summary>
        public float DefaultValue { get; set; }

        /// <summary>
        /// 属性是否要显示在Node面板中
        /// </summary>
        public bool DisplayOnNode { get; set; }
    }
}
