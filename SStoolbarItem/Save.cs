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
    public class Save : SSButtonBase.SSButtonBase
    {
        protected override Brush DisplayBG()
        {
            return new ImageBrush(new BitmapImage(new Uri(@"..\..\content\save_leave.png", UriKind.RelativeOrAbsolute))) { Stretch = Stretch.Uniform };
        }

        protected override object SetToolTip()
        {
            return "保存";
        }

        protected override Brush MouseClickBG()
        {
            return new ImageBrush(new BitmapImage(new Uri(@"..\..\content\save_click.png", UriKind.RelativeOrAbsolute))) { Stretch = Stretch.Uniform };
        }

        protected override Brush MouseEnterBG()
        {
            return new ImageBrush(new BitmapImage(new Uri(@"..\..\content\save_enter.png", UriKind.RelativeOrAbsolute))) { Stretch = Stretch.Uniform };
        }

        protected override void OnceClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("dd");
        }
    }
}
