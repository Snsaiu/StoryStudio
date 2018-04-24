using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SStoolbarItem
{
    public class SaveAs : SSButtonBase.SSButtonBase
    {
        protected override object DisplayLabel()
        {
            return "另存为";
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
