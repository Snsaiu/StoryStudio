using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJoinGlobalTracker
{
    /// <summary>
    ///  将自己添加到joinglobaltracker中
    /// </summary>
    public interface IJoinGlobalTracker
    {
        /// <summary>
        /// 加入到globaltraker
        /// </summary>
        void Join();

        /// <summary>
        /// 从globaltracker中移除
        /// </summary>
        /// <returns>返回true如果移除成功，否则返回false</returns>
        bool Quit();
    }
}
