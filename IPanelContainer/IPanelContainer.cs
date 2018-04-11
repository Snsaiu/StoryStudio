using System.Collections.Generic;
using System.Windows;

namespace IPanelContainer
{
    public delegate void NotifyUpdateDelegate();
    public interface IPanelContainer
    {

        event NotifyUpdateDelegate NotifyUpdateEvent;

        /// <summary>
        /// 根据面板名称激活容器内的面板
        /// </summary>
        /// <param name="PanelName">面板名称</param>
        /// <param name="replace">如果面板已打开的情况下是否进行替换，默认为true替换，建议true</param>
        void ActivityPanel(string PanelName, bool replace = true);

        /// <summary>
        /// 获得容器面板的名称
        /// </summary>
        string PanelName { get; }

        /// <summary>
        /// 获得当前激活的面板
        /// </summary>
        /// <returns>返回当前被激活的面板</returns>
        UIElement GetActivityPanel();

        /// <summary>
        /// 移除激活的面板
        /// </summary>
        void Unactivity();
    
        /// <summary>
        /// 获得容器内的所有面板
        /// </summary>
        /// <returns>返回容器内的面板</returns>
        List<UIElement> GetChildren();
        /// <summary>
        /// 添加一个新的面板
        /// </summary>
        /// <param name="PanelName">面板的名称</param>
        /// <param name="panel">面板实例</param>
        /// <returns>如果添加成功返回true，否则返回false</returns>
        bool AddNewPanel(string PanelName, UIElement panel);

        /// <summary>
        /// 根据面板名称移除容器内的指定面板实例
        /// </summary>
        /// <param name="panelName">面板名称</param>
        /// <returns>如果移除成功，返回true，否则返回false</returns>
        bool RemovePanel(string panelName);

        /// <summary>
        /// 尝试激活了一个面板以填充容器
        /// </summary>
        /// <returns>如果激活了，返回true,否则返回false</returns>
        bool TryActivityPanel();
    }
}
