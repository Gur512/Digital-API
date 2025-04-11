using AutoMapper;

namespace Digital_queueAPI.Models {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Queue, QueueDTO>().ReverseMap();
            CreateMap<QueueEntry, QueueEntryDTO>().ReverseMap();
            CreateMap<Notification, NotificationDTO>().ReverseMap();
        }
    }
}
