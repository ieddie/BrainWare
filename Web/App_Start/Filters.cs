namespace Filters
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Filters;
    using BrainWare;

    public class OrderExceptionFilterAttribute: ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            // appropriate logger should be used here, either 3rd party or Microsoft.Extensions
            if (!(context.Exception is BrainWareException))
            {
                Debug.WriteLine(string.Concat("Exception occured: ", context.Exception.Message));
            }
            
            context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}