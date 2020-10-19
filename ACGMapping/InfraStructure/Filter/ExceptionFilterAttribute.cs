using System;
using Microsoft.AspNetCore.Mvc.Filters;
using NLog;

namespace ACGMapping.InfraStructure.Filter
{
    public class ExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public void OnException(ExceptionContext filterContext)
        {
            var errorMsg = "Exception::" + filterContext.Exception.GetBaseException().Message;

            Logger.Error(errorMsg);

            //var exceptionType = filterContext.Exception.GetType();

            //if (exceptionType == typeof(JsonException))
            //{
            //}
        }
    }
}