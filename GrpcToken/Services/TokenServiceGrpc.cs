using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcToken.Apis;


namespace GrpcToken.Services;

public class TokenServiceGrpc:TokenService.TokenServiceBase
{
    private readonly ITokenService _tokenService;

    public TokenServiceGrpc(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    public override Task<TokenResponse> GetToken(Empty request, ServerCallContext context)
    {
        var response = new TokenResponse();
        response.Token= _tokenService.GetToken();
        return Task.FromResult(response);
    }
}