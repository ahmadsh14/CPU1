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
        private List<Processor> Processors;
        public int ClockCounter { get; private set; }

        public Scheduler Scheduler;

        public Simulator(int processorsCount, List<Task> tasks)
        {
            this.ProcessorsCount = processorsCount;
            this.Tasks = tasks;
            Scheduler = new Scheduler();
            Processors = new List<Processor>();
            this.ClockCounter = 0;
        }

        public void ProcessorsCreation()
        {
            for (int i = 0; i < ProcessorsCount; i++)
            {
                Processors.Add(new Processor("P" + (i + 1)));
                Console.WriteLine("New Processor has Been Created");
            }
        }

        public void RunSimulation()
        {
            this.ProcessorsCreation();
            while (
                this.Tasks.Any(t=>t.State != TaskState.Completed)
            )
            {
                ClockCounter++;
                foreach (Processor processor in Processors)
                {
                    if (processor.State == ProcessorState.Idle && Scheduler.TaskQueue.Count != 0)
                    {
                        Scheduler.AssignTaskToProcessor(processor);
                    }
                }

                foreach (Processor processor in Processors)
                {
                    if (processor.State == ProcessorState.Busy)
                    {
                        processor.ExecuteTask(ClockCounter);
                    }
                }

                Scheduler.AddTask(Tasks, ClockCounter);
            }
        }
    }
}
