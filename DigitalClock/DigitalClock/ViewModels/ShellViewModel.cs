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
        public ShellViewModel()
        {
            ActiveItem = new WorldClocksViewModel();
        }

        public void LoadWordlClocks()
        {
            ActiveItem = new WorldClocksViewModel();
        }
        public void LoadTimer()
        {
            ActiveItem = new TimerViewModel();
        }
    }
}

