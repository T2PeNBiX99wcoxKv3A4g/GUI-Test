using Codartesien.SourceGenerators.SceneNodeResolver;
using Godot;

namespace GUITest.scripts;

public partial class SideBarAnimPlayer : AnimationPlayer
{
	private bool _isOpen;
	private const string AnimName = "sidebar_anim";

	[SceneNode("../HBoxContainer/Sidebar")] private Panel? _sideBar;

	public void Toggle()
	{
		if (_sideBar == null) return;
		var width = _sideBar.CustomMinimumSize.X;

		if (width < 70.1)
			Play(AnimName);
		else
			PlayBackwards(AnimName);
	}
}
