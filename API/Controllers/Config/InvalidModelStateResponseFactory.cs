using Microsoft.AspNetCore.Mvc;
using API.Extensions;
using API.Resources;

namespace API.Controllers.Config
{
    public class InvalidModelStateResponseFactory
    {
        public static IActionResult ProduceErrorResponse(ActionContext context)
        {
            var errors = context.ModelState.GetErrorMessages();
            var response = new ErrorResource(messages: errors);

            return new BadRequestObjectResult(response);
        }
    }
}
