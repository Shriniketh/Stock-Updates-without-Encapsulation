using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace stockprogramwithoutEncapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            var date = new List<DateTime>();

            var open = new List<decimal>();

            var high = new List<decimal>();

            var low = new List<decimal>();

            var close = new List<decimal>();

            var readData = File.ReadAllLines(args[0]);

            var realData = readData.Skip(1);

            foreach (var data in realData)
            {
                var stockData = data.Split(',');

                date.Add(DateTime.Parse(stockData[0], new CultureInfo("en-US", false)));

                open.Add(decimal.Parse(stockData[1]));
                 
                high.Add(decimal.Parse(stockData[2]));

                low.Add(decimal.Parse(stockData[3]));

                close.Add(decimal.Parse(stockData[4])); 
            }

            for (int i = 0; i < realData.Count() - 1; i++)
            {
                if (open[i] > high[i + 1] && close[i] < low[i + 1])
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Stock price went down on {0}", date[i].ToShortDateString());
                }

                if (open[i] < low[i + 1] && close[i] > high[i + 1])
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("Stock price went up on {0}", date[i].ToShortDateString());
                }
            }

            Console.ReadLine();
        }
    }
}
