using NLog;
using System.Diagnostics;
using System.Text;
using VotingApp.Exceptions;

namespace VotingApp.Middlewares;

public class ErrorHandlingMiddleware : IMiddleware
{
    private static Logger logger = LogManager.GetCurrentClassLogger();
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (BadRequestException badRequestException)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync(badRequestException.Message);
        }
        catch (Exception e)
        {
            var stackTrace = new StackTrace(e, true);
            var frames = stackTrace.GetFrames();
            var logMessage = new StringBuilder();

            foreach (var frame in frames.Reverse()) 
            {
                if (frame.GetFileLineNumber() < 1)
                {
                    continue;
                }

                logMessage.Append($"METHOD: {frame.GetMethod().Name} | F: {frame.GetFileName().Split('\\').Last()} | LN: {frame.GetFileLineNumber()} | EXC. TYPE: {e.GetType()} | EXC. MSG: {e.Message}");
            }

            logger.Error(logMessage.ToString());
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Something went wrong");
        }
    }
}
