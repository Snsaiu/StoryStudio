using SSLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTracker
{
  public static class LineTracker
    {
        private static ArrowLineWithText _storeLineObj;

        /// <summary>
        /// 设置或者获得当前需要链接的线
        /// </summary>
        public static ArrowLineWithText StoreLineObj
        {
            get { return _storeLineObj; }
            set { _storeLineObj = value; }
        }

        private static bool _canCreateLine=true;

        /// <summary>
        /// 设置或者获得当前能否创建线
        /// </summary>
        public static bool CanCreateLine 
        {
            get { return _canCreateLine; }
            set { _canCreateLine = value; }
        }


    }
}
