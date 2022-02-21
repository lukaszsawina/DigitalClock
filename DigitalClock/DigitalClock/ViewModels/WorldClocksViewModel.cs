using Caliburn.Micro;
using DigitalClock.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace DigitalClock.ViewModels
{
    class WorldClocksViewModel : Screen
    {
        private BindableCollection<ClockModel> _clocks = new BindableCollection<ClockModel>();
        private TimeZoneInfo _timeZone = TimeZoneInfo.Local;
        private BindableCollection<TimeZoneModel> _timeZoneList = new BindableCollection<TimeZoneModel>();

        private int _localTimeDiff = TimeZoneInfo.Local.BaseUtcOffset.Hours;
        private bool _addClockFormIsVisible = false;
        private bool _worldClockIsVisible = true;
        private bool _deleteButtonIsVisible = false;
        private bool _normalListIsVisible = true;

        public bool NormalListIsVisible
        {
            get { return _normalListIsVisible; }
            set 
            { 
                _normalListIsVisible = value;
                NotifyOfPropertyChange(() => NormalListIsVisible);
            }
        }


        private TimeZoneModel _selectedTimeZone;

        private readonly string _path = "TimeZone.json";

        public bool DeleteButtonIsVisible
        {
            get { return _deleteButtonIsVisible; }
            set
            {
                _deleteButtonIsVisible = value;
                NotifyOfPropertyChange(() => DeleteButtonIsVisible);
            }
        }


        public TimeZoneModel SelectedTimeZone
        {
            get { return _selectedTimeZone; }
            set 
            { 
                _selectedTimeZone = value; 
            }
        }

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

        public BindableCollection<TimeZoneModel> TimeZoneList
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
            Warszawa.Id = 1;
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
            {
                List<TimeZoneJsonModel> timeZoneJson = new List<TimeZoneJsonModel>();

                timeZoneJson = JsonConvert.DeserializeObject<List<TimeZoneJsonModel>>(File.ReadAllText(_path));
                List<TimeZoneModel> timeZoneList = new List<TimeZoneModel>();

                foreach (TimeZoneJsonModel model in timeZoneJson)
                {
                    string City = model.tZDesc;

                    string[] Citys = City.Split(new[] { ", " }, StringSplitOptions.None);

                    foreach (string city in Citys.Skip(1))
                    {
                        TimeZoneModel newTimeZone = new TimeZoneModel();
                        newTimeZone.Standard = model.tZCode;
                        newTimeZone.City = city;

                        timeZoneList.Add(newTimeZone);
                    }

                    
                }
                var list = timeZoneList.OrderBy(x => x.City).ToList();

                foreach(var timezone in list)
                {
                    TimeZoneList.Add(timezone);
                }

            }
        }

        public void AddClock(System.Windows.Controls.ListView args)
        {
            TimeZoneModel newClockModel = new TimeZoneModel();
            newClockModel = (TimeZoneModel)args.SelectedItem;

            int newId = 1;

            if (Clocks.Count() != 0)
                newId = Clocks.Max(x => x.Id) + 1;

            ClockModel newClock = new ClockModel(newClockModel.Standard, _localTimeDiff, newId);
            newClock.City = newClockModel.City;

            Clocks.Add(newClock);

            AddClockFormIsVisible = !AddClockFormIsVisible;
            WordlClockIsVisible = !AddClockFormIsVisible;
        }

        public void EditClock()
        {
            DeleteButtonIsVisible = !DeleteButtonIsVisible;
            NormalListIsVisible = !NormalListIsVisible;
        }

        public void DeleteClock(ClockModel e)
        {
            Clocks.Remove(e);

            if (Clocks.Count == 0)
                EditClock();
        }
    }
}
