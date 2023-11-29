using System;
using ToDoTask.Data;
using ToDoTask.Models;
using ToDoTask.Repositories.Abstractions;

namespace ToDoTask.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TaskRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TaskModel> GetAllTasks()
        {
            return _dbContext.Tasks.ToList();
        }

        public TaskModel? GetTaskById(int id)
        {
            return _dbContext.Tasks.FirstOrDefault(t => t.Id == id);
        }

        public void AddTask(TaskModel task)
        {
            _dbContext.Tasks.Add(task);
            _dbContext.SaveChanges();
        }
    }
}
