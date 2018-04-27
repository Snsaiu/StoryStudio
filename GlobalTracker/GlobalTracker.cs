using IPanelContainer;
using System.Collections.Generic;
using System.Windows;

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

        /// <summary>
        /// 存放所有容器面板
        /// </summary>
        private List<IPanelContainer.IPanelContainer> containerlist = null;
       

        private GlobalTracker()
        {
            this.panellist = new List<IPanelBase.IPanelBase>();
            this.containerlist = new List<IPanelContainer.IPanelContainer>();
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
        /// 根据容器面板的名称获得容器实例
        /// </summary>
        /// <param name="panelname">容器面板的名称</param>
        /// <returns>返回容器面板的实例如果存在，否则返回null</returns>
        public IPanelContainer.IPanelContainer GetContainerByPanelName(string panelname)
        {
            foreach (var item in this.containerlist)
            {
                if (item.PanelName==panelname)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// 添加新的容器面板
        /// </summary>
        /// <param name="container">容器面板实例</param>
        public void AddContanierInstance(IPanelContainer.IPanelContainer container)
        {
            this.containerlist.Add(container);
        }

        /// <summary>
        /// 根据容器面板名称移除容器面板
        /// </summary>
        /// <param name="panelName">容器面板名称</param>
        /// <returns>移除成功返回true，否则返回false</returns>
        public bool RemoveContainerInstanceByPanelName(string panelName)
        {
            foreach (var item in this.containerlist)
            {
                if (item.PanelName == panelName)
                {
                    this.containerlist.Remove(item);
                    return true;
                }

            }
            return false;
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

        /// <summary>
        /// 获得所有的容器面板实例
        /// </summary>
        /// <returns>返回容器的列表</returns>
        public List<IPanelContainer.IPanelContainer> GetContainers()
        {
            if (this.containerlist!=null)
            {
                return this.containerlist;
            }
            return null;
        }

        /// <summary>
        /// 获得所有的面板实例
        /// </summary>
        /// <returns>返回面板列表实例如果列表有值，否则返回Null</returns>
        public List<IPanelBase.IPanelBase> GetPanels()
        {
            if (this.panellist.Count==0)
            {
                return null;
            }
            return this.panellist;

        }

        private Window _window = null;

        /// <summary>
        /// 获得主窗口
        /// </summary>
        /// <returns></returns>
        public Window GetWindow()
        {
            return this._window;
        }

        /// <summary>
        /// 设置主窗口
        /// </summary>
        /// <param name="window"></param>
        public void SetWindow(Window window)
        {
            this._window = window;
        }


    }
}
