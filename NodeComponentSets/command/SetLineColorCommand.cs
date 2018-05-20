
using System.Windows.Media;

namespace NodeBase
{
    public class SetLineColorCommand : ISSCommand.ISSCommand
    {
        private ArrowBase _line = null;

        /// <summary>
        /// 存储旧的颜色
        /// </summary>
        private Brush _oldColor = null;

        /// <summary>
        /// 存储新的颜色
        /// </summary>
        private Brush _newColor = null;

        public SetLineColorCommand(ArrowBase line, Brush newColor)
        {
            this._line = line;
            this._newColor = newColor;
        }
        public void Execute()
        {

            this._oldColor = this._line.Stroke;

            this._line.Stroke = this._newColor;
        }

        public void Undo()
        {
            this._line.Stroke = this._oldColor;
        }
    }
}
