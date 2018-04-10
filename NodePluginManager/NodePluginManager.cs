using GlobalTracker;
using IFillNode;
using IPanelContainer;
using IPluginManager;
using MefExport;
using NodeBase;
using NodeListPanel;
using NodePanel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NodePluginManager
{
    public class NodePluginManager : IPluginManager.IPluginManager
    {
        private NodeListPanel.NodeListPanel nodelistpanel = null;
        public NodePluginManager(NodeListPanel.NodeListPanel nodeListPanel)
        {
            this.nodelistpanel = nodeListPanel;
        }

        [ImportMany(typeof(IFillNode.IFillNode))]
        public IEnumerable<Lazy<IFillNode.IFillNode, NodeTypePlugin>> nodeplugins { get; set; }
        public void InstallPlugin()
        {
            this.getCompose();

            foreach (var plugin in this.nodeplugins)
            {
                
                List<INodeBase> nodes = plugin.Value.Draw();
                foreach (var item in nodes)
                {
                   
                    this.nodelistpanel.AddNodeTag(item.ShortTag,item,NodeActivity);
                }

            }
           
        }

        private void NodeActivity(INodeBase node)
        {
            GlobalTracker.GlobalTracker gt = GlobalTracker.GlobalTracker.GetInstance();

            NodePanel.NodePanel panel = gt.GetPanelByShorName("NEP") as NodePanel.NodePanel;
            Canvas canvas = panel.GetCanvas;
            canvas.Children.Add(node)

            
        }

        public void InstallPlugin(IPanelContainer.IPanelContainer panelContainer)
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
