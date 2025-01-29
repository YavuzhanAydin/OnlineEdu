using AutoMapper;
using OnlineEdu.DTO.DTOs.SubscribersDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEduAPI.Mapping
{
    public class SubscriberMapping:Profile
    {
        public SubscriberMapping()
        {
            CreateMap<CreateSubscriberDto, Subscriber>().ReverseMap();
            CreateMap<UpdateSubscriberDto, Subscriber>().ReverseMap();
        }
    }
}
