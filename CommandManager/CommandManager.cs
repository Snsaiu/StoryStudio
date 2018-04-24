using ISSCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandManager
{
    /// <summary>
    /// 命令管理器类，单例
    /// </summary>
    public class CommandManager
    {
        /// <summary>
        /// 存放撤销动作的栈
        /// </summary>
        private Stack<ISSCommand.ISSCommand> _undoStack = null;

        /// <summary>
        /// 存放重做动作的栈
        /// </summary>
        private Stack<ISSCommand.ISSCommand> _redoStack = null;

        /// <summary>
        /// 最大撤销次数，如果是-1表示无限存放，这样会造成内存的占用较高，不建议设置太高
        /// </summary>
        private int _undoCount = -1;

        /// <summary>
        /// 设置或者获得撤销的最大次数
        /// </summary>
        public int UndoCount { get=>this._undoCount; set=>this._undoCount=value; }


        /// <summary>
        /// 全局存放CommandManager对象实例
        /// </summary>
        private static CommandManager _instance = null;

        /// <summary>
        /// 获得commandManager实例
        /// </summary>
        /// <returns>返回CommandManager对象实例</returns>
        public static CommandManager GetInstance()
        {
            if (_instance==null)
            {
                _instance = new CommandManager();
            }
            return _instance;
        }

        /// <summary>
        /// 构造函数，实例化一个命令管理器
        /// </summary>
        /// <param name="undoCount"></param>
        private CommandManager()
        {
            this._redoStack = new Stack<ISSCommand.ISSCommand>();
            this._undoStack = new Stack<ISSCommand.ISSCommand>();
        }

        public void ExecuteCommand(ISSCommand.ISSCommand cmd)
        {
            // todo :需要添加其他的逻辑，
            cmd.Execute();
        }

        public void Undo()
        {
            //todo:添加逻辑
        }

        public void Redo()
        {
            // todo:添加逻辑
        }
    }
}
