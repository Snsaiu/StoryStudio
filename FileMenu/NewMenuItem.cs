using CommandManager;
using DisplayLabelEnum;
using SSMenuItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FileMenu
{
    public class NewMenuItem : SSMenuItem.SSMenuItem
    {
        private CommandManager.CommandManager _cmdmanager=null;

        public NewMenuItem(CommandManager.CommandManager commandManager):base(commandManager)
        {

        }

        public NewMenuItem()
        {

        }


        
        protected override void OnceClick(object sender, RoutedEventArgs e)
        {
           // throw new NotImplementedException();
        }

        protected override object SetDisplayLabel()
        {
            return MenuDisplayLabel.新建;
        }
    }
}
