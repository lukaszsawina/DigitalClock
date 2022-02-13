using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClock
{
    public class Clock
    {
        public string City { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }

        public void SetTime()
        {
            Time = DateTime.Now.ToString("HH:mm");
        }
        public void SetDate()
        {
            Date = "Dzisiaj, +0 GODZ.";
        }

    }
}
