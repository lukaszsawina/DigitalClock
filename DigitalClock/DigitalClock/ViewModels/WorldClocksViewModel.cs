﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DigitalClock.ViewModels
{
    class WorldClocksViewModel : Conductor<object>
    {
        private BindableCollection<ClockModel> _clocks = new BindableCollection<ClockModel>();
        private TimeZoneInfo _timeZone = TimeZoneInfo.Local; //Czy to jest na pewno potrzebne?
        private int _localTimeDiff = TimeZoneInfo.Local.BaseUtcOffset.Hours;

        public BindableCollection<ClockModel> Clocks
        {
            get { return _clocks; }
            set 
            { 
                _clocks = value;
                NotifyOfPropertyChange(() => Clocks);
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
            ClockModel New = new ClockModel("Central America Standard Time");
            New.City = "Warszawa";
            New.SetDate(_localTimeDiff);
            New.SetTime();
            Clocks.Add(New);

        }
    }
}