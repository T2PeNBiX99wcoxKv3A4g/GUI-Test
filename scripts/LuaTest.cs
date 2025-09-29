using GUITest.scripts.Proxy;

namespace GUITest.scripts;

public partial class LuaTest : Control
{
    public override void _Ready()
    {
        var lua = new LuaState();
        GD.Print(lua, " ", lua.GetType());
        lua.OpenLibraries();
        GD.Print("1");
        var result = lua.DoString("return 'Hello from lua!'");
        GD.Print("2 ", result);
    }
}