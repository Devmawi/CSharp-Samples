// See https://aka.ms/new-console-template for more information
global using WhatsNew.Version09;
global using static System.Console;

WriteLine("What's new in C# version 9!");

// Record type: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#record-types
var currentDateTime = DateTime.Now;
var r1 = new BaseRecord { Value = 1, DateTime= currentDateTime };
var rc2 = new ExtendedRecord { Value = 1, DateTime= currentDateTime };
var rc3 = r1 with { };
// r1.Value = 3; => Not allowed because of init setter
var recordsAreEqual = r1 == rc2;
WriteLine($"recordsAreEqual: {recordsAreEqual}");

recordsAreEqual = rc3 == r1;
WriteLine($"recordsAreEqual: {recordsAreEqual}");

new PartialClass().Hello();

ReadLine();
