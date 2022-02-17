using Caliburn.Micro;
using DigitalClock.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DigitalClock.ViewModels
{
    class WorldClocksViewModel : Screen
    {
        private BindableCollection<ClockModel> _clocks = new BindableCollection<ClockModel>();
        private TimeZoneInfo _timeZone = TimeZoneInfo.Local;
        private BindableCollection<TimeZoneJsonModel> _timeZoneList = new BindableCollection<TimeZoneJsonModel>();


        private int _localTimeDiff = TimeZoneInfo.Local.BaseUtcOffset.Hours;
        private bool _addClockFormIsVisible = false;
        private bool _worldClockIsVisible = true;

        private readonly string _path = "TimeZone.json";


        public bool WordlClockIsVisible 
        {
            get { return _worldClockIsVisible; }
            set 
            { 
                _worldClockIsVisible = value;
                NotifyOfPropertyChange(() => WordlClockIsVisible);
            }
        }


        public bool AddClockFormIsVisible
        {
            get { return _addClockFormIsVisible; }
            set 
            {
                _addClockFormIsVisible = value;
                NotifyOfPropertyChange(() => AddClockFormIsVisible);
            }
        }

        public BindableCollection<ClockModel> Clocks
        {
            get { return _clocks; }
            set 
            { 
                _clocks = value;
                NotifyOfPropertyChange(() => Clocks);
            }
        }

        public BindableCollection<TimeZoneJsonModel> TimeZoneList
        {
            get { return _timeZoneList; }
            set
            {
                _timeZoneList = value;
                NotifyOfPropertyChange(() => TimeZoneList);
            }
        }

        public WorldClocksViewModel()
        {
            DispatcherTimer timer = new DispatcherTimer();

            ClockModel Warszawa = new ClockModel();
            Warszawa.City = "Warszawa";

            Warszawa.SetDate(_localTimeDiff);
            Warszawa.SetTime();

            Clocks.Add(Warszawa);

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (var item in Clocks)
            {
                item.SetTime();
            }
        }

        public void AddNewClock()
        {
            InitializeData();

            AddClockFormIsVisible = !AddClockFormIsVisible;
            WordlClockIsVisible = !AddClockFormIsVisible;
        }

        public void HideTimeZoneList()
        {
            AddClockFormIsVisible = !AddClockFormIsVisible;
            WordlClockIsVisible = !AddClockFormIsVisible;
        }

        public void InitializeData()
        {
            if(TimeZoneList.Count == 0)
                TimeZoneList = JsonConvert.DeserializeObject<BindableCollection<TimeZoneJsonModel>>(File.ReadAllText(_path));
        }

    }
}
