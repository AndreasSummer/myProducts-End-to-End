﻿using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Thinktecture.Applications.Framework.WebApi
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var argumentException = actionExecutedContext.Exception;

            if (argumentException != null)
            {
                var message = string.IsNullOrEmpty(argumentException.Message)
                                  ? "An exception occurred"
                                  : argumentException.ToString();

                // 500 is the default, anyways...
                actionExecutedContext.Response =
                    actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message);
                actionExecutedContext.Response.Content.Headers.ContentType =
                    actionExecutedContext.Request.Content.Headers.ContentType;
            }
        }
    }
}