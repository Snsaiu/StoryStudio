using IPanelContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPluginManager
{
    public interface IPluginManager
    {
        void InstallPlugin();
        bool UninstallPlugin();
        void InstallPlugin(IPanelContainer.IPanelContainer panelContainer);
    }
}
