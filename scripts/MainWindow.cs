namespace GUITest.scripts;

public partial class MainWindow : Window
{
    public override void _Ready()
    {
        GetTree().AutoAcceptQuit = false;
        GetTree().GetRoot().CloseRequested += OnCloseRequested2;
    }

    private void OnCloseRequested()
    {
        Hide();
    }
    
    private void OnCloseRequested2()
    {
        GD.Print("Close Requested");
        GetTree().GetRoot().SetMode(ModeEnum.Minimized);
    }
}