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
        GD.Print($"Type: {result} {result.GetType()}");

        var test = LuaScript.Load("res://scripts/Test.lua");

        GD.Print($"test: {test} {test?.GetType()}");

        if (test == null) return;

        var obj = (GodotObject?)test.New();
        GD.Print($"obj: {obj}");

        var ret = obj?.Call("callFromOtherTest", "Test value from C# in lua");
        GD.Print($"ret: {ret}");

        var test2 = GD.Load<GDScript?>("res://scripts/LuaTest.gd");
        GD.Print($"test2: {test2}");

        var obj2 = (GodotObject?)test2?.New();
        GD.Print($"obj2: {obj2}");
        var ret2 = obj2?.Call("call_from_other_test", "Test value from C# in gdscript");
        GD.Print($"ret2: {ret2}");
    }
}