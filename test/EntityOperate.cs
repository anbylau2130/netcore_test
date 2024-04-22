using System.Collections.Generic;
using System.Linq.Expressions;
using EFCore;
using ExpressionTreeToString;
using Microsoft.EntityFrameworkCore;
using static Dapper.SqlMapper;
using static System.Linq.Expressions.Expression;
using System.Linq;
namespace test;

public class EntityOperate
{
    public void AddEntity()
    {
        using (EFCoreDbContext db = new EFCoreDbContext())
        {
            Article article = new Article();
            article.Title = "标题1";
            article.Comments = new List<Comment>()
            {
                new Comment{ Content="评论1"},
                new Comment{Content="评论2"}
            };

            db.Articles.Add(article);
            db.SaveChanges();
        }
    }


    public void SearchEntity(int id)
    {
        using (var ctx = new EFCoreDbContext())
        {
            var result = ctx.Articles.Single(item => item.Id == id);
            //Include 关联对象查询
            var result2 = ctx.Articles.Include(a => a.Comments).Single(item => item.Id == id);
            //Select 单表查询
            var result3 = ctx.Articles.Select(item => new { item.Id }).First();
            Console.WriteLine(result3);

        }
    }
    public void AddLeaveUserEntity()
    {
        using (var ctx = new EFCoreDbContext())
        {
            Leave leave = new Leave();
            leave.Approver = new User() { Name = "jessica" };
            leave.Requester = new User() { Name = "hiuyeung" };
            leave.Remarks = "辞职申请";
            ctx.Leaves.Add(leave);
            ctx.SaveChanges();
        }
    }


    public void AddNodeEntity()
    {
        using (var ctx = new EFCoreDbContext())
        {
            Node node = new Node()
            {
                Name = "父节点",
                Children = new List<Node>
                 {
                     new() {
                         Name="系统配置",
                         Children=new List<Node>()
                         {
                             new (){Name="菜单配置"},
                             new (){Name="权限管理"},
                             new(){Name="用户管理"},
                             new(){Name="系统参数"}
                         }
                         },
                     new(){Name="WMS模块"},
                     new(){Name="OMS模块"},
                     new(){Name="TMS模块"}
                 }
            };

            ctx.Nodes.Add(node);
            var result = ctx.SaveChanges();
            Console.WriteLine($"{result}");
        }
    }



