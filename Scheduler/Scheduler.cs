using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1
{
    public interface IScheduler
    {
        public void ProcessorsCreation(int processorCount);
        public void AddTask(List<Task> tasks);
        public void AssignAndExecuteTasks();
    }
    public class Scheduler : IScheduler
    {
        private List<Processor> Processors;
        private PriorityQueue<Task, string> TaskQueue;
        private int ClockCounter = 0;
        public Scheduler()
        {
            Processors = new List<Processor>();
            TaskQueue = new PriorityQueue<Task, string>();
        }

        public void ProcessorsCreation(int processorCount)
        {
            for (int i = 0; i < processorCount; i++)
            {
                Processors.Add(new Processor("P" + (i + 1)));
                Console.WriteLine("New Processor has Been Created");
            }
        }

        public void AddTask(List<Task> tasks)
        {
            while (TaskQueue.Count < tasks.Count)
            {
                foreach (Task task in tasks)
                {
                    if (task.CreationTime == ClockCounter)
                    {
                        task.State = TaskState.Waiting;
                        TaskQueue.Enqueue(task, task.Priority);
                        Console.WriteLine($"Task {task.Id} has been created at cycle: {ClockCounter}");
                    }
                }
                ClockCounter++;
            }
        }

        public void AssignAndExecuteTasks()
        {
            while (TaskQueue.Count > 0 || Processors.Any(p => p.State == ProcessorState.Busy))
            {
                ClockCounter++;
                foreach (Processor processor in Processors)
                {
                    if (processor.State == ProcessorState.Idle && TaskQueue.Count != 0)
                    {
                        var task = TaskQueue.Dequeue();
                        if (task.State == TaskState.Waiting)
                        {
                            processor.AssignTask(task);
                        }
                    }
                }

                foreach (Processor processor in Processors)
                {
                    if (processor.State == ProcessorState.Busy)
                    {
                        processor.ExecuteTask(ClockCounter);
                    }
                }
            }
        }
    }
}
