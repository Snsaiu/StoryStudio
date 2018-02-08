using IIOOper;
using IReadWrite;
using ISSDataOper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocOper
{
    public abstract class DocOper : IIOOper.IIOOper
    {
        private IReadWrite.IReadWrite _readwrite;

        public void AddFileType(IReadWrite.IReadWrite readwrite)
        {
            this._readwrite = readwrite;
        }
        public bool Read(string file, out ISSDataOper.ISSDataOper database)
        {
            return this._readwrite.Read(file, out database);
        }

        public bool Write(string file, ISSDataOper.ISSDataOper database)
        {
            return this._readwrite.Write(file, database);
        }
    }
}
