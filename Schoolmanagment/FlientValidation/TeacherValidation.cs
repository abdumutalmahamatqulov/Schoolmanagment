using FluentValidation;
using Schoolmanagment.Dto_s;

namespace Schoolmanagment.FlientValidation;
public class TeacherValidation: AbstractValidator<TeacherDto>
{
    public TeacherValidation()
    {
        RuleFor(t=>t.Name).NotEmpty().MaximumLength(20).MinimumLength(2).WithMessage("Iltimos ko'ziga qarab kirgiz harflarni chegara ichida bolsin : ");
    }
}
