using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SSLine
{
    public class DefaultLineFactory : SSLineFactoryAbs
    {

        public override ArrowLineWithText CreateCharacterLine()
        {
            // todo:添加线的具体描述
            ArrowLineWithText arrowLineWithText = new ArrowLineWithText();
            arrowLineWithText.Stroke = Brushes.CadetBlue;
            arrowLineWithText.StrokeThickness = 0.3;
            arrowLineWithText.ArrowLength = 3;
            
            return arrowLineWithText;
        }

        public override ArrowLineWithText CreateEventLine()
        {
            // todo:添加线的具体描述
            ArrowLineWithText arrowLineWithText = new ArrowLineWithText();

            return arrowLineWithText;
        }
    }
}
