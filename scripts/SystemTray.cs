namespace GUITest.scripts;

public partial class SystemTray : StatusIndicator
{
    public override void _Ready()
    {
        // GetTree().Win
        // GetTree().SetAutoAcceptQuit(false);
    }

    private void OnPressed(int mouseButton, Vector2I mousePosition)
    {
        var type = (MouseButton)mouseButton;
        GD.Print($"Pressed {mouseButton}, {type}");
        if (type != MouseButton.Left) return;
        DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
        // GetTree().GetRoot().Show();
        GetTree().GetRoot().GetNode<Window>("Window").Show();
    }
}