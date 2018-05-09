using NodeBase;
using System;
using System.Windows.Controls;

namespace SSNodeButton
{
    public class SSNodeButton:Button
    {

        /// <summary>
        /// 设置标签名
        /// </summary>
        public object DisplayLabel
        {
            get => this.Content; 
            set => this.Content=value; 
        }


        private CommandManager.CommandManager _cmdmanager = null;

        /// <summary>
        /// 设置或者的到commandmanager对象实例
        /// </summary>
        public CommandManager.CommandManager CommandManger { get=>this._cmdmanager; set=>this._cmdmanager=value; }

        /// <summary>
        /// 添加节点的委托
        /// </summary>
        private Action<NodeBase.NodeBase,Canvas> _actionNode;

        /// <summary>
        /// 节点实例
        /// </summary>
        private NodeBase.NodeBase _lastNode = null;

        /// <summary>
        /// 节点存放的面板实例
        /// </summary>
        private Canvas _canvas = null;


        /// <summary>
        /// 构造ssnodebutton，需要一个cmdmanager对象实例
        /// </summary>
        /// <param name="cmdmanager">commandmanger对象实例</param>
        public SSNodeButton(CommandManager.CommandManager cmdmanager)
        {

           

            this._cmdmanager = cmdmanager;

            //初始化
            this.initialize();
        }

        public SSNodeButton()
        {
            this._cmdmanager = CommandManager.CommandManager.GetInstance();
            //初始化
            this.initialize();
        }

        /// <summary>
        /// 初始化函数
        /// </summary>
        private void initialize()
        {
            this.Click += SSNodeButton_Click;
        }

        private void SSNodeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            //todo :添加命令逻辑
            this._actionNode(this._lastNode, this._canvas);
            GlobalTracker.GlobalTracker globalTracker = GlobalTracker.GlobalTracker.GetInstance();
            AddNodeCommand addNodeCommand = new AddNodeCommand( globalTracker.LastNode as NodeBase.NodeBase, this._canvas);
            this._cmdmanager.ExecuteCommand(addNodeCommand);

        }

        /// <summary>
        /// 在节点面板中添加一个node
        /// </summary>
        /// <param name="addnodefunc">添加节点的具体实现函数</param>
        /// <param name="node">节点对象实例</param>
        public void NodeActivity(Action<NodeBase.NodeBase,Canvas> addnodefunc,NodeBase.NodeBase node,Canvas canvas)
        {
            this._actionNode = addnodefunc;
            this._lastNode = node;
            this._canvas = canvas;
        }



    }
}
