namespace Digital_queueAPI.Models {
        public enum QueueStatus {
            Open,
            Closed
        }
    public class Queue {
        public int QueueId { get; set; }
        public string QueueName { get; set; }
        public QueueStatus OrderStatus { get; set; }
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual ICollection<QueueEntry>? QueueEntries { get; set; }
    }
}
