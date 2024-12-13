namespace AzureDevOpsClient
{
    public class WorkItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal RemainingWork { get; set; }
        public decimal Effort { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string State { get; set; }
    }
}
