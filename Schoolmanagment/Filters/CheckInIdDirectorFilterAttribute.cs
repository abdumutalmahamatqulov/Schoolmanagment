using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Schoolmanagment.Date;

namespace Schoolmanagment.Filters;
public class CheckInIdStudentFilterAttribute:ActionFilterAttribute
{
    private readonly AppDbContext _appDbContext;

    public CheckInIdStudentFilterAttribute(AppDbContext appDbContext) => _appDbContext = appDbContext;
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ActionArguments.ContainsKey("Id"))
        {
            await next();
            return;
        }
        var id = (int)context.ActionArguments["Id"];
        if(!await _appDbContext.Directors.AnyAsync(d=>d.Id == id))
        {
            await next();
            return;
        }
    }
}
