using IUsableData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IFillMenuUI
{
    public interface IFillMenuUI
    {
        bool Draw(Menu parentMenu);
    }
}
