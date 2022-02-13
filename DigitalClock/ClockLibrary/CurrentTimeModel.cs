using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockLibrary
{
    public class CurrentTimeModel
    {
        public string CurrentTime { get; set; }

        public async Task GetCurrentTimeAsync()
        {
            CurrentTime = DateTime.Now.ToString("HH:mm:ss");
            await Task.Delay(1000);
        }

        public async Task UpdateTimeAsync()
        {
            await GetCurrentTimeAsync();
        }
    }
}
