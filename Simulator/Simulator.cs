using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Simulator
    {
        public int ProcessorsCount { get; private set; }
        public List<Task> Tasks { get; private set; }
        public Scheduler Scheduler;

        public Simulator(int processorsCount, List<Task> tasks)
        {
            this.ProcessorsCount = processorsCount;
            this.Tasks = tasks;
            Scheduler = new Scheduler();
        }

        public void RunSimulation()
        {
            Scheduler.ProcessorsCreation(ProcessorsCount);
            Scheduler.AddTask(Tasks);
            Scheduler.AssignAndExecuteTasks();
        }
        
    }
}