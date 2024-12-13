namespace AzureDevOpsClient
{
    public interface ITask
    {
        public int Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        decimal RemainingWork { get; set; }
        decimal Effort { get; set; }
        DateTime? CompletionDate { get; set; }
        string State { get; set; }
    }
}