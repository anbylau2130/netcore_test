using EmptygRpcServer.Apis;
using Grpc.Core;

namespace EmptygRpcServer.Services
{
    public class UserServiceGrpc:UserService.UserServiceBase
    {
        private readonly IUserService _userService;

        public UserServiceGrpc(IUserService userService)
        {
            _userService = userService;
        }

        public override Task<UserResponse> GetUserInfo(UserRequest request, ServerCallContext context)
        {
            UserResponse response = new UserResponse();
            var userInfos= _userService.GetUserInfo();
            foreach(var userInfo in userInfos)
            {
                response.UserList.Add(new UserDtoGrpc() { Id=userInfo.Id,Name=userInfo.Name});
            }
            return Task.FromResult(response);
        }

    }
}
