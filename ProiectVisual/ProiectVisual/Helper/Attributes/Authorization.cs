using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProiectVisual.Models;
using ProiectVisual.Models.Enums;

namespace ProiectVisual.Helper.Attributes
{
    public class Authorization : Attribute, IAuthorizationFilter
    {
        private readonly ICollection<Role> _roles;

        public Authorization(ICollection<Role> roles)
        {
            _roles = roles;
        }

        void IAuthorizationFilter.OnAuthorization(AuthorizationFilterContext context)
        {
            var unauthorizedStatusObject = new JsonResult(new { Message = "Unauthorized" }){ StatusCode = StatusCodes.Status401Unauthorized};
            if (_roles==null)
            {
                context.Result = unauthorizedStatusObject;
            }

            var user = (User)context.HttpContext.Items["User"];
            if (user == null || !_roles.Contains(user.Rol));
            {
                context.Result = unauthorizedStatusObject;
            }
        }
    }
}
