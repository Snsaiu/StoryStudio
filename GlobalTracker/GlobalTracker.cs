using IPanelBase;
using NodeBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTracker
{
    /// <summary>
    /// 全局唯一实例，用于存储程序运行中产生的对象，通过该对象可以获得到一些
    /// 有用的对象，
    /// </summary>
    public class GlobalTracker
    {
        private static GlobalTracker instance = null;

        /// <summary>
        ///存放所有面饭
        /// </summary>
        private List<IPanelBase.IPanelBase> panellist = null;

        private GlobalTracker()
        {
            this.panellist = new List<IPanelBase.IPanelBase>();
        }

        /// <summary>
        /// 获得globaltracker的实例
        /// </summary>
        /// <returns>返回globaltracker的实例</returns>
        public static GlobalTracker GetInstance()
        {
            if (instance==null)
            {
                instance = new GlobalTracker();

            }
            return instance;
        }

        /// <summary>
        /// 存储面板
        /// </summary>
        /// <param name="panel">需要存储的面板实例</param>
        public void AddPanelInstance(IPanelBase.IPanelBase panel)
        {

            this.panellist.Add(panel);
        }

        /// <summary>
        /// 根据面板的短命获得面板实例
        /// </summary>
        /// <param name="shortname">面板短名</param>
        /// <returns>返回面板实例如果存在，否则返回Null</returns>
        public IPanelBase.IPanelBase GetPanelByShorName(string shortname)
        {

            foreach (var item in this.panellist)
            {
                if (item.ShortName==shortname)
                {
                    return item;
                }

            }
            return null;

        }

        /// <summary>
        /// 根据面板的长命获得面板实例
        /// </summary>
        /// <param name="shortname">面板长名</param>
        /// <returns>返回面板实例如果存在，否则返回Null</returns>
        public IPanelBase.IPanelBase GetPanelByLongName(string longname)
        {
            foreach (var item in this.panellist)
            {
                if (item.LongName == longname)
                {
                    return item;
                }

            }
            return null;
        }

        /// <summary>
        /// 根据短名从globaltracker中移除面板实例
        /// </summary>
        /// <param name="shortname">需要移除的面板实例的短名</param>
        /// <returns>返回true如果移除成功，否则返回false</returns>
        public bool RemovePanelByShortName(string shortname)
        {
            foreach (var item in this.panellist)
            {
                if (item.ShortName == shortname)
                {
                    this.panellist.Remove(item);
                    return true;
                }

            }
            return false ;
        }

        /// <summary>
        /// 根据长名从globaltracker中移除面板实例
        /// </summary>
        /// <param name="shortname">需要移除的面板实例的长名</param>
        /// <returns>返回true如果移除成功，否则返回false</returns>
        public bool RemovePanelByLoneName(string longname)
        {
            foreach (var item in this.panellist)
            {
                if (item.LongName == longname)
                {
                    this.panellist.Remove(item);
                    return true;
                }

            }
            return false;
        }


    }
}
