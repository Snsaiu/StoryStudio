using ISSCommand;
using NodeBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CommandSet
{
    public class AddNodeCommand : ISSCommand.ISSCommand
    {


        private Action<NodeBase.NodeBase, Canvas> _actionNode;

        /// <summary>
        /// 节点实例
        /// </summary>
        private NodeBase.NodeBase _lastNode = null;

        /// <summary>
        /// 节点存放的面板实例
        /// </summary>
        private Canvas _canvas = null;

        public AddNodeCommand(Action<NodeBase.NodeBase,Canvas> func,NodeBase.NodeBase node,Canvas canvas)
        {
            this._actionNode = func;
            this._lastNode = node;
            this._canvas = canvas;
        }



        public void Execute()
        {
            this._actionNode(this._lastNode, this._canvas);

        }

        public void Undo()
        {

            //   this._canvas.Children.Remove(this._lastNode as UIElement);
            //for (int i = 0; i < this._canvas.Children.Count; i++)
            //{
            //    if (this._canvas.Children[i] is NodeBase.NodeBase)
            //    {
            //        if (this._lastNode == this._canvas.Children[i] as NodeBase.NodeBase)
            //        {

            //            this._canvas.Children.RemoveAt(i);
            //        }
            //        Console.WriteLine(this._canvas.Children[i].GetType());
            //    }
            this._canvas.Children.RemoveAt(this._canvas.Children.Count - 1);

              
              
            

            //this._canvas.Children.Clear();
        }
    }
}
