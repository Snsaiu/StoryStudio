using IPanelBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IPanelContainer
{
    public interface IPanelContainer
    {
        void ActivityPanel(string PanelName);
        UIElement GetActivityPanel();
        List<UIElement> GetChildren();
        bool AddNewPanel(string PanelName, UIElement panel);
    }
}
