namespace Digital_queueAPI.Models {
    // Because swagger does not recognize enums we have to put this outside class
    // it Stores as 0 and 1 in database, so we use 0 and 1 there.
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
