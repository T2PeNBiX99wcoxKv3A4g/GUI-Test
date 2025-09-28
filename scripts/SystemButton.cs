using System;
using Codartesien.SourceGenerators.SceneNodeResolver;
using Godot;

namespace GUITest.scripts;

public partial class SystemButton : ColorRect
{
    public enum Types
    {
        Close,
        Maximize,
        Minimize
    }

    [Export] private Types _type = Types.Close;
    [Export] private Texture2D _icon = GD.Load<Texture2D>("res://icons/x.svg");
    [Export] private Color _hoverColor = Color.FromString("#363654", new Color(0.11f, 0.11f, 0.18f));
    private readonly Color _defaultColor = Color.FromString("#1e1e2e", new Color(0.11f, 0.11f, 0.18f));

    [SceneNode("Icon")] private TextureRect? _iconRect;

    public override void _Ready()
    {
        if (_iconRect == null) return;
        _iconRect.Texture = _icon;
    }

    private void OnGuiInput(InputEvent @event)
    {
        if (@event is not InputEventMouseButton mouseEvent) return;
        if (mouseEvent.IsPressed() || mouseEvent.GetButtonIndex() != MouseButton.Left) return;
        switch (_type)
        {
            case Types.Close:
                GetTree().Quit();
                break;
            case Types.Maximize:
                var nowMode = DisplayServer.WindowGetMode();
                DisplayServer.WindowSetMode(nowMode == DisplayServer.WindowMode.Windowed
                    ? DisplayServer.WindowMode.Maximized
                    : DisplayServer.WindowMode.Windowed);
                break;
            case Types.Minimize:
                DisplayServer.WindowSetMode(DisplayServer.WindowMode.Minimized);
                break;
            default:
                throw new IndexOutOfRangeException($"Unknown type of {_type}");
        }
    }

    private void OnMouseEntered()
    {
        Color = _hoverColor;
    }

    private void OnMouseExited()
    {
        Color = _defaultColor;
    }
}