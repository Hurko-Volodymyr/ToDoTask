using ToDoTask.Models;

namespace ToDoTask.Services.Abstractions
{
    public interface ITaskService
    {
        List<TaskModel> GetAllTasks();
        TaskModel? GetTaskById(int id);
        void AddTask(TaskModel task);
    }
}
