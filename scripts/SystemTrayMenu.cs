namespace GUITest.scripts;

public partial class SystemTrayMenu : PopupMenu
{
	public override void _Ready()
	{
	}

	private void OnIdPressed(int id)
	{
		GD.Print($"Pressed {id}");
		if (id != 3) return;
		GetTree().Quit();
	}
}
