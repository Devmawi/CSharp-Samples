// See https://aka.ms/new-console-template for more information
using Basics.DataSets;
using Basics.DataSets.DemoDataSetTableAdapters;
using System.Data.SqlClient;
using static Basics.DataSets.DemoDataSet;
using static System.Console;

Console.WriteLine("Fill DataSet!");

var ds = new DemoDataSet();
var sampleAdapter = new SampleTableAdapter();

var sqlConnectionStringBuilder = new SqlConnectionStringBuilder("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=.\\Demo1.mdf;Integrated Security=True;Connect Timeout=30");
sqlConnectionStringBuilder.AttachDBFilename = Path.Combine(AppContext.BaseDirectory,"Demo1.mdf");
sampleAdapter.Connection = new System.Data.SqlClient.SqlConnection(sqlConnectionStringBuilder.ConnectionString);

// Add new Row https://docs.microsoft.com/en-us/visualstudio/data-tools/insert-new-records-into-a-database?view=vs-2022
var row = ds.Sample.NewSampleRow();
row.Value = 3;
row.DateTime = DateTime.Now;
ds.Sample.AddSampleRow(row);

sampleAdapter.Update(ds.Sample);
sampleAdapter.Fill(ds.Sample);

var selectedRow = ds.Sample.Select("Value=3").First();
selectedRow.BeginEdit();
selectedRow["Value"] = 7;
selectedRow.EndEdit();

sampleAdapter.Update(ds.Sample);
sampleAdapter.Fill(ds.Sample);

// https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/dataset-datatable-dataview/loading-dataset-schema-information-from-xml
ds.WriteXml("Data.xml", System.Data.XmlWriteMode.WriteSchema);
ds = new DemoDataSet();
ds.ReadXml("Data.xml");

foreach (var item in ds.Sample.ToArray())
{
    WriteLine($"{item.Value}, {item.DateTime}");
    item.Delete();
    //ds.Sample.RemoveSampleRow(item);
}

sampleAdapter.Update(ds);



//ds.Sample.AcceptChanges();

//sampleAdapter.Insert(2, DateTime.Now);
//sampleAdapter.Fill(ds.Sample);

//foreach (var item in ds.Sample)
//{
//    WriteLine($"{item.Value}, {item.DateTime}");
//}
