using FluentValidation;
using Schoolmanagment.Dto_s;

namespace Schoolmanagment.FlientValidation;

public class StudentValidation:AbstractValidator<StudentDto>
{
    public StudentValidation()
    {
        RuleFor(i=>i.Gender).NotEmpty().MaximumLength(3).MinimumLength(1).WithMessage("Yosh faqat raqam bo'lsin Harf emas : ");
    }
}
