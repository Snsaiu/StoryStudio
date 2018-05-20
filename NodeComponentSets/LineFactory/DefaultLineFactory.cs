using ArrowLineWithText;
using System.Windows.Media;

namespace NodeBase
{
    public class DefaultLineFactory : SSLineFactoryAbs
    {

        public override ArrowBase CreateCharacterLine()
        {
            // todo:添加线的具体描述
            ArrowBase arrowLineWithText = new ArrowLineWithText.ArrowLineWithText();
            arrowLineWithText.Stroke = Brushes.CadetBlue;
            arrowLineWithText.StrokeThickness = 0.3;
            arrowLineWithText.ArrowLength = 3;
            
            return arrowLineWithText;
        }

        public override ArrowBase CreateEventLine()
        {
            // todo:添加线的具体描述
            ArrowBase arrowLineWithText = new ArrowLineWithText.ArrowLineWithText();

            return arrowLineWithText;
        }
    }
}
