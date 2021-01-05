using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace trades
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Trade> Trades = new List<Trade>();
            using (StreamReader sr = new StreamReader("trades.txt", Encoding.Default))
            {
                string line;
                sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    Trades.Add(new Trade(line));
                }
            }
            var TradesDifference = Trades.Where(elem => elem.Board == "TQBR" || elem.Board == "FQBR")
                                      .GroupBy(elem => elem.Code)
                                      .Select(elem => new
                                      {
                                          Name = elem.Key,
                                          PriceDifference = elem.Last().Price - elem.First().Price,
                                          Percent = 100.0 * (elem.Last().Price - elem.First().Price)/elem.First().Price,
                                          SumValue = elem.Sum(el => el.Value),
                                      });
            var BestTrades = TradesDifference.OrderByDescending(elem => elem.PriceDifference).Take(10);
            Console.WriteLine("\n10 BestTreades:\nSECCODE   PRICEDIFFERENCE     DIFFERENCEPERCENT   TOTALSUMVALUE");
            foreach(var elem in BestTrades)
            {
                Console.WriteLine($"{elem.Name}     {elem.PriceDifference}      {elem.Percent}     {elem.SumValue}");
            }
            var WorstTrades = TradesDifference.OrderBy(elem => elem.PriceDifference).Take(10);
            Console.WriteLine("\n10 WorstTrades:\nSECCODE   PRICEDIFFERENCE     DIFFERENCEPERCENT   TOTALSUMVALUE");
            foreach(var elem in WorstTrades)
            {
                Console.WriteLine($"{elem.Name}     {elem.PriceDifference}      {elem.Percent}     {elem.SumValue}");
            }
        }
    }
}
