// See https://aka.ms/new-console-template for more information
// File scoped name space
using WhatsNew.Version10;

Console.WriteLine("What's new in C# 10");

var currentDateTime = DateTime.UtcNow;
var r = new RecordStruct { Value=1, DateTime= currentDateTime };
var r2 = r with { }; // Copy
var r3 = new RecordStruct { Value = 1, DateTime = currentDateTime }; // Only same values

var recordsAreEqual = r == r2 && r == r3;
Console.WriteLine($"recordsAreEqual: {recordsAreEqual}");

var rc = new RecordClass { Value = 1, DateTime = currentDateTime };
var rc2 = rc with { }; // Copy
var rc3 =  new InheritedRecordClass { Value = 1, DateTime = currentDateTime }; // Only same values

// https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10#assignment-and-declaration-in-same-deconstruction
RecordClass rc4 = new();
(rc4.Value, rc4.DateTime) = rc3; // Unpacking/ De constructing

var recordClassInstancesAreEqual = rc == rc2 && rc.Equals(rc4);
Console.WriteLine($"recordClassInstancesAreEqual: {recordClassInstancesAreEqual}");

var (value, time) = rc4;
Console.WriteLine($"Value: {value}, Time: {time}");

var hasValueOne = rc3 is not RecordClass { Value: > 2 and < -1 }; // Extended property patterns
Console.WriteLine($"hasValueOne: {hasValueOne}");

var n = 20;
var nIsInRange = n is > 10 and < 21;
Console.WriteLine($"nIsInRange: {nIsInRange}");






