using Microsoft.AspNetCore.Mvc.Filters;
using NLog;

namespace ACGMapping.InfraStructure.Filter
{
    public class MethodCaptureAttribute : ActionFilterAttribute
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Logger.Info("--------------------------------------------------------");

            var controllerName = (string)filterContext.RouteData.Values["controller"];

            var actionName = (string)filterContext.RouteData.Values["action"];

            Logger.Info($"{controllerName}.{actionName} In");

            Logger.Trace("Received Parameters---------------");

            foreach (var parameter in filterContext.ActionArguments)
            {
                Logger.Trace($"{parameter.Key}:{parameter.Value}");

                if (parameter.Value is string || parameter.Value is int || parameter.Key == "files")
                {
                    continue;
                }

                var properties = parameter.Value.GetType().GetProperties();
                
                foreach (var propertyInfo in properties)
                {
                    Logger.Trace($"{propertyInfo.Name}:{propertyInfo.GetValue(parameter.Value)}");
                }
            }

            base.OnActionExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string controllerName = (string)filterContext.RouteData.Values["controller"];

            string actionName = (string)filterContext.RouteData.Values["action"];

            Logger.Info($"{controllerName}.{actionName} Out");

            base.OnResultExecuted(filterContext);
        }
    }
}