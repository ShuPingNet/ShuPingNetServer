using Infrastructure.Resource;
using System.Diagnostics;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ShuPing.WebApi.Attributes
{
    /// <summary>
    /// 全局日志拦截
    /// </summary>
    public class LoggingActionFilterAttribute: ActionFilterAttribute
    {
        const string StopwatchKey = StringResource.Stopwatch;
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if(null == actionContext)
            {
                return;
            }

            var request   = actionContext.Request;
            request.Properties.Add(StopwatchKey, Stopwatch.StartNew());
            var requestId = request.GetCorrelationId();

            if(request.Content != null)
            {
                string requestContent = string.Empty;
                using (var stream = request.Content.ReadAsStreamAsync().Result)
                {
                    if (stream.CanSeek)
                    {
                        stream.Position = 0;
                    }
                    requestContent = request.Content.ReadAsStringAsync().Result;
                }

                if (!string.IsNullOrEmpty(requestContent))
                {
                    Debug.WriteLine(requestContent);
                }
            }
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext == null)
            {
                return;
            }

            var request   = actionExecutedContext.Request;
            var requestId = request.GetCorrelationId();
            var response  = actionExecutedContext.Response;

            if(response != null)
            {
                if(response.Content != null)
                {
                    Debug.WriteLine(response.Content.ReadAsStringAsync().Result);
                }
            }

            var stopWatch = request.Properties[StopwatchKey] as Stopwatch;
            if(stopWatch != null)
            {
                stopWatch.Stop();
                long mil = stopWatch.ElapsedMilliseconds;
                Debug.WriteLine(mil);
            }
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}