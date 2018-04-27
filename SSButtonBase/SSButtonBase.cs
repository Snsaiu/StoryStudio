using CommandManager;
using GlobalTracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
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
            this.Margin = new Thickness(5.0f, 0.0f, 5.0f, 0.0f);
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
        /// 设置按钮marggin属性
        /// </summary>
        protected Thickness ButtonMargin { get; set; }

        /// <summary>
        /// 当鼠标移到按钮上时显示的备注
        /// </summary>
        /// <returns></returns>
        protected virtual object SetToolTip()
        {
            return null;
        }

        /// <summary>
        /// 初始化函数，主要用于初始化按钮的事件
        /// </summary>
        private void initialize()
        {
            this.ToolTip = SetToolTip();

            this.Width = 15;
            this.Height = 15;
            this.Margin = new Thickness(5.0f, 0.0f, 5.0f, 0.0f);

            ResourceDictionary resourceDictionary = new ResourceDictionary();
            resourceDictionary.Source = new Uri(@"..\..\styles\button_style.xaml",UriKind.Relative);
            Style buttonstyel = resourceDictionary["myButtonStyle"] as Style;
            this.Style = buttonstyel;

            this.Background = this.DisplayBG();

            this.Click += SSButtonBase_Click;      
            this.MouseEnter += SSButtonBase_MouseEnter;
            this.MouseLeave += SSButtonBase_MouseLeave;
            // 获得主窗口对象
              GlobalTracker.GlobalTracker.GetInstance().GetWindow().KeyDown += SSButtonBase_KeyDown;
            // 快捷键事件
            this.KeyDown += SSButtonBase_KeyDown;

        }

        /// <summary>
        /// 设置热键,只能识别两个键同时按下
        /// </summary>
        /// <returns></returns>
        protected virtual List<Key> SetHotKey()
        {
            return null;
        }

        /// <summary>
        /// 键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SSButtonBase_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (SetHotKey() != null)
            {
                if (SetHotKey().Count > 2 && SetHotKey().Count <= 1)
                {
                    return;
                }
                else
                {
                    if (e.KeyboardDevice.IsKeyDown(SetHotKey()[0])  && e.KeyboardDevice.IsKeyDown(SetHotKey()[1]))
                    {
                        this.OnceClick(sender, e);
                    }
                }
            }
      
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

    }
}
