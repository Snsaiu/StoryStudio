using SSBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace IPanelBase
{
    public interface IPanelBase:ISSBase
    {
        /// <summary>
        /// 面板名称
        /// </summary>
        string PanelLabel { get;}
        /// <summary>
        /// 设置面板浮动
        /// </summary>
        /// <param name="parent"></param>
        void SetPanelFloat(UIElement parent);
        /// <summary>
        /// 禁止面板浮动
        /// </summary>
        /// <param name="parent"></param>
        void SetPanelNoFloat(UIElement parent);
        /// <summary>
        /// 面板短名
        /// </summary>
        string ShortName { get; }
        /// <summary>
        /// 面板全名
        /// </summary>
        string LongName { get; }

        /// <summary>
        /// 设置当前面板是否是激活状态
        /// </summary>
        bool IsActivity { get; set; }


 
    }
}
