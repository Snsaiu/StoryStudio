using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSCommand
{
    public interface ISSCommand
    {
        void Execute(object param);
        void Undo(object param);
    }
}
      