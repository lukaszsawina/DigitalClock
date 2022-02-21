using Caliburn.Micro;
using DigitalClock.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DigitalClock.ViewModels
{
    public class StopWatchViewModel : Screen
    {

        private string _measure = "00:00,00";
        private DateTime _timeWhenStart;
        private DateTime _roundStart;
        private DispatcherTimer _stopWatch = new DispatcherTimer();
        private BindableCollection<RoundModel> _rounds = new BindableCollection<RoundModel>();

        public BindableCollection<RoundModel> Rounds
        {
            get { return _rounds; }
            set 
            { 
                _rounds = value;
                NotifyOfPropertyChange(() => Rounds);
            }
        }



        private bool _roundIsVisible = true;
        private bool _startButtonIsVisible = true;
        private bool _resetButtonIsVisible = false;
        private bool _stopButtonIsVisible = false;


        public bool StopButtonIsVisible
        {
            get { return _stopButtonIsVisible; }
            set 
            { 
                _stopButtonIsVisible = value;
                NotifyOfPropertyChange(() => StopButtonIsVisible);
            }
        }

        public bool ResetButtonIsVisible
        {
            get { return _resetButtonIsVisible; }
            set 
            { 
                _resetButtonIsVisible = value;
                NotifyOfPropertyChange(() => ResetButtonIsVisible);
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

        public bool RoundIsVisible
        {
            get { return _roundIsVisible; }
            set 
            { 
                _roundIsVisible = value;
                NotifyOfPropertyChange(() => RoundIsVisible);
            }
        }

        public string Measure
        {
            get { return _measure; }
            set 
            { 
                _measure = value;
                NotifyOfPropertyChange(() => Measure);
            }
        }

        public StopWatchViewModel()
        {
            _timeWhenStart = DateTime.Now;
            _stopWatch.Interval = TimeSpan.FromMilliseconds(10);
            _stopWatch.Tick += StopWatchCount;
        }

        private void StopWatchCount(object sender, EventArgs e)
        {
            TimeSpan value = DateTime.Now.Subtract(_timeWhenStart);

            Measure = value.ToString(@"mm\:ss\,ff");
        }

        public void StartMeasureTime()
        {
            _stopWatch.Start();
            _roundStart = DateTime.Now;
            _timeWhenStart = DateTime.Now;

            if (Measure.Equals("00:00,00"))
            {
                StartButtonIsVisible = !StartButtonIsVisible;
                StopButtonIsVisible = !StopButtonIsVisible;
            }
            else
            {
                StartButtonIsVisible = !StartButtonIsVisible;
                StopButtonIsVisible = !StopButtonIsVisible;
                ResetButtonIsVisible = !ResetButtonIsVisible;
            }

        }

        public void ResetMeasureTime()
        {
            Measure = "00:00,00";
            ResetButtonIsVisible = !ResetButtonIsVisible;
            Rounds.Clear();
        }

        public void AddRound()
        {
            RoundModel model = new RoundModel();
            int newId = 1;
            if (Rounds.Count != 0)
            {
                 newId = Rounds.Max(x => x.Id) + 1;
            }

            TimeSpan value = DateTime.Now.Subtract(_roundStart);

            model.Id = newId;
            model.RoundNumber = $"Runda { newId }";
            model.Time = Measure;
            model.RoundTime = value;
            model.Color = "#fff";

            Rounds.Insert(0,model);
            SetColorOfBestAndWorst();
            _roundStart = DateTime.Now;
        }

        public void StopMeasureTime()
        {
            _stopWatch.Stop();

            StartButtonIsVisible = !StartButtonIsVisible;
            StopButtonIsVisible = !StopButtonIsVisible;

            ResetButtonIsVisible = !ResetButtonIsVisible;

        }

        private void SetColorOfBestAndWorst()
        {
            foreach(var r in Rounds)
            {
                r.Color = "#fff";
            }

            Rounds.OrderByDescending(i => i.RoundTime).First().Color = "#ff0000";
            Rounds.OrderBy(i => i.RoundTime).First().Color = "#00e600";

        }
    }
}
