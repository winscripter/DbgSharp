Use the `Interpreter` class found in the `DbgSharp` namespace to interpret C# scripts.

# Interpreter()
Default constructor. Takes no parameters.

# void Interpret(String)
Interprets the code. Previous classes, variables, methods, etc, also apply.

#### Parameters:
1. Input code (type `String`)

# void InterpretAsync(String)
Pretty much the same as Interpret(String). May not differ because the method itself is not asynchronous.

#### Parameters:
1. Input code (type `String`)

# Example
```cs
var interpreter = new Interpreter();
interpreter.Interpret("int x = 45;");
interpreter.Interpret("System.Console.WriteLine(x);"); // outputs 45
interpreter.Interpret("x++;");
interpreter.Interpret("System.Console.WriteLine(x);"); // outputs 46
```
