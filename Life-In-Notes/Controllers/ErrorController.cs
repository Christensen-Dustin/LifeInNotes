using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Life_In_Notes.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }

        [Route("Error/{statusCode}")]
        [AllowAnonymous]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            // Variable for the Status Code Results
            var statusCodeResults = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            // Go through the status codes
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the requested resource could not be found";
                    logger.LogWarning($"404 Error Occured. Path: {statusCodeResults.OriginalPath} " +
                        $"and QueryString: {statusCodeResults.OriginalQueryString}");
                    break;
                case 500:
                    ViewBag.ErrorMessage = "Sorry, at this time your request cannot be processed";
                    logger.LogWarning($"500 Error Occured. Path: {statusCodeResults.OriginalPath} " +
                        $"and QueryString: {statusCodeResults.OriginalQueryString}");
                    break;
                default:
                    ViewBag.ErrorMessage = "An error has occured while processing your request." +
                        "The support team is notified and we are working to correct the situation.";
                    logger.LogWarning($"An Error Occured. Path: {statusCodeResults.OriginalPath} " +
                        $"and QueryString: {statusCodeResults.OriginalQueryString}");
                    break;
            }

            return View("NotFound");
        }

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            // varible to collect the Error path, message and stacktrace
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            // Transfer information to the logger element
            logger.LogError($"The path {exceptionDetails.Path} threw an exception " +
                $"{exceptionDetails.Error}") ;
            
            // Return the custom error view
            return View("Error");
        }
    }
}
