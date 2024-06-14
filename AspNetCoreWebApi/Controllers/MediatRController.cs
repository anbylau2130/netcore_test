using AspNetCoreWebApi.JWT;
using AspNetCoreWebApi.MediatR;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MediatRController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly BaseDbContext dbContext;

        public MediatRController(IMediator mediator, BaseDbContext dbContext)
        {
            this.mediator = mediator;
            this.dbContext= dbContext;
        }

        [NotCheckJwtVersion]
        [HttpPost]
        public int Add(int a,int b)
        {
            this.mediator.Publish(new PostNotification("hello guys"));
            return a+b;
        }

        [NotCheckJwtVersion]
        [HttpPost]
        public async Task CreateMaterial()
        {
            Material mtr = new Material("物料001","kg",18.001);
            dbContext.Add(mtr);
            await dbContext.SaveChangesAsync();
        }
    }
}
