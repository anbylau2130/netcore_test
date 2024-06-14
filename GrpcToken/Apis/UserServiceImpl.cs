namespace GrpcToken.Apis;

public class UserServiceImpl : IUserService
{
    public User GetUser()
    {
        return new User()
        {
            Id = 1,
            Name = "Test",
            Email = "123456@qq.com",
            Phone = "13011111111",
            Address = "China",
            Password = "123456",
            JwtVersion="1"
        };
    }
}