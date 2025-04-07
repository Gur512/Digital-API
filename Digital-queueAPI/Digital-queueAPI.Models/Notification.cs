namespace Digital_queueAPI.Models {
        public enum NotificationStatus {
            Sent,
            Read
        }
    public class Notification {
        public int NotificationId { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
        public NotificationStatus OrderStatus { get; set; }
        public int? UserId { get; set; }
        public int? EntryId { get; set; }
        public User? User { get; set; }
        public QueueEntry? QueueEntry { get; set; }
    }
}
