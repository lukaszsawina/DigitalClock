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
        IWindowManager manager = new WindowManager();
        private string _timer = "00:00:00";
        private bool _timeSelectIsVisible = true;
        private bool _timeLeftIsVisible = false;
        private bool _startButtonIsVisible = true;
        private bool _stopButtonIsVisible = false;
        private bool _returnButtonIsVisible = false;
        private bool _returnButtonEnable = false;


        private int _progress;
        DispatcherTimer timer = new DispatcherTimer();

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
        public bool StartButtonIsVisible
        {
            get { return _startButtonIsVisible; }
            set
            {
                _startButtonIsVisible = value;
                NotifyOfPropertyChange(() => StartButtonIsVisible);
            }
        }
        public bool StopButtonIsVisible
        {
            get { return _stopButtonIsVisible; }
            set
            {
                _stopButtonIsVisible = value;
                NotifyOfPropertyChange(() => StopButtonIsVisible);
            }
        }
        public bool ReturnButtonIsVisible
        {
            get { return _returnButtonIsVisible; }
            set
            {
                _returnButtonIsVisible = value;
                NotifyOfPropertyChange(() => ReturnButtonIsVisible);
            }
        }
        public bool ReturnButtonEnable
        {
            get { return _returnButtonEnable; }
            set
            {
                _returnButtonEnable = value;
                NotifyOfPropertyChange(() => ReturnButtonEnable);
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

            StartButtonIsVisible = !StartButtonIsVisible;
            StopButtonIsVisible = !StopButtonIsVisible;
            ReturnButtonEnable = !ReturnButtonEnable;


            Time = DateTime.ParseExact(Timer, "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            int hours = Int32.Parse(Timer.ToString().Substring(0,2));
            int min = Int32.Parse(Timer.ToString().Substring(3, 2));
            int sec = Int32.Parse(Timer.ToString().Substring(6, 2));


            TimeWhenStop = DateTime.Now.AddMinutes(min).AddHours(hours).AddSeconds(sec+1);

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Time_Tick;
            timer.Start();
        }

        public void Time_Tick(object sender, EventArgs args)
        {
            TimeSpan value = TimeWhenStop.Subtract(DateTime.Now);
            Timer = value.ToString(@"hh\:mm\:ss");

            if (value.ToString(@"hh\:mm\:ss").Equals("00:00:00"))
            {
                manager.ShowWindowAsync(new TimerAlertViewModel(), null, null);
                TimeSelectIsVisible = !TimeSelectIsVisible;
                TimeLeftIsVisible = !TimeLeftIsVisible;
                timer.Stop();

                StartButtonIsVisible = !StartButtonIsVisible;
                StopButtonIsVisible = !StopButtonIsVisible;
            }

        }

        public void StopTimer()
        {
            timer.Stop();

            ReturnButtonIsVisible = !ReturnButtonIsVisible;
            StopButtonIsVisible = !StopButtonIsVisible;
        }

        public void ReturnTimer()
        {
            Time = DateTime.ParseExact(Timer, "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            int hours = Int32.Parse(Timer.ToString().Substring(0, 2));
            int min = Int32.Parse(Timer.ToString().Substring(3, 2));
            int sec = Int32.Parse(Timer.ToString().Substring(6, 2));


            TimeWhenStop = DateTime.Now.AddMinutes(min).AddHours(hours).AddSeconds(sec + 1);

            timer.Start();

            ReturnButtonIsVisible = !ReturnButtonIsVisible;
            StopButtonIsVisible = !StopButtonIsVisible;

        }

        public void Reset()
        {
            timer.Stop();
            Timer = "00:00:00";
            TimeSelectIsVisible = !TimeSelectIsVisible;
            TimeLeftIsVisible = !TimeLeftIsVisible;

            StartButtonIsVisible = true;
            StopButtonIsVisible = false;
            ReturnButtonIsVisible = false;
            ReturnButtonEnable = false;

        }
    }
}
