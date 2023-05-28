using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment1
{
    public interface IScheduler
    {
        void AddTask(List<Task> tasks, int ClockCounter);
        void AssignTaskToProcessor(Processor availableProcessor);
    }
}
