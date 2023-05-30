using System;
using System.IO;
using SchedualProcessOs.Bl;
using System.Collections.Generic;
using Newtonsoft.Json;
using SchedualProcessOs.Bl;
using System.Diagnostics;

namespace SchedualProcessOs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string jsonString = File.ReadAllText("processes.json");
            List<Processes> lstProcess = JsonConvert.DeserializeObject<List<Processes>>(jsonString);
            IShcedualProcess ProcessAlgorithm = new ShortestProcess(lstProcess);

            int nTimeLineIndex = 0;
            Processes CurrentProcess = ProcessAlgorithm.IncomingProcess();
            foreach (var Process in lstProcess)
            {
                Console.WriteLine($"Process Name  {Process.ProcessName} Arival Time{Process.ArivalTime}");
            }
            Console.WriteLine("-----------------");

            while (true)
            {
                if (CurrentProcess==null)
                {
                    if (ProcessAlgorithm.MainProcess.Count > ProcessAlgorithm.EndedProcess.Count)
                    {
                        Console.WriteLine("Ideal State Empty time line");
                        continue;
                    }

                    else
                        break;
                }

                Console.WriteLine($"process name {CurrentProcess.ProcessName}  **  Remain Busrt Time= {CurrentProcess.RemainBurstTime}");
                CurrentProcess.RemainBurstTime--;

                if (CurrentProcess.RemainBurstTime==0)
                {
                    ProcessAlgorithm.EndedProcess.Add(CurrentProcess);
                    if (ProcessAlgorithm.WaitingProcess.Count > 0)
                        CurrentProcess = ProcessAlgorithm.IncomingQueue(CurrentProcess);
                    else
                        CurrentProcess = null;
                }


                nTimeLineIndex++;
                CurrentProcess = ProcessAlgorithm.IncomingProcess(CurrentProcess, nTimeLineIndex);

                if (ProcessAlgorithm.WaitingProcess.Count > 0)
                {
                    CurrentProcess = ProcessAlgorithm.IncomingQueue(CurrentProcess);
                }
            }
            Console.WriteLine("***********************************");
            Console.WriteLine("Finished");
            Console.ReadKey();
        }
    }
}
