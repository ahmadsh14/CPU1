using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Scheduler : IScheduler
    {
        public PriorityQueue<Task, string> TaskQueue;

        public Scheduler()
        {
            TaskQueue = new PriorityQueue<Task, string>();
        }

        public void AddTask(List<Task> tasks, int ClockCounter)
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
        }

        public void AssignTaskToProcessor(Processor availableProcessor)
        {
            var task = TaskQueue.Dequeue();
            if (task.State == TaskState.Waiting)
            {
                availableProcessor.AssignTask(task);
            }
        }
    }
}
