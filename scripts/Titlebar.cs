using Godot;

namespace GUITest.scripts;

public partial class Titlebar : Control
{
    private bool _following;
    private Vector2 _startPosition = Vector2.Zero;

    [Export] private bool _moveWindow;

    private void OnGuiInput(InputEvent @event)
    {
        if (!_moveWindow) return;
        if (@event is InputEventMouseButton mouseEvent)
        {
            if (mouseEvent.GetButtonIndex() == MouseButton.Left)
            {
                _following = mouseEvent.IsPressed();
                _startPosition = GetLocalMousePosition();
            }
        }

        if (!_following) return;
        var movePosition = (Vector2I)((GetLocalMousePosition() - _startPosition) / 32).Round();
        GetWindow().Position += movePosition * 2;
    }
}