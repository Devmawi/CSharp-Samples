// See https://aka.ms/new-console-template for more information
using Basics.DataSets;
using Basics.DataSets.DemoDataSetTableAdapters;
using static System.Console;

Console.WriteLine("Fill DataSet!");

var ds = new DemoDataSet();
var sampleAdapter = new SampleTableAdapter();
sampleAdapter.Insert(2, DateTime.Now);
sampleAdapter.Fill(ds.Sample);

foreach (var item in ds.Sample)
{
    WriteLine($"{item.Value}, {item.DateTime}");
}
