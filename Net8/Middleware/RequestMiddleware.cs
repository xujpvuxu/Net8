using Serilog;
using Serilog.Context;
using System.Diagnostics;

namespace Net8.Middleware
{
    public class RequestMiddleware
    {
        public RequestDelegate _next;

        public RequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
              // 產生或取得 RequestId（使用 Activity 或 HttpContext）
        var requestId = Guid.NewGuid();

        // 將 RequestId 加入 LogContext
        {
            // 記錄開始處理請求
            Log.Information("開始處理請求: {Method} {Path} {RequestId}", context.Request.Method, context.Request.Path);

            await _next(context);
            // 記錄完成處理請求
            Log.Information("完成處理請求: {Method} {Path} - 狀態碼: {StatusCode}",
                context.Request.Method,
                context.Request.Path,
                context.Response.StatusCode);
        }
        }
    }
}