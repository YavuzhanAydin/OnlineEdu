using AutoMapper;
using OnlineEdu.DTO.DTOs.BlogCategoryDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEduAPI.Mapping
{
    public class BlogCategoryMapping : Profile
    {
        public BlogCategoryMapping()
        {
            CreateMap<CreateBlogCategoryDto , BlogCategory>().ReverseMap();
            CreateMap<UpdateBlogCategoryDto , BlogCategory>().ReverseMap();
            CreateMap<ResultsBlogCategoryDto , BlogCategory>().ReverseMap();
            
        }
    }
}
