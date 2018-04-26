using CommandManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;


namespace SSButtonBase
{
    /// <summary>
    /// 抽象类, storystudio中所有的按钮理论都应该继承SSButtonBase
    /// </summary>
    public abstract class SSButtonBase:Button
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
        /// 设置鼠标离开背景图标
        /// </summary>
        /// <returns></returns>
        protected abstract Brush DisplayBG();

        /// <summary>
        /// 设置鼠标点击背景图标
        /// </summary>
        /// <returns></returns>
        protected abstract Brush MouseClickBG();

        /// <summary>
        /// 设置鼠标进入背景图标
        /// </summary>
        /// <returns></returns>
        protected abstract Brush MouseEnterBG();


        /// <summary>
        /// 构造ssbuttonbase实例
        /// </summary>
        /// <param name="cmdManager">命令管理器实例</param>
        public SSButtonBase(CommandManager.CommandManager cmdManager)
        {

            this._cmdManager = cmdManager;
            this.initialize();
        }

        /// <summary>
        /// 构造ssbuttonbase实例
        /// </summary>
        public SSButtonBase()
        {
          
            this.initialize();

        }

        /// <summary>
        /// 初始化函数，主要用于初始化按钮的事件
        /// </summary>
        private void initialize()
        {
            this.Width = 20;
            this.Height = 20;
            this.Background = this.DisplayBG();



            //
            //this.Style.Triggers.Clear();
            //TriggerBase trigger = new EventTrigger(MouseEnterEvent);

            //Setter setter = new Setter();
            //setter.Property = BackgroundProperty;
            //setter.Value = new SolidColorBrush(Colors.Green);
            //trigger.SetValue(BackgroundProperty, new SolidColorBrush(Colors.Green));
            //this.Triggers.Add(trigger);

            Console.WriteLine(this.Triggers.Count());

            this.Click += SSButtonBase_Click;
            this.MouseDoubleClick += SSButtonBase_MouseDoubleClick;
            this.MouseEnter += SSButtonBase_MouseEnter;
            this.MouseLeave += SSButtonBase_MouseLeave;
           
        }

        private void SSButtonBase_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.Background = this.DisplayBG();
        }

        private void SSButtonBase_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
          
            this.Background = this.MouseEnterBG();
        }

        /// <summary>
        /// 按钮双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SSButtonBase_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //this.Background = this.MouseClickBG();
            //this.DoubleClick(sender, e);
        }

        /// <summary>
        /// 按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SSButtonBase_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Background = this.MouseClickBG();
            this.OnceClick(sender, e);

           
        }

        /// <summary>
        /// 按钮单击事件的具体实现，子类必须实现该方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected abstract void OnceClick(object sender, System.Windows.RoutedEventArgs e);

        /// <summary>
        /// 按钮双击事件的具体实现，子类必须实现该方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected abstract void DoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e);

    }
}
