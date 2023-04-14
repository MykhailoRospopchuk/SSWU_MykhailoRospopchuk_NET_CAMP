
using System.Globalization;

namespace exercise_3
{
    internal static class View
    {
        public static void PrintFormatedRecord(EnergyRecord r)
        {
            string date_1 = r.MeasurDate1 == default ? "" : r.MeasurDate1.ToString("dd.MM.yyyy");
            string date_2 = r.MeasurDate2 == default ? "" : r.MeasurDate2.ToString("dd.MM.yyyy");
            string date_3 = r.MeasurDate3 == default ? "" : r.MeasurDate3.ToString("dd.MM.yyyy");
            
            string output = $"| {r.Id,-3} | {r.Surname,-15} | {r.IncomMonth1,7} | {r.IncomMonth2,7} | {r.IncomMonth3,7} | {date_1,-10} | {date_2,-10} | {date_3,-10} | {r.GetTimeSpend(),11:0.00} | {r.SumDept(),11:C}|";
            Console.WriteLine(output);
        }

        public static void PrintHeadRecord(EnergyQuarter q)
        {
            List<string> month = new List<string>();
            month = q.Month;
            string quarter = q.ToString();
            string head_table = $"|{"Flat",-3} | {"Surname",-15} | {"Consume",-7} | {"Consume",-7} | {"Consume"} | {month[0],-10} | {month[1],-10} | {month[2],-10} | {"Last record",-11} | {"Total debt",-11}|";
            Console.WriteLine(quarter);
            Console.WriteLine(head_table);
            Console.WriteLine(new string('-', head_table.Length));
        }
    }
}
