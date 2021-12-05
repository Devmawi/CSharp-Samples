global using static System.Console;

WriteLine("What's new in C# version 9!");

// https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#tuple-patterns
var (p, x, y, z) = (1, 2, 1, 2);

var condition = (p, x) == (y, z);
WriteLine($"condition: {condition}");

ReadLine();