using ArrowLineWithText;
using System.Windows.Media;

namespace DefaultLineFactory
{
    public class DefaultLineFactory : SSLineFactoryAbs.SSLineFactoryAbs
    {

        public override SSLine.ArrowBase CreateCharacterLine()
        {
            // todo:添加线的具体描述
            SSLine.ArrowBase arrowLineWithText = new ArrowLineWithText.ArrowLineWithText();
            arrowLineWithText.Stroke = Brushes.CadetBlue;
            arrowLineWithText.StrokeThickness = 0.3;
            arrowLineWithText.ArrowLength = 3;
            
            return arrowLineWithText;
        }

        public override SSLine.ArrowBase CreateEventLine()
        {
            // todo:添加线的具体描述
            SSLine.ArrowBase arrowLineWithText = new ArrowLineWithText.ArrowLineWithText();

            return arrowLineWithText;
        }
    }
}
