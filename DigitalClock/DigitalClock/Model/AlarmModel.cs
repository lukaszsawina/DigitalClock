using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace DigitalClock.Model
{
    public class AlarmModel : PropertyChangedBase
    {
        public int Id { get; set; }
        public string time { get; set; }

        private string _buttonText = "On";

        public string ButtonText
        {
            get { return _buttonText; }
            set 
            { 
                _buttonText = value;
                NotifyOfPropertyChange(() => ButtonText);
            }
        }

        private bool _isOn = true;

        public bool isOn
        {
            get { return _isOn; }
            set 
            { 
                _isOn = value;
                if(value)
                {
                    ButtonText = "On";
                }
                else
                {
                    ButtonText = "Off";
                }
                NotifyOfPropertyChange(() => isOn);
            }
        }


    }
}
