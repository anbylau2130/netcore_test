
using System.Security.Principal;
using EFCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
var opt = new EntityOperate();
// await opt.ExecSql();
opt.ExpressionTree();

