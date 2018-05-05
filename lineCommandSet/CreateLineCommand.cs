using ISSCommand;
using SSLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineCommandSet
{
    public class CreateLineCommand : ISSCommand.ISSCommand
    {
        private ArrowLineWithText _arrowLineWithText = null;
        public CreateLineCommand(ArrowLineWithText arrowLineWithText)
        {
            this._arrowLineWithText = arrowLineWithText;
        }

        public void Execute()
        {
            
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
