using NodeBase;

namespace LineCommandSet
{
    public class DeleteLineCommand : ISSCommand.ISSCommand
    {

        private SSLine.ArrowBase  _line = null;

        private InputComponent _inputComponent = null;

        private OutputComponent _outputComponent = null;

        public DeleteLineCommand(SSLine.ArrowBase line)
        {
            this._line = line;

            this._inputComponent = this._line.StartComponent as InputComponent;
            this._outputComponent = this._line.EndComponent as OutputComponent;

        }
        public void Execute()
        {
            this._outputComponent.LogoutComponent(this._inputComponent);
            this._outputComponent.MyShell.Process();
            this._inputComponent.RemoveNotifier(this._outputComponent);
            this._inputComponent.MyShell.Process();
            this._outputComponent.DeleteLineByInstance(this._line);
            this._inputComponent.DeleteLineByInstance(this._line);

            GlobalTracker.GlobalTracker tracker = GlobalTracker.GlobalTracker.GetInstance();
            tracker.GetNodeCanvas().Children.Remove(this._line);

        }

        public void Undo()
        {
            this._inputComponent.AddNewLine(this._line);
            this._outputComponent.AddNewLine(this._line);

            this._inputComponent.AddNotifier(this._outputComponent);
            this._outputComponent.RegiseterComponent(this._inputComponent);
            this._outputComponent.MyShell.Process();
            this._inputComponent.MyShell.Process();

            GlobalTracker.GlobalTracker tracker = GlobalTracker.GlobalTracker.GetInstance();
            tracker.GetNodeCanvas().Children.Add(this._line);
        }
    }
}
