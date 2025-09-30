namespace GUITest.scripts;

public partial class SystemTray : StatusIndicator
{
    private const string NodePath = "Window";

    private void OnPressed(int mouseButton, Vector2I mousePosition)
    {
        var type = (MouseButton)mouseButton;
        if (type != MouseButton.Left) return;
        DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
        var hasWindow = GetTree().GetRoot().HasNode(NodePath);

        if (hasWindow)
            GetTree().GetRoot().GetNode<Window>(NodePath).Show();
        else
            GetTree().GetRoot().Show();
    }
}