﻿using NodeBase;
using System;
using System.Windows;
using System.Windows.Controls;

namespace NodeListPanel
{
    /// <summary>
    /// Interaction logic for NodeListPanel.xaml
    /// </summary>
    public partial class NodeListPanel : UserControl, IPanelBase.IPanelBase, IJoinGlobalTracker.IJoinGlobalTracker
    {
        
        public string PanelLabel =>"节点列表面板";

        public string ShortName => "NLP";

        public string LongName => "NodeListPanel";

        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public global::BaseTypeEnum.BaseTypeEnum BaseType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public NodeListPanel()
        {
            InitializeComponent();

          
        }

        private bool _isactivity=false;

        public bool IsActivity { get => _isactivity; set => this._isactivity = value; }



        /// <summary>
        /// 添加一个node标签
        /// </summary>
        /// <param name="TagName">标签名</param>
        /// <param name="func">标签功能</param>
        /// <param name="nodeBase">节点实例</param>
        /// <param name="canvas">节点存放的面板实例</param>
        public void AddNodeTag(string TagName,NodeBase.NodeBase nodeBase,Action<NodeBase.NodeBase,Canvas> func,Canvas canvas)
        {

            SSNodeButton.SSNodeButton btn = new SSNodeButton.SSNodeButton();

            //todo:命令管理器

            btn.DisplayLabel = TagName;
            btn.NodeActivity(func, nodeBase, canvas);
            this.NodeListPanelContainer.Children.Add(btn);
        }

        /// <summary>
        /// 给定一个Node的标签并且删除
        /// </summary>
        /// <param name="TagName">要删除的node的标签</param>
        /// <returns>如果查找到该node并且删除，返回true，否则返回false</returns>
        public bool RemoveNodeTag(string TagName)
        {
            foreach (Button item in this.NodeListPanelContainer.Children)
            {
                if(item.Content.ToString()==TagName)
                {
                    this.NodeListPanelContainer.Children.Remove(item);
                    return true;
                }
          
                     
              
            }
            return false;

        }

        public void SetPanelFloat(UIElement parent)
        {
            throw new NotImplementedException();
        }

        public void SetPanelNoFloat(UIElement parent)
        {
            throw new NotImplementedException();
        }

        public bool FindDataByTag(string tag, out object resource)
        {
            throw new NotImplementedException();
        }

        public void Join()
        {
            GlobalTracker.GlobalTracker gt = GlobalTracker.GlobalTracker.GetInstance();
            gt.AddPanelInstance(this);
        }

        public bool Quit()
        {
            GlobalTracker.GlobalTracker gt = GlobalTracker.GlobalTracker.GetInstance();
            return gt.RemovePanelByShortName("CP");
        }
    }
}
