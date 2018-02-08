using SSBase;
using System.Collections.Generic;

namespace ISSDataOper
{
    public interface ISSDataOper
    {
        List<ISSBase> GetData();
        bool SetData(ISSBase data);
    }
}
