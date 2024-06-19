using Polly;
using Polly.CircuitBreaker;
using Polly.Fallback;
using Polly.Retry;

namespace ASPNETCORE.Polly.Polly;

/// <summary>
/// 所有策略
/// </summary>
public class ClientPolly<T> where T :new()
{
    /// <summary>
    /// 重试
    /// </summary>
    public AsyncRetryPolicy<HttpResponseMessage> RetryPolicy { get; set; }

    /// <summary>
    /// 熔断
    /// </summary>
    public AsyncCircuitBreakerPolicy CircuitBreakerPolicy { get; set; }


    public AsyncFallbackPolicy<T> FallbackPolicy { get; set; }


    public ClientPolly()
    {

        //如果失败重试，重试5次，每次间隔为次数的平方
        RetryPolicy = Policy.HandleResult<HttpResponseMessage>(p => !p.IsSuccessStatusCode).
            WaitAndRetryAsync(5,retryAttempt=>TimeSpan.FromMinutes(Math.Pow(2,retryAttempt)));

        //连续发生了Exception异常之后，会抛出BrokenCircuitException异常，1分钟后恢复请求：这样可以减少并发量
        CircuitBreakerPolicy = Policy.Handle<Exception>().CircuitBreakerAsync(2, TimeSpan.FromMinutes(1));

        //捕捉到Exception异常之后，返回一个 T 对象的实例
        FallbackPolicy = Policy<T>.Handle<Exception>().FallbackAsync(new T());
    }
}