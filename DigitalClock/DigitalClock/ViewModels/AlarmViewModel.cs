using Caliburn.Micro;
using DigitalClock.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClock.ViewModels
{
    public class AlarmViewModel : Screen
    {
        private BindableCollection<AlarmModel> _alarms = new BindableCollection<AlarmModel>();
        private bool _alarmListIsVisible = true;
        private bool _alarmAddIsVisible = false;
        private string _newAlarmClock = "00:00";

        public string NewAlarmClock 
        {
            get { return _newAlarmClock; }
            set 
            { 
                _newAlarmClock = value;
                NotifyOfPropertyChange(() => NewAlarmClock);
            }
        }


        public bool AlarmAddIsVisible
        {
            get { return _alarmAddIsVisible; }
            set 
            { 
                _alarmAddIsVisible = value;
                NotifyOfPropertyChange(() => AlarmAddIsVisible);
            }
        }


        public bool AlarmListIsVisible
        {
            get { return _alarmListIsVisible; }
            set 
            { 
                _alarmListIsVisible = value;
                NotifyOfPropertyChange(() => AlarmListIsVisible);
            }
        }


        public BindableCollection<AlarmModel> Alarms
        {
            get { return _alarms; }
            set 
            {
                _alarms = value;
                NotifyOfPropertyChange(() => Alarms);
            }
        }

        public void NewAlarm()
        {
            AlarmAddIsVisible = true;
            AlarmListIsVisible = false;
        }
        public void CloseNewAlarm()
        {
            AlarmAddIsVisible = false;
            AlarmListIsVisible = true;
        }

        public void AddNewAlarm()
        {
            AlarmModel newAlarm = new AlarmModel();

            newAlarm.time = NewAlarmClock;
            int newId = 1;
            if (Alarms.Count != 0)
                newId = Alarms.Max(x => x.Id) + 1;

            newAlarm.Id = newId;
            Alarms.Add(newAlarm);
            CloseNewAlarm();
        }

        public void AlarmOff(AlarmModel arg)
        {
            Alarms[arg.Id-1].isOn = !arg.isOn;
        }
    }
}
