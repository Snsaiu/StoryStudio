using IFillPanelUI;
using IPanelContainer;
using IPluginManager;
using MefExport;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPanelContainer;
using GlobalTracker;

namespace PanelPluginManager
{
    public class PanelPluginManager : IPluginManager.IPluginManager
    {

       
        [ImportMany(typeof(IFillPanelUI.IFillPanelUI))]
        public IEnumerable<Lazy<IFillPanelUI.IFillPanelUI,PanelTypePlugin>> PanelPlugins { get; set; }

        public void InstallPlugin()
        {

            this.getCompose();
            foreach(var plugin in this.PanelPlugins)
            {
                GlobalTracker.GlobalTracker tracker = GlobalTracker.GlobalTracker.GetInstance();
                IPanelBase.IPanelBase p = plugin.Value.Draw() as IPanelBase.IPanelBase;
                tracker.AddPanelInstance(p);
            }

        }

        public void InstallPlugin(IPanelContainer.IPanelContainer panelContainer)
        {
            this.getCompose();
            foreach (var plugin in this.PanelPlugins)
            {
           panelContainer.AddNewPanel(plugin.Metadata.PluginType , plugin.Value.Draw());
            }
        }

        public bool UninstallPlugin()
        {
            throw new NotImplementedException();
        }

        private void getCompose()
        {
            var catalog = new DirectoryCatalog(@"..\..\SystemPlugins");
            CompositionContainer composition = new CompositionContainer(catalog);
            composition.ComposeParts(this);
        }
    }
}
