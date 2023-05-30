using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedualProcessOs.Bl
{
    interface IShcedualProcess
    {
        public List<Processes> MainProcess { get; set; }
        public List<Processes> WaitingProcess { get; set; }
        public List<Processes> EndedProcess { get; set; }
        public Processes IncomingProcess(Processes currentProcess, int timeLineIndex);
        public Processes IncomingProcess();
        public Processes IncomingQueue(Processes currentProcess);
    }
}
