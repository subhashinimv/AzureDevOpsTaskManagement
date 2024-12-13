using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AzureDevOpsClient.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowLocalhost")]
    public class TasksController : Controller
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkItems()
        {
            List<WorkItem> result = await _taskService.GetAllWorkItemsAsync();
            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskDto taskDto)
        {
            if (taskDto == null)
            {
                return BadRequest("Invalid task data.");
            }

            await _taskService.CreateWorkItemAsync(taskDto);

            return Ok(new { Message = "Task created successfully" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskDto task)
        {
            if (task == null)
            {
                return BadRequest("Invalid task data.");
            }

            // Delegate task update to TaskService
            await _taskService.UpdateWorkItemAsync(id, task);

            return Ok(new { Message = "Task updated successfully" });
        }


    }
}
