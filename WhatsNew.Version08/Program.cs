global using static System.Console;
using WhatsNew.Version08;

WriteLine("What's new in C# version 8!");

// https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#static-local-functions
static bool CompareTuple((int,int) tuple1, (int, int) tuple2)
{
    return tuple1 == tuple2;
}

static IEnumerable<int> CreateList()
{
    foreach (var item in Enumerable.Range(0,10))
    {
        yield return item;
    }
}

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

(card.Text, card.Color) = value switch
{
    > 12 => ("ERROR", Colors.Red),
    >= 10 => ("WARNING", Colors.Yellow),
    < 10 and > 5 => ("OK", Colors.Green),
    _ => ("OK", Colors.Green)
};

// https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#tuple-patterns
var (p, x, y, z) = (1, 2, 1, 2);

var condition = CompareTuple((p, x), (y, z));
WriteLine($"condition: {condition}");

var list = CreateList();

WriteLine($"condition: {list.Count()}");

var firstThree = list.ToArray()[0..3];
var last = firstThree[^1];

ReadLine();