// See https://aka.ms/new-console-template for more information
using DotNetBatch14HWH.ConsoleApp4.AdoDotNetExamples;
using DotNetBatch14HWH.ConsoleApp4.DapperExamples;
using DotNetBatch14HWH.ConsoleApp4.EFCoreExamples;

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
//dp.Update("77422E59-84E8-4F6C-89BA-18F212D29D45", "Rain", "Rain", "Rain");
//dp.Delete("B0F09B8C-8C63-43EE-99F5-0ABC234E38FC");

EFCoreExample ef = new EFCoreExample();
ef.Read();
ef.Edit("5E22F29D-1919-4336-A408-10DD0246F595");
ef.Create("ee", "ee", "ee");
ef.Update("5E22F29D-1919-4336-A408-10DD0246F595", "a", "a", "a");
ef.Delete("5E22F29D-1919-4336-A408-10DD0246F595");