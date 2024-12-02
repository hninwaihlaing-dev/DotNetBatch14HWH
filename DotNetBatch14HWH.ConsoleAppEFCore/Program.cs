// See https://aka.ms/new-console-template for more information
using DotNetBatch14HWH.ConsoleAppEFCore;

Console.WriteLine("Hello, World!");

EFCoreExample ef = new EFCoreExample();
ef.Create("Apple", 5000, 10);
ef.Read();
ef.Edit(1);
ef.Update(1, "Orange", 3000, 200);
ef.Delete(2);
Console.ReadLine();
