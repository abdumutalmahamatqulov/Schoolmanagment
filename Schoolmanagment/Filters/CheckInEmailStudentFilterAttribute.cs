using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Schoolmanagment.Date;

namespace Schoolmanagment.Filters;

public class CheckInEmailStudentFilterAttribute : ActionFilterAttribute
{
    private readonly AppDbContext _appDbContext;

    public CheckInEmailStudentFilterAttribute(AppDbContext appDbContext) => _appDbContext = appDbContext;
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ActionArguments.ContainsKey("Id"))
        {
            await next();
            return;
        }
        var Name = context.ActionArguments["Name"];
        if (!await _appDbContext.Students.AnyAsync(s=>s.Name==Name))
        {
            await next();
            return;
        }
    }
}
