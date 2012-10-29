using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using LakePuzzle.Business;

namespace LakePuzzle.API.Controllers
{
    public class UnhandledExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {

            HttpStatusCode status = HttpStatusCode.InternalServerError;
            string errorMsg = "Critical error.";


            var exType = context.Exception.GetType();

            if (exType == typeof(LakePuzzleException))
            {
                errorMsg = context.Exception.Message;
                status = HttpStatusCode.BadRequest;
            }
            else if (exType == typeof(UnauthorizedAccessException))
            {
                status = HttpStatusCode.Unauthorized;
            }
            else if (exType == typeof(ArgumentException))
            {
                status = HttpStatusCode.NotFound;
            }
            else if (exType == typeof(NotImplementedException))
            {
                status = HttpStatusCode.NotImplemented;
            }

            context.Response = new HttpResponseMessage(status) { Content = new StringContent(errorMsg) };

            base.OnException(context);
        }
    }
}