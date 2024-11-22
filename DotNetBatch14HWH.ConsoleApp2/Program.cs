
using DotNetBatch14HWH.ConsoleApp2.AdoDotNetExamples;
using DotNetBatch14HWH.ConsoleApp2.DapperExamples;
using DotNetBatch14HWH.ConsoleApp2.EFCoreExamples;
using System.Runtime.Intrinsics.Arm;

Console.WriteLine("Hello, World!");


//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Edit("1");
//adoDotNetExample.Create("Hey", "Hey", "Hey");
//adoDotNetExample.Update("C62A3801-7B22-450C-BE76-FD9895D77344", "Hee", "Hee", "Hee");
//adoDotNetExample.Delete("1");

//DapperExample dp = new DapperExample();
//dp.Read();
//dp.Edit("C62A3801-7B22-450C-BE76-FD9895D77344");
//dp.Create("Hey", "Hey", "Hey");
//dp.Update("C62A3801-7B22-450C-BE76-FD9895D77344", "H", "H", "H");
//dp.Delete("C62A3801-7B22-450C-BE76-FD9895D77344");

EFCoreExample eFCoreExample = new EFCoreExample();
eFCoreExample.Read();
eFCoreExample.Edit("C62A3801-7B22-450C-BE76-FD9895D77344");
eFCoreExample.Create("Hey", "Hey", "Hey");
eFCoreExample.Update("C62A3801-7B22-450C-BE76-FD9895D77344", "H", "H", "H");
eFCoreExample.Delete("C62A3801-7B22-450C-BE76-FD9895D77344");