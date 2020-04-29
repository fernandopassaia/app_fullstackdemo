using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AppFullStackDemo.Domain.Handlers;
using AppFullStackDemo.Domain.Repositories;
using AppFullStackDemo.Infra.Transactions;
using AppFullStackDemo.Domain.Commands.User;
using AppFullStackDemo.Domain.Results;
using System.Collections.Generic;
using AppFullStackDemo.Api.Controllers.Security;
using AppFullStackDemo.Api.Models;
using Microsoft.Extensions.Options;

namespace AppFullStackDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly UserHandler _handler;

        private readonly IUserRepository _repository;

        private readonly IUow _uow;
        private readonly AppSettings _appSettings; //here i will get the Values storage in appsettings.json that will be used to generate my Token

        public UserController(IUow uow, IUserRepository repository, UserHandler handler, IOptions<AppSettings> appSettings) : base(uow)
        {
            _uow = uow;
            _repository = repository;
            _handler = handler;
            _appSettings = appSettings.Value;
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
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginUserCommand command)
        {
            var result = _handler.Handle(command);
            if (result.Success == true)
            {
                var userClaimsList = (List<string>)result.Data;
                var user = _repository.GetByLogin(command.UserName);
                var token = new JwtGenerator(_appSettings).GenerateToken(result, userClaimsList);
                return Ok(new { token });
            }

            return await Response(new BaseCommandResult(false, "Username or Password invalid.", null)); //Do Not need to Jsonfy it, so I'll return the Own Result            
        }
    }
}











