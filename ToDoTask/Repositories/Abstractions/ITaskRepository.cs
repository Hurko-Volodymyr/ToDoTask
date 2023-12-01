using Microsoft.EntityFrameworkCore;
using ToDoTask.Models;

namespace ToDoTask.Repositories.Abstractions
{
    public interface ITaskRepository
    {
        List<TaskModel> GetAllTasks();
        TaskModel? GetTaskById(int id);
        void AddTask(TaskModel task);
        public void UpdateTask(TaskModel task);
        public TaskModel? GetTaskByTitle(string title);
        public void DeleteTask(TaskModel task);
    }
}
