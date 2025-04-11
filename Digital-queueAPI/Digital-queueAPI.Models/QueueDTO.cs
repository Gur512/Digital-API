using System.ComponentModel.DataAnnotations;

namespace Digital_queueAPI.Models {
    public class QueueDTO {
        [Required(ErrorMessage = "Set a Name for queue!")]
        public string QueueName { get; set; }
        public QueueStatus OrderStatus { get; set; }
        [Required(ErrorMessage = "Set a Location for queue!")]
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
