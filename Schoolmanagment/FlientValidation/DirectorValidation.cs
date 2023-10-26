using FluentValidation;
using Schoolmanagment.Dto_s;

namespace Schoolmanagment.FlientValidation;
public class DirectorValidation:AbstractValidator<DirectorDto>
{
    public DirectorValidation()
    {
        RuleFor(d => d.Email).NotEmpty().MaximumLength(50).MinimumLength(10).WithMessage("10 tadan kam belgi bo'lsa yetmaydi hatolik 50 tadan ko'p bo'lsa ko'p hatolik beradi :");
    }
}
