using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;

namespace __MyServiceName__.Presentation.Controllers
{
    [EnableCors("AllowCros")]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IHttpContextAccessor httpContextAccessor;

        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public BaseController()
        {
        }

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [NonAction]
        public OkObjectResult PPlusOk() => this.Ok("API Response");

        [NonAction]
        public BadRequestObjectResult PPlusError([ActionResultObjectValue] object value, string Errors, string Message)
            => this.BadRequest("Bad Request");

    }
}
