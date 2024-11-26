// See https://aka.ms/new-console-template for more information
using DotNetBatch14HWH.ConsoleApp3.AdoDotNetExamples;
using DotNetBatch14HWH.ConsoleApp3.DapperExamples;
using DotNetBatch14HWH.ConsoleApp3.EFCoreExamples;

Console.WriteLine("Hello, World!");

//AdoDotNetExample
//AdoDotNetExample ado = new AdoDotNetExample();
//ado.Read();
//ado.Edit("E42EB5C1-6598-49EF-A6A5-7652918882D4");
//ado.Create("Mee", "Mee", "Mee");
//ado.Update("E42EB5C1-6598-49EF-A6A5-7652918882D4", "Rain", "Rain", "Rain");
//ado.Delete("21D2B181-6F40-45AD-ADF1-FA102AD831E9");

//DapperExample dp = new DapperExample();
//dp.Read();
//dp.Edit("");
//dp.Create("Mee", "Mee", "Mee");
//dp.Update("5E22F29D-1919-4336-A408-10DD0246F595", "Rain", "Rain", "Rain");
//dp.Delete("E42EB5C1-6598-49EF-A6A5-7652918882D4");

EFCoreExample ef = new EFCoreExample();
ef.Read();
ef.Edit("5E22F29D-1919-4336-A408-10DD0246F595");
ef.Create("Mee", "Mee", "Mee");
ef.Update("5E22F29D-1919-4336-A408-10DD0246F595", "Rain", "Rain", "Rain");
ef.Delete("E42EB5C1-6598-49EF-A6A5-7652918882D4");


