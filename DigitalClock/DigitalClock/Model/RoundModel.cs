using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace DigitalClock.Model
{
    public class RoundModel : PropertyChangedBase
    {
        public int Id { get; set; }
        public string RoundNumber { get; set; }
        public string Time { get; set; }

        private string _color;

        public string Color
        {
            get { return _color; }
            set 
            { 
                _color = value;
                NotifyOfPropertyChange(() => Color);
            }
        }


        public TimeSpan RoundTime { get; set; }
    }
}
