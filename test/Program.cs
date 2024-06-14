
using System.Security.Principal;
using EFCore;
using ITest;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using test;

// new EntityOperate().addEntity();
// new EntityOperate().AddLeaveUserEntity();
// new EntityOperate().SearchLeaveUserEntity();
// new EntityOperate().AddNodeEntity();
//new EntityOperate().AddOne2OneEntity();
//new EntityOperate().SearchOne2OneEntity(1);
//new EntityOperate().AddMany2ManyEntity();
// new EntityOperate().SearchMany2ManyEntity(1);

// new EntityOperate().SearchAllNodeEntity();
// var opt = new EntityOperate();
// opt.AddEntity();
// await opt.ExecSql();
//opt.ExpressionTree();


// string[] allLines = File.ReadAllLines("email.txt");
// foreach (string line in allLines)
// {
//     var section=line.Split(',');
//     var name = section[0];
//     var email= section[1];
//     var title= section[2];
//     var body= section[3];
//     Console.WriteLine($"发送邮件{name}-{email}-{title}-{body}");
// }


ServiceCollection service = new ServiceCollection();
service.AddScoped<IEmailSender, MyEmailSender>();
service.AddScoped<IDataProvider, MyDataProvider>();
service.AddScoped<Bussiness>();

var sp = service.BuildServiceProvider();
var bussiness = sp.GetRequiredService<Bussiness>();
await bussiness.Send();


