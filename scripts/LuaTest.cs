using GUITest.scripts.Proxy;

namespace GUITest.scripts;

public partial class LuaTest : Control
{
    public override void _Ready()
    {
        var lua = new LuaState();
        lua.OpenLibraries();
        var result = lua.DoString("return 'Hello from lua!'");
        var error = (LuaError?)result;

        if (error != null)
            GD.PrintErr("[Lua Error] ", error.Message);
        else
            GD.Print($"{result}");
    }
}