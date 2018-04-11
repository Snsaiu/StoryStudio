using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using IPanelContainer;

namespace PanelContainer
{
    /// <summary>
    /// Interaction logic for PanelContainer.xaml
    /// </summary>
    public partial class PanelContainer : UserControl, IPanelContainer.IPanelContainer, IJoinGlobalTracker.IJoinGlobalTracker
    {

        private Dictionary<string, UIElement> _panelsDictionary = null;
        private UIElement _activityPanel = null;

        private string _containername = null;

        public event NotifyUpdateDelegate NotifyUpdateEvent;

        /// <summary>
        /// 获得面板名称
        /// </summary>
        public string PanelName => this._containername;

        /// <summary>
        /// 实例化一个面板容器
        /// </summary>
        /// <param name="ContainerName">容器的名称</param>
        public PanelContainer(string ContainerName)
        {
            this._containername = ContainerName;

            InitializeComponent();

            this._panelsDictionary = new Dictionary<string, UIElement>();

            ///here need use plugin add panel
            this.TagList.ItemsSource = this._panelsDictionary;

            this.TagList.SelectionChanged += ((o, e) =>
            {
                int index = this.TagList.SelectedIndex;

                string key = this._panelsDictionary.ElementAt(index).Key;

                if (this._activityPanel!=null)
                {
                    IPanelBase.IPanelBase p = this._activityPanel as IPanelBase.IPanelBase;
                    p.IsActivity = false;
                }

                //Update();

                this.ActivityPanel(key);

                // 委托通知其他容器更新
                if (NotifyUpdateEvent!=null)
                {
                    this.NotifyUpdateEvent();
                }

            });

            // 将自己添加到globaltracker中
            this.Join();
         

            // 订阅事件，注意，不要订阅自己的事件
            //GlobalTracker.GlobalTracker gt = GlobalTracker.GlobalTracker.GetInstance();
            //foreach (var item in gt.GetContainers())
            //{
            //    if (item.PanelName==this._containername)
            //    {
            //        continue;
            //    }
                //this.NotifyUpdateEvent += () =>
                //{
                //    Update();
                //};

            //}




        }

        /// <summary>
        /// 更新容器列表
        /// </summary>
        public void Update()
        {

            //清空字典
            this._panelsDictionary.Clear();

            GlobalTracker.GlobalTracker gt = GlobalTracker.GlobalTracker.GetInstance();

            foreach (var item in gt.GetPanels())
            {
                if (item.IsActivity == false)
                {

                    this._panelsDictionary.Add(item.PanelLabel, item as UIElement);
                }
            }
        }


        /// <summary>
        /// 根据面板名称移除面板
        /// </summary>
        /// <param name="panelName">面板名称</param>
        /// <returns>如果移除成功，那么返回true，否则返回false</returns>
        public bool RemovePanel(string panelName)
        {
            if (this._panelsDictionary.ContainsKey(panelName))
            {
                this._panelsDictionary.Remove(panelName);
                return true;
            }

            return false;

        }


        public void ActivityPanel(string PanelName,bool replace=true)
        {
            if (replace)
            {
                if (this._panelsDictionary.ContainsKey(PanelName))
                {
                    // 如果是使用替换机制，要检查是否有其他面板已经占用该面板，如果占用，那么替换

                    GlobalTracker.GlobalTracker gt = GlobalTracker.GlobalTracker.GetInstance();

                    foreach (var item in gt.GetContainers())
                    {
                        //如果遍历到自己，那么不处理
                        if (item.PanelName==this.PanelName)
                        {
                            continue;
                        }
                        else
                        {
                            IPanelBase.IPanelBase p = item.GetActivityPanel() as IPanelBase.IPanelBase;

                            if (p!=null)
                            {
                                // 如果发现已经有容器激活了该面板，清除它
                                if (p.PanelLabel == PanelName)
                                {
                                    item.Unactivity();

                                    this.Container.Children.Clear();
                                    IPanelBase.IPanelBase pa = this._panelsDictionary[PanelName] as IPanelBase.IPanelBase;
                                    pa.IsActivity = true;
                                    UIElement u = pa as UIElement;
                                    this.Container.Children.Add(u);
                                    this._activityPanel = u;


                                    //原始的面板应该要找一个没有被使用的面板填充
                                    item.TryActivityPanel();
                                    return;
                                }
                            }

                   
                        }
                    }

                    this.Container.Children.Clear();
                    IPanelBase.IPanelBase panel = this._panelsDictionary[PanelName] as IPanelBase.IPanelBase;
                    panel.IsActivity = true;
                    UIElement uI = panel as UIElement;
                    this.Container.Children.Add(uI);
                    this._activityPanel = uI;
                }
            }
            else
            {
                if (this._panelsDictionary.ContainsKey(PanelName))
                {
                    this.Container.Children.Clear();
                    IPanelBase.IPanelBase panel = this._panelsDictionary[PanelName] as IPanelBase.IPanelBase;
                    panel.IsActivity = true;

                    UIElement uI = panel as UIElement;
                    this.Container.Children.Add(uI);
                    this._activityPanel = uI;
                }
            }




        }

        public bool AddNewPanel(string PanelName, UIElement panel)
        {
            if (this._panelsDictionary.ContainsKey(PanelName))
            {
                return false;
            }
            else
            {
                this._panelsDictionary.Add(PanelName, panel);
                return true;
            }
        }

        public UIElement GetActivityPanel()
        {
            return this._activityPanel;
        }

        public List<UIElement> GetChildren()
        {
            List<UIElement> list = new List<UIElement>();
            foreach (var item in this._panelsDictionary.Keys)
            {
                list.Add(this._panelsDictionary[item]);
            }
            return list;
        }

        public void Join()
        {
            GlobalTracker.GlobalTracker gt = GlobalTracker.GlobalTracker.GetInstance();
            gt.AddContanierInstance(this);
           
        }

        public bool Quit()
        {
            GlobalTracker.GlobalTracker gt = GlobalTracker.GlobalTracker.GetInstance();
            return gt.RemoveContainerInstanceByPanelName(this._containername);
        }


        public void Unactivity()
        {

            ((this.GetActivityPanel()) as IPanelBase.IPanelBase).IsActivity = false; 
            this.Container.Children.Clear();
        }

        public bool TryActivityPanel()
        {
            int count = this.TagList.Items.Count;

            for (int i = 0; i < count; i++)
            {
               if( (this._panelsDictionary.ElementAt(i).Value as IPanelBase.IPanelBase).IsActivity==false)
                {
                    if (this.Container.Children.Count!=0)
                    {
                        this.Container.Children.Clear();
                    }
                    // this.ActivityPanel(this._panelsDictionary.ElementAt(i).Key);
                    this.Container.Children.Add((this._panelsDictionary.ElementAt(i).Value));

                    this.TagList.SelectedIndex = i;
                    return true;
                }
            }
            return false;
        }
    }
}
