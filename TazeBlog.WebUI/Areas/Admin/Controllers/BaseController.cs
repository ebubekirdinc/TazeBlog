using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TazeBlog.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var LoggedUser = User.Claims.Where(c => c.Type == ClaimTypes.Name)
               .Select(c => c.Value).SingleOrDefault();
            base.OnActionExecuting(context);
        }
    }
}