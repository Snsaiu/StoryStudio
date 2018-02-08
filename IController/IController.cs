using ISSCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IController
{
    public interface IController
    {
       bool HasCommand { get; set; }

        bool AddCommand(string label, ISSCommand.ISSCommand command);
        bool ChangedCommand(string label, ISSCommand.ISSCommand newCommand);
        bool RemoveCommand(string label);
        bool ExecuteCommand(string label);
        bool RedoCommand();
        bool UndoCommand();

    }
}
