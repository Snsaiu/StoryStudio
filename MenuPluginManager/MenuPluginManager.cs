using IFillMenuUI;
using IPanelContainer;
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
        public IEnumerable<Lazy<IFillMenuUI.IFillMenuUI, MenuTypePlugin>> MenuPlugins { get; set; }
        private Menu _stackMenu = null;

        public MenuPluginManager(Menu parent)
        {
            this._stackMenu = parent;
        }

        public void InstallPlugin()
        {
            this.getCompose();

            // 这里不知道怎么样才能排序，所以 要循环多次 ,
            //暂时用这种方法吧
            // todo :需要使用更加好的方法进行排序
            foreach (var plugin in this.MenuPlugins)
            {
                // load file menu
                if (plugin.Metadata.PluginType == "FileMenu")
                {

                    if (plugin.Value.Draw(this._stackMenu))
                    {
                        // todo : display true information
                    }
                    else
                    {
                        // todo: display false information
                    }

                }
             
            }
            foreach (var plugin in this.MenuPlugins)
            {
                if (plugin.Metadata.PluginType == "EditMenu")
                {
                    if (plugin.Value.Draw(this._stackMenu))
                    {
                        // todo: display true information
                    }
                    else
                    {
                        // todo: display false information
                    }
                }
            }
            foreach (var plugin in this.MenuPlugins)
            {
                if (plugin.Metadata.PluginType == "NodeMenu")
                {
                    if (plugin.Value.Draw(this._stackMenu))
                    {
                        // todo :display true information
                    }
                    else
                    {
                        // todo: display false information
                    }
                }
            }
            foreach (var plugin in this.MenuPlugins)
            {
                if (plugin.Metadata.PluginType == "WindowMenu")
                {
                    if (plugin.Value.Draw(this._stackMenu))
                    {
                        // todo :display true information
                    }
                    else
                    {
                        // todo: display false information
                    }
                }
            }
            foreach (var plugin in this.MenuPlugins)
            {
                if (plugin.Metadata.PluginType == "HelpMenu")
                {
                    if (plugin.Value.Draw(this._stackMenu))
                    {
                        // todo :display true information
                    }
                    else
                    {
                        // todo: display false information
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

        public void InstallPlugin(IPanelContainer.IPanelContainer panelContainer)
        {
            throw new NotImplementedException();
        }
    }
}
