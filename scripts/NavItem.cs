using Codartesien.SourceGenerators.SceneNodeResolver;
using Godot;

namespace GUITest.scripts;

public partial class NavItem : Control
{
    [SceneNode("BG")] private Panel? _bg;
    [SceneNode("Icon")] private TextureRect? _iconRect;
    [SceneNode("Name")] private Label? _nameLabel;

    private readonly StyleBox _defaultStyleBox = GD.Load<StyleBox>("res://styles/NavItem/Background.tres");
    [Export] private StyleBox _hoverStyleBox = GD.Load<StyleBox>("res://styles/NavItem/Hover.tres");
    [Export] private Texture2D _icon = GD.Load<Texture2D>("res://icons/home.svg");
    [Export] private string _name = string.Empty;

    internal TabContainer? TabContainer;
    internal int NavItemId = -1;
    internal StyleBox SelectedStyleBox = GD.Load<StyleBox>("res://styles/NavItem/Selected.tres");
    private bool _selected;

    private const string OverrideName = "panel";

    public override void _Ready()
    {
        _bg?.AddThemeStyleboxOverride(OverrideName, _defaultStyleBox);
        if (_iconRect != null)
            _iconRect.Texture = _icon;
        if (_nameLabel != null)
            _nameLabel.Text = _name;
    }

    private void OnBGMouseEntered()
    {
        if (_bg == null || _selected) return;
        _bg.AddThemeStyleboxOverride(OverrideName, _hoverStyleBox);
    }

    private void OnBGMouseExited()
    {
        if (_bg == null || _selected) return;
        _bg.AddThemeStyleboxOverride(OverrideName, _defaultStyleBox);
    }

    public void Selection()
    {
        if (_bg == null) return;
        _bg.AddThemeStyleboxOverride(OverrideName, SelectedStyleBox);
        _selected = true;
    }

    public void UnSelection()
    {
        if (_bg == null) return;
        _bg.AddThemeStyleboxOverride(OverrideName, _defaultStyleBox);
        _selected = false;
    }

    private void OnBGGuiInput(InputEvent @event)
    {
        if (@event is not InputEventMouseButton mouseEvent) return;
        if (mouseEvent.GetButtonIndex() != MouseButton.Left || !mouseEvent.IsPressed()) return;
        TabContainer?.SelectionNavItem(NavItemId);
    }
}