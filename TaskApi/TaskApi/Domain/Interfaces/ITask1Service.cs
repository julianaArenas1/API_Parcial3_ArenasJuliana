using System.Diagnostics.Metrics;
using TaskApi.DAL.Entities;

namespace TaskApi.Domain.Interfaces
{
    public interface ITask1Service
    {
        Task<IEnumerable<Task1>>GetTaskAsync();
        Task<Task1> GetTaskByIdAsync(Guid id);
        Task<Task1> GetTaskByDueDateAsync(DateTime DueDate);
        Task<Task1> CreateTaskAsync(Task1 task1);
        Task<Task1> EditTaskAsync(Task1 task1);
        Task<Task1> DeleteTaskAsync(Guid id);
    }
}
