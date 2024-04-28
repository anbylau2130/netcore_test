托管服务的使用
--定时任务，托管任务
1.托管服务实现IHostedService接口，一般编写从BackgroundService继承的类


2.实现接口方法


3.builder.Service.AddHostedService<DelyCommandService>();


4.如果服务抛出异常，则自动停止web服务
建议在ExcuseAsync方法中进行 try catch处理，并进行日志记录



托管服务中使用依赖注入DI
1.托管服务是以单例的声明周期注册到依赖注入容器中的。因此，不能注入生命周期为瞬时或者范围的服务。(比如注入EFcore的上下文，程序会报异常）。
2.可以通过构造方法注入一个IServiceScopeFactory服务，它可以用来创建一个IServiceScope对象，这样我们就可以通过IServiceScope对象，这样我们就可以通过IServiceScope来创建短生命周期的 服务。
记住在Dispose中释放IServiceScope




定时服务部推荐使用该方法

可以使用HangFire