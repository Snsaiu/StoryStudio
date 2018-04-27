using CommandManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SStoolbarItem
{
   public class Undo : SSButtonBase.SSButtonBase
    {
        protected override Brush DisplayBG()
        {
                return new ImageBrush(new BitmapImage(new Uri(@"..\..\content\undo_leave.png", UriKind.RelativeOrAbsolute))) { Stretch = Stretch.Uniform };
        }

        public Undo()
        {
            this.commandManager = CommandManager.CommandManager.GetInstance();
        }

        private CommandManager.CommandManager commandManager = null;

        protected override List<Key> SetHotKey()
        {
            return new List<Key>() { Key.LeftCtrl, Key.Z };
        }

        protected override object SetToolTip()
        {
            return "撤销";
        }

        protected override Brush MouseClickBG()
        {
            return new ImageBrush(new BitmapImage(new Uri(@"..\..\content\undo_click.png", UriKind.RelativeOrAbsolute))) { Stretch = Stretch.Uniform };
        }

        protected override Brush MouseEnterBG()
        {
          
          return new ImageBrush(new BitmapImage(new Uri(@"..\..\content\undo_enter.png", UriKind.RelativeOrAbsolute))) { Stretch = Stretch.Uniform };
        }


        protected override void OnceClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("hello");
            this.commandManager.Undo();
        }
    }
}
