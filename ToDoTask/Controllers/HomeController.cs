using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using ToDoTask.Models;
using ToDoTask.Services.Abstractions;

namespace ToDoTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<TaskModel> _tasks = new List<TaskModel>();
        private readonly ITaskService _taskService;



        public HomeController(ILogger<HomeController> logger, ITaskService taskService)
        {
            _logger = logger;
            _taskService = taskService;
        }

        public IActionResult Index()
        {
            var tasks = _taskService.GetAllTasks();
            return View(tasks);
        }

        public IActionResult TaskDetails(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == default)
            {
                return NotFound();
            }

            return View(task);
        }

        [HttpPost]
        public IActionResult AddTask(TaskModel task)
        {
            _logger.LogInformation($"AddTask called with title: {task.Title}");
            if (task.Title == default) 
            {
                _logger.LogInformation($"AddTask denied, title is null: {task.Title}");
            }
            else
            {
                _taskService.AddTask(task);
            }           
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditTask(TaskEditedModel model)
        {
            _logger.LogInformation($"EditTask called with title: {model.Title}, newTitle: {model.NewTitle}, isDone: {model.IsCompleted}");

            if (model.Title == default || model.NewTitle == default)
            {
                _logger.LogInformation("Invalid request. Title cannot be null.");
                return Json(new { success = false, errorMessage = "Title cannot be null." });
            }

            var editedTask = _taskService.EditTask(model.Title, model.NewTitle, model.IsCompleted);

            if (editedTask != default)
            {
                _logger.LogInformation($"Task edited successfully. Title: {editedTask.Title}, IsDone: {editedTask.IsCompleted}");
                return Json(new { success = true, editedTask });
            }

            _logger.LogInformation("Task not found for editing.");
            return Json(new { success = false, errorMessage = "Task not found for editing." });
        }


        [HttpPost]
        public IActionResult DeleteTask(TaskModel model)
        {
            _logger.LogInformation($"DeleteTask called with title: {model.Title}");

            if (model.Title == default)
            {
                _logger.LogInformation("Invalid request. Title cannot be null.");
                return BadRequest(new { success = false, errorMessage = "Title cannot be null." });
            }

            var success = _taskService.DeleteTask(model.Title);

            if (success)
            {
                _logger.LogInformation($"Task \"{model.Title}\" deleted successfully.");
                return Json(new { success = true });
            }

            _logger.LogInformation($"Failed to delete task. Task \"{model.Title}\" not found.");
            return Json(new { success = false, errorMessage = $"Task \"{model.Title}\" not found." });
        }



        public IActionResult Editing()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
