extends Control

var lua = LuaState.new()

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	lua.open_libraries()
	
	var result = lua.do_string("return 'Hello from lua!'")
	
	if result is LuaError:
		printerr("Error in Lua code: ", result)
	else:
		print(result, " ", type_string(typeof(result)))

func call_from_other_test(test_value: String) -> String:
	print(test_value)
	return test_value