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

          return new ImageBrush(new BitmapImage(new Uri(@"..\..\content\undo.png", UriKind.RelativeOrAbsolute)));
        }

        protected override void DoubleClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void OnceClick(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
