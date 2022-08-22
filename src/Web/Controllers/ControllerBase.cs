using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace MovieCatalog.Web.Controllers;

public class ControllerBase : Controller
{
    public string UserId
    {
        get
        {
            if (User != null)
            {
                var userIdNameClaim = 
                    User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                if (userIdNameClaim != null)
                {
                    return userIdNameClaim.Value;
                }
            }

            return null;
        }
    }
}