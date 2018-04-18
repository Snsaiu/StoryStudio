using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSLine
{
    /// <summary>
    /// 创建节点之间的连线的抽象类
    /// </summary>
    public abstract class SSLineFactoryAbs
    {
        /// <summary>
        /// 创建角色节点之间的线样式
        /// </summary>
        /// <returns></returns>
        public abstract ArrowLineWithText CreateCharacterLine();

        /// <summary>
        /// 创建事件节点之间的线样式
        /// </summary>
        /// <returns></returns>
        public abstract ArrowLineWithText CreateEventLine();

 
    }
}
