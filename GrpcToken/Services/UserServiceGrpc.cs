using Grpc.Core;
using GrpcToken.Apis;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace GrpcToken.Services;

public class UserServiceGrpc : UserService.UserServiceBase
{
    private readonly IUserService _UserService;

    public UserServiceGrpc(IUserService UserService)
    {
        _UserService = UserService;
    }

    [Authorize]
    public override Task<UserResponse> GetUser(UserRequest request, ServerCallContext context)
    {
        UserResponse response = new UserResponse();
        var User = _UserService.GetUser();
        response.User = new UserDtoGrpc()
        {
            Id = User.Id,
            Name = User.Name,
            Address = User.Address,
            Email = User.Email,
            Phone = User.Phone,
            JwtVersion = User.JwtVersion,
            Password = User.Password
        };
        return Task.FromResult(response);
    }

}