using ToDoTask.Models;
using ToDoTask.Repositories.Abstractions;
using ToDoTask.Services.Abstractions;

namespace ToDoTask.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger<TaskService> _logger;

        public TaskService(ITaskRepository taskRepository, ILogger<TaskService> loggerService)
        {
            _taskRepository = taskRepository;
            _logger = loggerService;
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

        public TaskModel? EditTask(string title, string newTitle, bool isCompleted)
        {
            var existingTask = _taskRepository.GetTaskByTitle(title);

            if (existingTask != null)
            {
                existingTask.Title = newTitle;
                existingTask.IsCompleted = isCompleted;

                _taskRepository.UpdateTask(existingTask);

                _logger.LogInformation($"Task edited. Old Title: {title}, New Title: {newTitle}, IsDone: {isCompleted}");
            }
            else
            {
                _logger.LogWarning($"Task not found for editing. Title: {title}");
            }

            return existingTask;
        }


        public bool DeleteTask(string title)
        {
            var taskToDelete = _taskRepository.GetTaskByTitle(title);

            if (taskToDelete != null)
            {
                _taskRepository.DeleteTask(taskToDelete);
                return true;
            }

            return false;
        }

    }
}
