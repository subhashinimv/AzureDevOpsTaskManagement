using Microsoft.EntityFrameworkCore;
using System;

namespace AzureDevOpsClient
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        
        }
        public async Task CreateWorkItemAsync(TaskDto task)
        {
            var newTask = new WorkItem
            {
                Title = task.Title,
                Description = task.Description,
                State = "New",
                CompletionDate = DateTime.UtcNow,
                RemainingWork = task.RemainingWork,
                Effort = task.Effort
            };

            await _context.WorkItem.AddAsync(newTask);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateWorkItemAsync(int Id,TaskDto taskDto)
        {
            var task = await _context.WorkItem.FindAsync(Id);
            if (task != null)
            {
                task.Title = taskDto.Title;
                task.Description = taskDto.Description;
                task.State = task.State;
                task.CompletionDate = DateTime.UtcNow;
                task.RemainingWork = taskDto.RemainingWork;
                task.Effort = taskDto.Effort;

                _context.WorkItem.Update(task);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<List<WorkItem>> GetAllWorkItemsAsync()
        {
            return await _context.WorkItem.ToListAsync();

        }

        public async Task<WorkItem> GetWorkItemByIdAsync(int workItemId)
        {
            return await _context.WorkItem.FindAsync(workItemId);

        }
    }
}
