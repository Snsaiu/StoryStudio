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
    public class SaveAs : SSButtonBase.SSButtonBase
    {
        protected override Brush DisplayBG()
        {
            return new ImageBrush(new BitmapImage(new Uri(@"..\..\content\saveas_leave.png", UriKind.RelativeOrAbsolute))) { Stretch = Stretch.Uniform };
        }



        protected override Brush MouseClickBG()
        {
            return new ImageBrush(new BitmapImage(new Uri(@"..\..\content\saveas_click.png", UriKind.RelativeOrAbsolute))) { Stretch = Stretch.Uniform };
        }

        protected override Brush MouseEnterBG()
        {
            return new ImageBrush(new BitmapImage(new Uri(@"..\..\content\saveas_enter.png", UriKind.RelativeOrAbsolute))) { Stretch = Stretch.Uniform };
        }

        protected override void OnceClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("dd");
        }

        protected override object SetToolTip()
        {
            return "另存为";
        }

    }
}
