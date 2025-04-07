namespace Digital_queueAPI.Models {
    public class User {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual ICollection<Queue>? Queues { get; set; }
        public virtual ICollection<QueueEntry>? QueueEntries { get; set; }
        public virtual ICollection<Notification>? Notifications { get; set; }
    }
}
