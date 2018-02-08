using ISSDataOper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIOOper
{
    public interface IIOOper
    {

        bool Write(string file, ISSDataOper.ISSDataOper database);
        bool Read(string file, out ISSDataOper.ISSDataOper database);
    }
}
