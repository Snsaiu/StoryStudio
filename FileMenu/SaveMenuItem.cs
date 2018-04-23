using DisplayLabelEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FileMenu
{
    public class SaveMenuItem : SSMenuItem.SSMenuItem
    {
        protected override void OnceClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override object SetDisplayLabel()
        {
            return MenuDisplayLabel.保存;
        }
    }
}
