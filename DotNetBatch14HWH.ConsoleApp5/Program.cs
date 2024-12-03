using DotNetBatch14HWH.ConsoleApp5.AdoDotNet;
using DotNetBatch14HWH.ConsoleApp5.Dapper;
using DotNetBatch14HWH.ConsoleApp5.EFCore;

namespace DotNetBatch14HWH.ConsoleApp5;

internal class Program
{
    static void Main(string[] args)
    {
        //AdoDotNetExample ad = new AdoDotNetExample();
        //ad.Read();
        //ad.Edit("e521605b-8acc-4980-bd12-b8fc58b3279f");
        //ad.Create("yy", "uu", "oo");
        //ad.Update("e521605b-8acc-4980-bd12-b8fc58b3279f", "aa", "Aa", "aa");
        //ad.Delete("F33C4DA9-8437-46C4-BAEA-4A8DB900325A");

        //EFCoreExample ef = new EFCoreExample();
        //ef.Read();
        //ef.Edit("e521605b-8acc-4980-bd12-b8fc58b3279f");
        //ef.Create("yy", "uu", "oo");
        //ef.Update("F33C4DA9-8437-46C4-BAEA-4A8DB900325A", "aa", "Aa", "aa");
        //ef.Delete("e521605b-8acc-4980-bd12-b8fc58b3279f");

        DapperExample dp = new DapperExample();
        dp.Read();
        dp.Edit("06B32084-69FD-43DF-9232-4C570A41C8E9");
        dp.Create("yy", "uu", "oo");
        dp.Update("06B32084-69FD-43DF-9232-4C570A41C8E9", "aa", "Aa", "aa");
        dp.Delete("ff9dde8b-d328-4626-8a49-99d79e821614");

        Console.ReadLine();
    }
}
