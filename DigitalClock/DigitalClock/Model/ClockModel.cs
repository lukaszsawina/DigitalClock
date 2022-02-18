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
        public int Id { get; set; }
        private string _time;
        private TimeZoneInfo _timeZone;
        private DateTime _currentTime;
        public string TimeZoneString { get; set; }

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
            TimeZoneString = _timeZone.Id;

        }
        public ClockModel(string timeZone, int localTimeDiff, int id)
        {
            _timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            TimeZoneString = timeZone;
            _currentTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(timeZone));

            Id = id;

            SetDate(localTimeDiff);
        }


        public string City { get; set; }
        public string Date { get; set; }

        public void SetTime()
        {
            _currentTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(TimeZoneString));

            Time = _currentTime.ToString("HH:mm");
        }
        public void SetDate(int localTimeDiff)
        { 
            int timeDiff = 0;
            int deltaDay = 0;
            int delta;

            timeDiff = _timeZone.BaseUtcOffset.Hours;
            delta = timeDiff - localTimeDiff;

            deltaDay = Int32.Parse(_currentTime.ToString("dd")) - Int32.Parse(DateTime.Now.ToString("dd"));

            if(deltaDay > 0)
            {
                if (delta >= 0)
                    Date = $"Jutro: +{ delta.ToString() } GODZ.";
                else
                    Date = $"Jutro: { delta.ToString() } H";
            }
            else if(deltaDay < 0)
            {
                if (delta >= 0)
                    Date = $"Wczoraj: +{ delta.ToString() } GODZ.";
                else
                    Date = $"Wczoraj: { delta.ToString() } H";
            }
            else
            {
                if (delta >= 0)
                    Date = $"Dzisiaj: +{ delta.ToString() } GODZ.";
                else
                    Date = $"Dzisiaj: { delta.ToString() } H";
            }

        }
    }
}
