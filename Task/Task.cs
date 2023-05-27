using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Assignment1
{

    public class Task
    {
        public int Id { get; set; }
        public int CreationTime { get; set; }
        public int RequestedTime { get; set; }
        public int CompletionTime { get; set; }
        public string? Priority { get; set; }
        public TaskState State { get; set; }

    }

    public enum TaskState
    {
        Waiting,
        Executing,
        Completed
    }
}






