using System.ComponentModel.DataAnnotations;

namespace Digital_queueAPI.Models {
    public class QueueEntryDTO {
        [Required(ErrorMessage = "Position is not set!")]
        public int Position { get; set; }
        public QueueEntryStatus OrderStatus { get; set; }
        public DateTime JoinedAt { get; set; }
        [Required(ErrorMessage = "Add a user in queueEntry!")]
        public int? UserId { get; set; }
        [Required(ErrorMessage = "Add queue in entry!")]
        public int? QueueId { get; set; }
    }
}
