using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClock.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private WorldClocksViewModel _clockView = new WorldClocksViewModel();
        private TimerViewModel _timerView = new TimerViewModel();
        private StopWatchViewModel _stopWatchView = new StopWatchViewModel();
        private AlarmViewModel _alarmView = new AlarmViewModel();

        public ShellViewModel()
        {
            ActiveItem = _clockView;
        }

        public void LoadWordlClocks()
        {
            ActiveItem = _clockView;
        }
        public void LoadAlarm()
        {
            ActiveItem = _alarmView;
        }
        public void LoadStopWatch()
        {
            ActiveItem = _stopWatchView;

        }
        public void LoadTimer()
        {
            ActiveItem = _timerView;

        }
    }
}

