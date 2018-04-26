using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace SStoolbarItem
{
    public class SaveAs : SSButtonBase.SSButtonBase
    {
        protected override Brush DisplayBG()
        {
            return null;
        }


        protected override void DoubleClick(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override Brush MouseClickBG()
        {
            return null;
        }

        protected override Brush MouseEnterBG()
        {
            return null;
        }

        protected override void OnceClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
