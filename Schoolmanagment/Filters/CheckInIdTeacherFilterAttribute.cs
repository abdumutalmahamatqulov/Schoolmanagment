using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Schoolmanagment.Date;

namespace Schoolmanagment.Filters;
public class CheckInIdTeacherFilterAttribute: ActionFilterAttribute
{
    private readonly AppDbContext _appDbContext;

    public CheckInIdTeacherFilterAttribute(AppDbContext appDbContext) => _appDbContext = appDbContext;
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if(!context.ActionArguments.ContainsKey("Id")) 
        {
            await next();
            return;
        }
        var id = (int)context.ActionArguments["Id"];
        if(!await _appDbContext.Teachers.AnyAsync(t=>t.Id == id))
        {
            await next();
            return;
        }
    }
}
