namespace AzureDevOpsClient
{
    public interface ITaskService
    {
        Task CreateWorkItemAsync(TaskDto taskDto);
        Task UpdateWorkItemAsync(int Id, TaskDto taskDto);
        Task<WorkItem> GetWorkItemByIdAsync(int workItemId);
        Task<List<WorkItem>> GetAllWorkItemsAsync();
    }
}
