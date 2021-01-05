using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace trades
{
    public class Trade
    {
        public string Num {get;}
        public DateTime Time {get;}
        public string Board {get;}
        public string Code {get;}
        public double Price {get; set;}
        public Int64 Volume {get;}
        public double Accruedint {get;}
        public double Yield {get;}
        public double Value {get;}

        public Trade(string Line)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            provider.NumberGroupSeparator = ",";

            string[] Params = Line.Split();
            Num = Params[0];
            Time = DateTime.ParseExact(Params[1], "HHmmss", System.Globalization.CultureInfo.InvariantCulture);
            Board = Params[2];
            Code = Params[3];
            Price = Convert.ToDouble(Params[4], provider);
            Volume = Convert.ToInt64(Params[5]);
            Accruedint = Convert.ToDouble(Params[6], provider);
            Yield = Convert.ToDouble(Params[7], provider);
            Value = Convert.ToDouble(Params[8], provider);
        }

    }
}
