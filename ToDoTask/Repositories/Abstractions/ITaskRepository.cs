using ToDoTask.Models;

namespace ToDoTask.Repositories.Abstractions
{
    public interface ITaskRepository
    {
        List<TaskModel> GetAllTasks();
        TaskModel? GetTaskById(int id);
        void AddTask(TaskModel task);
    }
}
