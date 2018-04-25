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

            //ImageBrush image = new ImageBrush();
            //image.ImageSource = new BitmapImage(new Uri("undo.png", UriKind.Relative));
            //image.Stretch = Stretch.Fill;
            //image.TileMode = TileMode.Tile;
            //return image;
            return null;
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
