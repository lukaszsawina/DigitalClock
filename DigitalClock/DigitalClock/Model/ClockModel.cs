using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClock
{
    public class ClockModel : PropertyChangedBase
    {
        private string _time;
        private TimeZoneInfo _timeZone;
        private DateTime _currentTime;

        public string Time
        {
            get { return _time; }
            set 
            { 
                _time = value;
                NotifyOfPropertyChange(() => Time);
            }
        }

        public ClockModel()
        {
            _timeZone = TimeZoneInfo.Local;
            _currentTime = DateTime.Now;

        }
        public ClockModel(string timeZone)
        {
            _timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZone);


            _currentTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(timeZone));
        }


        public string City { get; set; }
        //public string Time { get; set; }
        public string Date { get; set; }

        public void SetTime()
        {
            Time = _currentTime.ToString("HH:mm");
        }
        public void SetDate(int localTimeDiff)
        { 
            int timeDiff = 0;
            int delta;

            timeDiff = _timeZone.BaseUtcOffset.Hours;
            delta = timeDiff - localTimeDiff;

            if (delta >= 0)
                Date = $"Dzisiaj: +{ delta.ToString() } GODZ.";
            else
                Date = $"Dzisiaj: { delta.ToString() } H";
        }

    }
}
