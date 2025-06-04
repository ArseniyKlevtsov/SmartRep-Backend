using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SmartRep_Backend.Domain.interfaces.Repositories;
using System.Security.Claims;

namespace SmartRep_Backend.WebApi.Middlewares;

public class StatusConfirmedAttribute : ActionFilterAttribute
{
    private readonly IUnitOfWork _unitOfWork;

    public StatusConfirmedAttribute(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public override async void OnActionExecuting(ActionExecutingContext context)
    {
        // Получите текущего пользователя из клаймов
        var userIdClaim = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

        if (userIdClaim == null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var userId = Guid.Parse(userIdClaim.Value);

        // Получите профиль учителя из базы данных
        var teacherProfile = _unitOfWork.TeacherProfiles.GetByIdAsync(userId, CancellationToken.None).GetAwaiter().GetResult();

        // (teacherProfile == null || !teacherProfile.StatusConfirmed)
        if(teacherProfile == null)
        {
            context.Result = new ForbidResult(); // Возвращаем 403 Forbidden
            return;
        }

        base.OnActionExecuting(context);
    }
}
