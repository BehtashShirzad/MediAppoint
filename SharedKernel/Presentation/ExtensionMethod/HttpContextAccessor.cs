using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Presentation.ExtensionMethod
{
    public static class HttpContextAccessor 
    {
        public static Guid GetUserId(this IHttpContextAccessor httpContext)
        {
            var result = httpContext.HttpContext.User.Claims.FirstOrDefault(_=>_.Value=="Id")?.ToString();
             Guid.TryParse(result,out Guid res);
            return res;
        }
    }
}
