global using static System.Console;
using WhatsNew.Version08;

WriteLine("What's new in C# version 8!");

// https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#static-local-functions
static bool CompareTuple((int,int) tuple1, (int, int) tuple2)
{
    return tuple1 == tuple2;
}

static IEnumerable<string> CreateList()
{
    // https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#using-declarations
    using var file = new StreamReader(".\\TEXT.txt");
    
    while (!file.EndOfStream)
    {
        yield return file.ReadLine() ?? "";
    }
}

// https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#switch-expressions
var value = 10;
var card = new Card
{
    Color = value switch
    {
        > 12 => Colors.Red,
        >= 10 => Colors.Yellow,
        < 10 and > 5 => Colors.Green,
        _ => Colors.Green
    }
};

// https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#tuple-patterns
(card.Text, card.Color) = value switch
{
    > 12 => ("ERROR", Colors.Red),
    >= 10 => ("WARNING", Colors.Yellow),
    < 10 and > 5 => ("OK", Colors.Green),
    _ => ("OK", Colors.Green)
};

var (p, x, y, z) = (1, 2, 1, 2);

var condition = CompareTuple((p, x), (y, z));
WriteLine($"condition: {condition}");

var list = CreateList();

WriteLine($"condition: {list.Count()}");

// https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#indices-and-ranges
var firstThree = list.ToArray()[0..3];
var last = firstThree[^1];

ReadLine();