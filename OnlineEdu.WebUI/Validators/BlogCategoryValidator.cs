using FluentValidation;
using OnlineEdu.WebUI.DTOs.BlogCategoryDtos;

namespace OnlineEdu.WebUI.Validators
{
	public class BlogCategoryValidator : AbstractValidator<CreateBlogCategoryDto>
	{
        public BlogCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Blog Adı Boş Geçilemez");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Blog Adı MAX 30 Karakter Olabilir");
        }
    }
}
