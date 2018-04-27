using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MefExport;
using SSButtonBase;

namespace SStoolbarItem
{

    public class Redo : SSButtonBase.SSButtonBase
    {
        protected override Brush DisplayBG()
        {

            return new ImageBrush(new BitmapImage(new Uri(@"..\..\content\redo_leave.png", UriKind.RelativeOrAbsolute))) { Stretch = Stretch.Uniform };
        }

        private CommandManager.CommandManager commandManager = null;


        protected override object SetToolTip()
        {
            return "重做";
        }

        public Redo()
        {
            this.commandManager = CommandManager.CommandManager.GetInstance();
        }

        protected override Brush MouseClickBG()
        {
            return new ImageBrush(new BitmapImage(new Uri(@"..\..\content\redo_click.png", UriKind.RelativeOrAbsolute))) { Stretch = Stretch.Uniform };
        }

        protected override Brush MouseEnterBG()
        {
            return new ImageBrush(new BitmapImage(new Uri(@"..\..\content\redo_enter.png", UriKind.RelativeOrAbsolute))) { Stretch = Stretch.Uniform };
        }


        protected override void OnceClick(object sender, RoutedEventArgs e)
        {

            this.commandManager.Redo();
            Console.WriteLine("dd");
        }
    }
}
