using ISSCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace SSLine.Commands
{
    public class SetLineColorCommand : ISSCommand.ISSCommand
    {
        private ArrowLine _line = null;

        /// <summary>
        /// 存储旧的颜色
        /// </summary>
        private Brush _oldColor = null;

        /// <summary>
        /// 存储新的颜色
        /// </summary>
        private Brush _newColor = null;

        public SetLineColorCommand(ArrowLine line, Brush newColor)
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
