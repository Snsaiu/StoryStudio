using IPluginManager;
using MefExport;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ToolBarPluginManager
{
    public class ToolBarPluginManager : IPluginManager.IPluginManager
    {
        [ImportMany(typeof(IFillToolBar.IFillToolBar))]
        public IEnumerable<Lazy<IFillToolBar.IFillToolBar, ToolBarTypePlugin>> ToolBarPlugins { get; set; }

        private ToolBar toolBar = null;
        public ToolBarPluginManager(ToolBar toolBar)
        {
            this.toolBar = toolBar;
        }

        public void InstallPlugin()
        {
            this.getCompose();
            foreach (var item in this.ToolBarPlugins)
            {
                item.Value.Draw(this.toolBar);
            }
        }

        public void InstallPlugin(global::IPanelContainer.IPanelContainer panelContainer)
        {
            throw new NotImplementedException();
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
