using GUITest.scripts.Proxy;

namespace GUITest.scripts;

public partial class LuaTest : Control
{
    private readonly LuaState _lua = new();

    public override void _Ready()
    {
        _lua.OpenLibraries();
        var result = _lua.DoString("return 'Hello from lua!'");
        var error = (LuaError?)result;

        if (error != null)
            GD.PrintErr("[Lua Error] ", error.Message);
        else
            GD.Print($"{result}");
    }
}