    public void SearchAllNodeEntity()
    {
        using (var ctx = new EFCoreDbContext())
        {
            EfCoreDbOperations<EFCoreDbContext, Node> op = new EfCoreDbOperations<EFCoreDbContext, Node>(ctx);
            long totalcount;
            long pagecount;
            var reuslt = op.Pager(x => x.Id != 0, 1, 3, out totalcount, out pagecount);
            Console.WriteLine(1);

        }
    }
    public class TreeNode
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<TreeNode> Children { get; set; } = new List<TreeNode>();
    }

    public List<TreeNode> SearchNodeByParent(EFCoreDbContext ctx, int? parent)
    {
        List<TreeNode> treeNodeList = new List<TreeNode>();
        var children = ctx.Nodes.Where(x => x.ParentId == parent).ToList();


        foreach (var child in children)
        {
            treeNodeList.Add(new TreeNode()
            {
                Id = child.Id,
                Name = child.Name,
                Children = SearchNodeByParent(ctx, (int?)child.Id)
            });
        }
        return treeNodeList;
    }


    public void AddOne2OneEntity()
    {
        using (var ctx = new EFCoreDbContext())
        {
            Person person = new Person()
            {
                Name = "cuixiaoyang",
                PersonCard = new PersonCard()
                {
                    NO = "123456789",
                }
            };
            ctx.Persons.Add(person);
            ctx.SaveChanges();
        }
    }

    public void SearchOne2OneEntity(int id)
    {
        using (var ctx = new EFCoreDbContext())
        {
            //Include 关联对象查询
            var result = ctx.Persons.Include(a => a.PersonCard).Single(item => item.Id == id);

            Console.WriteLine(result);
        }
    }
    public void AddMany2ManyEntity()
    {
        using (var ctx = new EFCoreDbContext())
        {
            Teacher t = new Teacher()
            {
                Name = "数学老师",
            };
            Teacher t2 = new Teacher()
            {
                Name = "语文老师"
            };
            Student studentA = new Student()
            {
                Name = "学生A"
            };
            Student studentB = new Student()
            {
                Name = "学生B"
            };
            t.Students.Add(studentA);
            t.Students.Add(studentB);
            t2.Students.Add(studentA);
            t2.Students.Add(studentB);

            ctx.Teachers.Add(t);
            ctx.Teachers.Add(t2);
            ctx.SaveChanges();
        }
    }
    public void SearchMany2ManyEntity(int id)
    {
        using (var ctx = new EFCoreDbContext())
        {
            //Include 关联对象查询
            var result = ctx.Teachers.Include(x => x.Students).Single(item => item.Id == id);

            Console.WriteLine(result);
        }
    }
    public void SearchLeaveUserEntity()
    {
        using (var ctx = new EFCoreDbContext())
        {
            var result = ctx.Leaves.Include(a => a.Requester)
                .Include(e => e.Approver)
                .Single(x => x.Remarks == "辞职申请");
            Console.WriteLine(result);
        }
    }

    public async Task ExecSql()
    {
        using (var ctx = new EFCoreDbContext())
        {
            var opt = new EfCoreDbOperations<EFCoreDbContext, Node>(ctx);
            var result = await opt.ExecOriginalSql("select *  from t_node where id=@id", new { id = 1 });
        }

    }


    #region 批量更新，删除
    public void DeleteEntityBatch()
    {
        using (EFCoreDbContext ctx = new EFCoreDbContext())
        {
            ctx.Nodes.Where(x => x.Id >= 19).ExecuteDelete();
            ctx.SaveChanges();
        }
    }

    public void UpdateEntityBatch()
    {
        using (EFCoreDbContext ctx = new EFCoreDbContext())
        {
            ctx.Nodes.Where(x => x.Id > 3).ExecuteUpdate(s => s.SetProperty(b => b.Name, b => b.Name + "test"));
            ctx.SaveChanges();
        }
    }

    #endregion



    #region 表达式树测试
    public void ExpressionTree()
    {
        Expression<Func<Book, bool>> express1 = b => b.Name == "test";
        Console.WriteLine(express1.ToString("Factory methods", "C#")); ;


        Expression<Func<Book, object[]>> express2 = x => new object[] { x.Name, x.Description };
        Console.WriteLine(express2.ToString("Factory methods", "C#")); ;


        // Func<Book, bool> func1 = b => b.Name.Contains("a");
        using (var ctx = new EFCoreDbContext())
        {
            // ctx.Books.Where(express1).ToArray();
            // ctx.Books.Where(func1).ToArray();
            var result = ctx.Books.Where(WhereExpression("Name", "", "C#方法论")).ToList();
            var result2 = ctx.Books.Select(SelectExpression("Id","Name")).ToList();
            Console.WriteLine(result.Count);
        }
    }
    Expression<Func<Book, object[]>> SelectExpression(params string[] columns)
    {

        var parameter = Parameter(
            typeof(Book),
            "parameter"
        );
        List<Expression> members = new List<Expression>();
        foreach (var column in columns)
        {
           var member= MakeMemberAccess(parameter, typeof(Book).GetProperty(column));
            members.Add(Convert(member,typeof(object)));
        }
        var express = Lambda<Func<Book, object[]>>(NewArrayInit(typeof(object),members ), parameter);
        return express;
    }



    Expression<Func<Book, bool>> WhereExpression(string propertyName, string opType, object value)
    {
        Type valueType = typeof(Book).GetProperty(propertyName).PropertyType;
        // using static System.Linq.Expressions.Expression
        Expression<Func<Book, bool>> express;

        var parameter = Parameter(typeof(Book), "parameter");
        var left = MakeMemberAccess(parameter, typeof(Book).GetProperty(propertyName));
        var right = Constant(System.Convert.ChangeType(value, valueType));
        Expression body;
        if (valueType.IsPrimitive)
        {
            body = MakeBinary(ExpressionType.Equal, left, right);
        }
        else
        {
            body = Equal(left, right);
        }
        express = Lambda<Func<Book, bool>>(body, parameter);
        return express;
    }



    #endregion



    /// <summary>
    /// 读取文件
    /// </summary>
    public void ReadFromFile()
    { 
     
    }
}