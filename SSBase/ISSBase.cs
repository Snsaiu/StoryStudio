using BaseTypeEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSBase
{
    public interface ISSBase
    {
        int Id { get; set; }
        BaseTypeEnum.BaseTypeEnum BaseType { get; set; }

        bool FindDataByTag(string tag, out object resource);
    }
}
