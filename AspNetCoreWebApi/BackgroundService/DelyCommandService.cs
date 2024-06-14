using System.Data;

namespace AspNetCoreWebApi.BackgroundService;




public class TestService
{
    public int Add(int a,int b)
    {
        return a + b;
    }
}

/// <summary>
/// 
/// </summary>
public class DelyCommandService:Microsoft.Extensions.Hosting.BackgroundService
{


    #region 依赖注入
    private IServiceScope serviceScope;
    public DelyCommandService(IServiceScopeFactory scopeFactory)
    {
        this.serviceScope=scopeFactory.CreateScope();
    }

    public override void Dispose()
    {
        this.serviceScope.Dispose();
        base.Dispose();
    }

    #endregion
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        this.serviceScope.ServiceProvider.GetRequiredService<TestService>().Add(1, 2);
    }
}