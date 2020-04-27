using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AppFullStackDemo.Domain.Handlers;
using AppFullStackDemo.Domain.Repositories;
using AppFullStackDemo.Infra.Transactions;
using AppFullStackDemo.Domain.Commands.User;

namespace AppFullStackDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly UserHandler _handler;

        private readonly IUserRepository _repository;

        private readonly IUow _uow;

        public UserController(IUow uow, IUserRepository repository, UserHandler handler) : base(uow)
        {
            _uow = uow;
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/test")]
        [AllowAnonymous]
        public string GetTest()
        {
            return "Api AppFullStackDemo is Working!";
        }

        [HttpPost]
        [Route("v1")]
        [Authorize(Roles = "user.create")]
        public async Task<IActionResult> Post([FromBody]CreateUserCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result);
        }

        [HttpPut]
        [Route("v1")]
        [Authorize(Roles = "user.update")]
        public async Task<IActionResult> Put([FromBody]UpdateUserCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result);
        }

        [HttpPost]
        [Route("v1/Login")]
        public async Task<IActionResult> Login([FromBody]LoginUserCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result);
        }
    }
}











