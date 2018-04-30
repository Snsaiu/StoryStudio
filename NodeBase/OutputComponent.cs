using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NodeBase
{
    public abstract class OutputComponent : NodeComponentBase
    {
        public override void NotifyMove()
        {
            Console.WriteLine("ddd");
        }
        protected override void ClickEvent(object sender, RoutedEventArgs e)
        {
            //todo:处理输出节点点击事件
        }
    }
}
