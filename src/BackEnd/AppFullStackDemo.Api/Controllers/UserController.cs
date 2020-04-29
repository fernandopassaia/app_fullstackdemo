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

        // [HttpPost]
        // [Route("v1/Login")]
        // public async Task<IActionResult> Post([FromBody]LoginUserCommand command)
        // {
        //     var result = await _handler.HandleLoginUser(command);
        //     if (result.Message != "Email ou senha não localizados!")
        //     {
        //         var userClaimsList = (List<string>)result.Data;

        //         //Here I'll check if the User Was Authenticated
        //         if (result.Success == false)
        //             return BadRequest(result);

        //         //Here I'll load the Owner of the Token and Refresh Token (Will be used to Generate and Store Both in DB)
        //         var employee = await _employeeRepository.GetByIdAsync(Guid.Parse(result.IdUser)); //I load the Employee (to save the new RefreshToken for employee)
        //         var company = await _companyRepository.GetByIdAsync(employee.Subsidiary.Company.Id);
        //         //I'll remove any OLD Token and RefreshToken possible...
        //         await _tokenRepository.RemoveOldTokens(employee);
        //         await _refreshTokenRepository.RemoveOldRefreshTokens(employee);

        //         var refreshToken = new JwtGenerator(_appSettings).GenerateRefreshToken(employee); //will generate a RefreshToken
        //         await _refreshTokenRepository.Save(refreshToken); //will remove OLD refresh-tokens and add the new one

        //         var token = new JwtGenerator(_appSettings).GenerateToken(result, userClaimsList);
        //         Token userToken = new Token(employee, DateTime.UtcNow.AddMinutes(_appSettings.ExpirationInMinutes), token);
        //         await _tokenRepository.Save(userToken); //will remove the OLD tokens and add the new one

        //         //Here I'll Create a Object (with Token and RefreshToken), Then, Serialize it to a JSON to Return...
        //         var tokenAndRefreshToken = new TokenAndRefreshTokenResult() { token = token, refreshToken = refreshToken.RefreshTokenKey, companyName = company.Name.FirstName, employeeName = employee.Name.ToString(), employeeEmail = employee.Email.EmailAddress, employeeId = employee.Id.ToString(), companyLogoUrl = "http://www.futuradata.com.br/acback/Resources/" + company.LogoUrl, loggedSuccessful = true };
        //         //var tokenAndRefreshTokenJson = Helpers.JsonSerializer.SerializeObject(tokenAndRefreshTokenObjToSerialize);
        //         //return Ok(new { tokenAndRefreshToken }); //Do Not need to Jsonfy it, so I'll return the Own Result

        //         //tive que mudar o tipo de retorno, por que preciso chamar o "Response" e passar o token, por que o UOW precisa ser chamado pra salvar o backGroundTask (caso exista)
        //         return await Response(new Domain.Commands.BaseCommandResult(true, "Logado com Sucesso", tokenAndRefreshToken)); //Do Not need to Jsonfy it, so I'll return the Own Result
        //     }
        //     //return Ok(new TokenAndRefreshTokenResult() { token = "", refreshToken = "", loggedSuccessful = false });
        //     return await Response(new Domain.Commands.BaseCommandResult(false, "Nome de Usuário ou Senha inválidos.", null)); //Do Not need to Jsonfy it, so I'll return the Own Result
        // }

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











