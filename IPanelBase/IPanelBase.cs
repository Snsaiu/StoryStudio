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
        string PanelLabel { get; set; }
        void SetPanelFloat(UIElement parent);
        void SetPanelNoFloat(UIElement parent);

 
    }
}
