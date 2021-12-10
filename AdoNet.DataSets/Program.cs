// See https://aka.ms/new-console-template for more information
using AdoNet.DataSets;
using AdoNet.DataSets.DemoDataSetTableAdapters;
using System.Data.SqlClient;
using static System.Console;

Console.WriteLine("Welcome to ADO.NET.DataSet!");

var sqlConnectionStringBuilder = new SqlConnectionStringBuilder("Data Source=(LocalDB)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30");
sqlConnectionStringBuilder.AttachDBFilename = Path.Combine(AppContext.BaseDirectory,"Demo1.mdf");
 
var ds = new DemoDataSet();
var sampleAdapter = new SampleTableAdapter()
{
    Connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString)
};

// Add new Row https://docs.microsoft.com/en-us/visualstudio/data-tools/insert-new-records-into-a-database?view=vs-2022
var row = ds.Sample.NewSampleRow();
row.Value = 3;
row.DateTime = DateTime.Now;
// sampleAdapter.Insert2, DateTime.Now);
ds.Sample.AddSampleRow(row);

// https://docs.microsoft.com/en-us/visualstudio/data-tools/update-data-by-using-a-tableadapter?view=vs-2022
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

var rows = ds.Sample.ToArray();
foreach (var item in rows)
{
    WriteLine($"{item.Value}, {item.DateTime}");
    item.Delete();
    //ds.Sample.RemoveSampleRow(item);
}

sampleAdapter.Update(ds);