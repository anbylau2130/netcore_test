namespace EFCoreDDDTest.DDD;

public class User
{
    public long Id { get; init; }
    public DateTime CreateTime { get; init; }

    public string UserName { get; private set; }

    public int Credits { get; set; }


    private string? passwordHash;
    private string? remark;
    public string? Remark
    {
        get
        {
            return remark;
        }
    }

    public string? Tag { get; set; }

    /// <summary>
    /// 给EFCORE使用，从数据库读取数据然后创建User对象使用
    /// </summary>
    private User()
    {
    }

    /// <summary>
    /// 给调用者使用
    /// 如果参数名与属性名不同，如：yhm和UserName不同，需要指定私有无参构造方法
    /// </summary>
    /// <param name="yhm"></param>
    public User(string yhm)
    {
        UserName = yhm;
        CreateTime = DateTime.Now;
        Credits = 10;
    }

    public void ChangeUserName(string name)
    {
        if (name.Length < 5)
        {
            Console.WriteLine("用户名不能小于5");
            return;
        }
        UserName = name;
    }

    public void ChangePassword(string password)
    {
        if (password.Length < 5)
        {
            Console.WriteLine("密码不能小于5");
            return;
        }
        passwordHash = HashHelper.GetMd5Hash(password);

    }
}