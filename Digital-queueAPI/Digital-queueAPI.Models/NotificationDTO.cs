using System.ComponentModel.DataAnnotations;

namespace Digital_queueAPI.Models {
    public class NotificationDTO {
        [Required(ErrorMessage = "Message is required!")]
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
        public NotificationStatus OrderStatus { get; set; }
        [Required(ErrorMessage = "Assign a User to notify!")]
        public int? UserId { get; set; }
        [Required(ErrorMessage = "Assign a entryqueue to notify!")]
        public int? EntryId { get; set; }
    }
}
