using ToDoTask.Models;

namespace ToDoTask.Services.Abstractions
{
    public interface ITaskService
    {
        List<TaskModel> GetAllTasks();
        TaskModel? GetTaskById(int id);
        void AddTask(TaskModel task);
        TaskModel? EditTask(string title, string newTitle, bool isCompleted);
        public bool DeleteTask(string title);
    }
}
