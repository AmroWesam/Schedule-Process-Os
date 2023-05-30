using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedualProcessOs.Bl
{
    class ShortestProcess : IShcedualProcess
    {
        public ShortestProcess()
        {
            MainProcess = new List<Processes>();
            WaitingProcess = new List<Processes>();
            EndedProcess = new List<Processes>();
        }
        public ShortestProcess(List<Processes> mainprocess)
        {
            MainProcess = mainprocess;
            WaitingProcess = new List<Processes>();
            EndedProcess = new List<Processes>();
        }
        public List<Processes> MainProcess { get; set; }
        public List<Processes> WaitingProcess { get; set; }
        public List<Processes> EndedProcess { get; set; }
        public Processes IncomingProcess(Processes currentProcess, int timeLineIndex)
        {

            Processes myProcess = MainProcess.Where(a => a.ArivalTime == timeLineIndex).FirstOrDefault();
            if (myProcess == null)
                return currentProcess;
            else
            {
                if (currentProcess == null || currentProcess.RemainBurstTime<=0)
                    return myProcess;
                if (currentProcess.RemainBurstTime< myProcess.RemainBurstTime)
                {
                    WaitingProcess.Add(myProcess);
                    return currentProcess;
                }
                else
                {
                    WaitingProcess.Add(currentProcess);
                    return myProcess;
                }
            }
        }

        public Processes IncomingProcess()
        {
            return MainProcess.FirstOrDefault();
        }

        public Processes IncomingQueue(Processes currentProcess)
        {
            int miniBurstTime = WaitingProcess.Min(a => a.RemainBurstTime);
            Processes myProcess = WaitingProcess.Where(a => a.RemainBurstTime == miniBurstTime).FirstOrDefault();
            if (currentProcess == null || currentProcess.RemainBurstTime<=0)
            {
                WaitingProcess.Remove(myProcess);
                return myProcess;
            }

            if (currentProcess.RemainBurstTime< myProcess.RemainBurstTime)
                return currentProcess;
            else
            {
                WaitingProcess.Remove(myProcess);
                WaitingProcess.Add(currentProcess);
                return myProcess;
            }
        }
    }
}
