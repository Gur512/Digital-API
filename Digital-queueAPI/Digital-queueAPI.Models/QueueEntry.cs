namespace Digital_queueAPI.Models {
        public enum QueueEntryStatus {
            Waiting,
            Served,
            Cancelled
        }
    public class QueueEntry {
        public int EntryId { get; set; }
        public int Position { get; set; }
        public QueueEntryStatus OrderStatus { get; set; }
        public DateTime JoinedAt { get; set; }
        public int? UserId { get; set; }
        public int? QueueId { get; set; }
        public User? User { get; set; }
        public Queue? Queue { get; set; }
        public virtual ICollection<Notification>? Notifications { get; set; }
    }
}
