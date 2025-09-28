using Codartesien.SourceGenerators.SceneNodeResolver;
using Godot;

namespace GUITest.scripts;

public partial class ToggleButton : Control
{
	[SceneNode("../../../../../SideBarAnimPlayer")]
	private SideBarAnimPlayer? _animationPlayer;

	private void OnGuiInput(InputEvent @event)
	{
		if (@event is not InputEventMouseButton mouseEvent) return;
		if (mouseEvent.GetButtonIndex() != MouseButton.Left || !mouseEvent.IsPressed()) return;
		_animationPlayer?.Toggle();
	}
}
