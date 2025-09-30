local test = {}

test.class_name = "LuaTest"
test.extends = Control
test.testValue = export(100)

function test:_ready()
    print("test", self.position, self.testValue)
end

function test:_process(delta)
    --print(delta)
end

return test