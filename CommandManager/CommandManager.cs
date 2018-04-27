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
            //撤销最大次数
            this.UndoCount = 20;

            this._redoStack = new Stack<ISSCommand.ISSCommand>();
            this._undoStack = new Stack<ISSCommand.ISSCommand>();
        }

        public void ExecuteCommand(ISSCommand.ISSCommand cmd)
        {
            // todo :需要添加其他的逻辑，

            // 执行命令之后 压入undo的栈
            cmd.Execute();
            this._undoStack.Push(cmd);
        }

        public void Undo()
        {
            //todo:缺少判断,如果为空应该禁止执行,如果栈上限了,应该把最底层的命令删除掉

            // 将undo栈中的最上层的对象先弹出出来
            if (this._undoStack.Count==0)
            {
                return;
            }
            ISSCommand.ISSCommand undocommond = this._undoStack.Pop();
            // 执行一下undo
            undocommond.Undo();
            // 压入redo栈中
            this._redoStack.Push(undocommond);


        }

        public void Redo()
        {
            if (this._redoStack.Count == 0)
            {
                return;
            }
            // todo:缺少判断,如果为空应该禁止执行,如果栈上限了,应该把最底层的命令删除掉
            ISSCommand.ISSCommand redocommand = this._redoStack.Pop();
            redocommand.Execute();
            this._undoStack.Push(redocommand);

        }
    }
}
