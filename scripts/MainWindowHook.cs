namespace GUITest.scripts;

public partial class MainWindowHook : Node
{
    public override void _Ready()
    {
        GetTree().AutoAcceptQuit = false;
        GetTree().GetRoot().CloseRequested += OnCloseRequested;
    }

    private void OnCloseRequested()
    {
        GetTree().GetRoot().SetMode(Window.ModeEnum.Minimized);
    }
}