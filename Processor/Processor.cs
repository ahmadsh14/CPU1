using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Assignment1
{
    public class Processor
    {
        public string Id { get; private set; }
        public ProcessorState State { get; private set; }
        public Task Task { get; private set; }

        public Processor(string id)
        {
            Id = id;
            State = ProcessorState.Idle;
            Task = null;
        }

        public void AssignTask(Task task)
        {
            State = ProcessorState.Busy;
            Task = task;
            Task.State = TaskState.Executing;
            Console.WriteLine($"Task: {task.Id} Has been assigned to the processor: {Id}");
        }



        public void ExecuteTask(int clockCounter)
        {
            if (Task.State == TaskState.Executing)
            {
                Task.RequestedTime--;
                Console.WriteLine($"Task: {Task.Id} is executing now & Remaining: {Task.RequestedTime}");
            }
            if (Task.RequestedTime == 0)
            {
                State = ProcessorState.Idle;
                Task.State = TaskState.Completed;
                Task.CompletionTime = clockCounter;
                Console.WriteLine($"Task: {Task.Id} Has Completed at Cycle: {clockCounter}:{Task.CompletionTime}");
                Task = null;
            }
        }
    }

    public enum ProcessorState
    {
        Idle,
        Busy
    }
}

