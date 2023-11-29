using ToDoTask.Models;
using ToDoTask.Repositories.Abstractions;
using ToDoTask.Services.Abstractions;

namespace ToDoTask.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public List<TaskModel> GetAllTasks()
        {
            return _taskRepository.GetAllTasks();
        }

        public TaskModel? GetTaskById(int id)
        {
            return _taskRepository.GetTaskById(id);
        }

        public void AddTask(TaskModel task)
        {
            _taskRepository.AddTask(task);
        }
    }
}
