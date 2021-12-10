// See https://aka.ms/new-console-template for more information
using AdoNet.DataSets;
using AdoNet.DataSets.DemoDataSetTableAdapters;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
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

/*
    DbProviderFactory factory = SQLiteFactory.Instance;
    DbConnection connection = factory.CreateConnection();
    connection.ConnectionString = "Data Source=:memory:";

    using (connection)
    {
        // Create the select command.
        DbCommand command = factory.CreateCommand();
        command.CommandText = sampleAdapter.Adapter.SelectCommand.CommandText;
        command.Connection = connection;

        // Create the DbDataAdapter.
        DbDataAdapter adapter = factory.CreateDataAdapter();
        adapter.SelectCommand = command;

        DbCommand insertCommand = factory.CreateCommand();
        insertCommand.CommandText = sampleAdapter.Adapter.InsertCommand.CommandText;
        insertCommand.Connection = connection;

        adapter.InsertCommand = insertCommand;

        DbCommand updateCommand = factory.CreateCommand();
        updateCommand.CommandText = sampleAdapter.Adapter.InsertCommand.CommandText;
        updateCommand.Connection = connection;
        // Create the DbCommandBuilder.

        adapter.UpdateCommand = updateCommand;

        row = ds.Sample.NewSampleRow();
        row.Value = 3;
        row.DateTime = DateTime.Now;
        // sampleAdapter.Insert2, DateTime.Now);
        ds.Sample.AddSampleRow(row);

        // https://docs.microsoft.com/en-us/visualstudio/data-tools/update-data-by-using-a-tableadapter?view=vs-2022
        adapter.Update(ds.Sample);
    }
*/