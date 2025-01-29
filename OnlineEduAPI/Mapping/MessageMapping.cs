using AutoMapper;
using OnlineEdu.DTO.DTOs.MessagesDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEduAPI.Mapping
{
    public class MessageMapping : Profile
    {
        public MessageMapping()
        {
            CreateMap<CreateMessageDto,Message>().ReverseMap();
            CreateMap<UpdateMessageDto,Message>().ReverseMap();
            
        }
    }
}
