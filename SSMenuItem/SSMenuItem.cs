using CommandManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace SSMenuItem
{
    /// <summary>
    /// 抽象类，storystudio中所有的菜单子按钮理论都应该继承SSMenuItem
    /// </summary>
    public abstract class SSMenuItem:MenuItem
    {
        /// <summary>
        /// 存储命令管理器
        /// </summary>
        private CommandManager.CommandManager _cmdManager;

        /// <summary>
        /// 设置或者获得命令管理器实力
        /// </summary>
        public CommandManager.CommandManager CmdManager
        {
            get { return _cmdManager; }
            set { _cmdManager = value; }
        }


        /// <summary>
        /// 添加子按钮
        /// </summary>
        /// <param name="son">子按钮实例</param>
        protected void AddSon(object son)
        {
            this.Items.Add(son);
        }


        /// <summary>
        /// 构造ssmenuitem的实例
        /// </summary>
        /// <param name="cmdManager">命令管理器</param>
        public SSMenuItem(CommandManager.CommandManager cmdManager)
        {
            this._cmdManager = cmdManager;

            this.Initialize();
        }

        /// <summary>
        /// 构造ssmenuitem的实例
        /// </summary>
        public SSMenuItem()
        {
            this.Initialize();
        }

        /// <summary>
        /// 设置或者获得菜单子按钮的文字颜色
        /// </summary>
        public Brush MenuItemForeground { get=>this.Foreground; set=>this.Foreground=value; }

        /// <summary>
        /// 设置或者获得菜单子按钮的背景颜色
        /// </summary>
        public Brush MenuItemBackground { get=>this.Background; set=>this.Background=value; }

        /// <summary>
        /// 获得菜单子按钮的显示内容
        /// </summary>
        public object DisplayLabel { get=>this.Header; }

        /// <summary>
        /// 保存背景色
        /// </summary>
        private Brush _SaveBackgroundColor = null;
        

        /// <summary>
        /// 初始化按钮
        /// </summary>
        private void Initialize()
        {

            //文字颜色
            this.Foreground= new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFF"));

            // 背景颜色
            this.Background= new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF28292A"));

            this._SaveBackgroundColor = this.Background;

            // 显示菜单子按钮的显示内容
            this.Header = this.SetDisplayLabel();

            //点击事件
            this.Click += SSMenuItem_Click;

            //鼠标进入事件
            this.MouseEnter += SSMenuItem_MouseEnter;

            //鼠标离开事件
            this.MouseLeave += SSMenuItem_MouseLeave;

            

        }

        private void SSMenuItem_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.Background = this._SaveBackgroundColor;
         
        }

        private void SSMenuItem_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.Background = new SolidColorBrush(Colors.Gray);
           
           
        }

        /// <summary>
        /// 设置菜单子按钮的显示内容
        /// </summary>
        /// <returns>返回显示内容的实例</returns>
        protected abstract object SetDisplayLabel();


        /// <summary>
        /// 菜单按钮的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SSMenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.OnceClick(sender,e);
        }

        /// <summary>
        /// 菜单子按钮点击事件的具体实现，子类必须实现该方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected abstract void OnceClick(object sender, System.Windows.RoutedEventArgs e);


       

    }
}
