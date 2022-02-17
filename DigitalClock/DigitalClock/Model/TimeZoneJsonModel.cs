using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClock.Model
{
    public class TimeZoneJsonModel
    {
        private string _tZCode;
        private string _tZDesc;

        public string tZCode { get => _tZCode; set => _tZCode = value; }
        public string tZDesc { get => _tZDesc; set => _tZDesc = value; }
    }
}
