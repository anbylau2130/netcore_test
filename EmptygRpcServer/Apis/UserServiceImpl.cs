
namespace EmptygRpcServer.Apis
{
    public class UserServiceImpl : IUserService
    {
       public List<UserInfo> GetUserInfo()
        {
            return new List<UserInfo>
            {
                new UserInfo(){
                    Id = 1,
                    Name = "Test",
                },
                new UserInfo()
                {
                    Id = 2,
                    Name = "Test2",
                },
                new UserInfo()
                {
                    Id = 3,
                    Name = "Test3",
                }
            };
        }
    }
}
