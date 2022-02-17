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

        public ShellViewModel()
        {
            ActiveItem = _clockView;
        }

        public void LoadWordlClocks()
        {
            ActiveItem = _clockView;
        }
        public void LoadTimer()
        {



        }
    }
}

