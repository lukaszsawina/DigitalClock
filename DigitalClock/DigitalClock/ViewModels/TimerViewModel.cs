using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DigitalClock.ViewModels
{
    class TimerViewModel : Screen
    {
        private string _timer = "00:00:00";
        private bool _timeSelectIsVisible = true;
        private bool _timeLeftIsVisible = false;
        private int _progress;

        public int Progress
        {
            get { return _progress; }
            set 
            { 
                _progress = value;
                NotifyOfPropertyChange(() => Progress);
            }
        }
        public DateTime Time { get; set; }
        public DateTime TimeWhenStop { get; set; }
        public bool TimeLeftIsVisible
        {
            get { return _timeLeftIsVisible; }
            set 
            { 
                _timeLeftIsVisible = value;
                NotifyOfPropertyChange(() => TimeLeftIsVisible);
            }
        }
        public bool TimeSelectIsVisible
        {
            get { return _timeSelectIsVisible; }
            set 
            { 
                _timeSelectIsVisible = value;
                NotifyOfPropertyChange(() => TimeSelectIsVisible);
            }
        }
        public string Timer
        {
            get { return _timer; }
            set 
            { 
                _timer = value;
                NotifyOfPropertyChange(() => Timer);
            }
        }

        public void StartTimer()
        {
            TimeSelectIsVisible = !TimeSelectIsVisible;
            TimeLeftIsVisible = !TimeLeftIsVisible;


            Time = DateTime.ParseExact(Timer, "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            int hours = Int32.Parse(Timer.ToString().Substring(0,2));
            int min = Int32.Parse(Timer.ToString().Substring(3, 2));
            int sec = Int32.Parse(Timer.ToString().Substring(6, 2));


            TimeWhenStop = DateTime.Now.AddMinutes(min).AddHours(hours).AddSeconds(sec+1);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Time_Tick;
            timer.Start();
        }

        public void Time_Tick(object sender, EventArgs args)
        {
            TimeSpan value = TimeWhenStop.Subtract(DateTime.Now);

            Timer = value.ToString(@"hh\:mm\:ss");
        }
    }
}
