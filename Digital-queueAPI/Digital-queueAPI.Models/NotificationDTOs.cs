namespace Digital_queueAPI.Models {
    public class NotificationDTOs {
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
        public NotificationStatus OrderStatus { get; set; }
        public int? UserId { get; set; }
        public int? EntryId { get; set; }
    }
}
