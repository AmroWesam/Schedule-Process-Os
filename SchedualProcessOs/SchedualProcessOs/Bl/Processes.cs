using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedualProcessOs.Bl
{
    class Processes
    {
        public string ProcessName { get; set; }
        public int ArivalTime { get; set; }
        int _BurstTime;
        public int BurstTime
        {
            get
            {
                return _BurstTime;
            }
            set
            {
                _BurstTime = value;
                RemainBurstTime = _BurstTime;
            }
        }
        public int RemainBurstTime { get; set; }
    }
}
