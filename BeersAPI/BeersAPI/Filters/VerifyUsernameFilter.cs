using BeersAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BeersAPI.Filters
{
    public class VerifyUsernameFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        { 
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var model1 = context.ActionArguments.SingleOrDefault(a => a.Value is Ratings);
            var regex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            var object1 = (Ratings)model1.Value;
            bool isValid = Regex.IsMatch(object1.Username, regex, RegexOptions.IgnoreCase);
            if (isValid == false)
            {
                context.Result = new BadRequestObjectResult("Username is invalid");

            }
        }
    }
}
