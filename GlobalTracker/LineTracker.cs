namespace GlobalTracker
{
    public static class LineTracker
    {
        private static object _storeLineObj;

        /// <summary>
        /// 设置或者获得当前需要链接的线
        /// </summary>
        public static object StoreLineObj
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
