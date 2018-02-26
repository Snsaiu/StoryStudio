using IFillMenuUI;
using IPluginManager;
using MefExport;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MenuPluginManager
{
    public class MenuPluginManager : IPluginManager.IPluginManager
    {
        [ImportMany(typeof(IFillMenuUI.IFillMenuUI))]
        public IEnumerable<Lazy<IFillMenuUI.IFillMenuUI,MenuTypePlugin>> MenuPlugins { get; set; }
        private StackPanel _stackpanel = null;

        public MenuPluginManager(StackPanel parent)
        {
            this._stackpanel = parent;
        }

        public void InstallPlugin()
        {
            this.getCompose();
            foreach (var plugin in this.MenuPlugins)
            {
                if (plugin.Metadata.PluginType=="FileMenu")
                {
                    try
                    {
                        plugin.Value.Draw(this._stackpanel, null);

                    }
                    catch (Exception)
                    {

                      //  throw;
                    }
                 
                }
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
