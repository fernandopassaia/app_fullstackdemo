using AppFullStackDemo.Domain.Commands;
using AppFullStackDemo.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AppFullStackDemo.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        //this is to Padronize all my returns of API
        private readonly IUow _uow;

        public BaseController(IUow uow)
        {
            _uow = uow;
        }

        [NonAction] //need decorator because Swagger is trying to build this method and falling into error
        public new async Task<IActionResult> Response(IBaseCommandResult baseCommandResult)
        {
            if (baseCommandResult.Success)
            {
                try
                {
                    await _uow.Commit();
                    return Ok(new
                    {
                        Success = true,
                        Message = baseCommandResult.Message,
                        ResponseDataObj = baseCommandResult.ResponseDataObj
                    });
                }
                catch (Exception err)
                {
                    //log the error with something (like Elmah)
                    return BadRequest(new
                    {
                        Success = false,
                        Message = baseCommandResult.Message,
                        ResponseDataObj = new[] { "A Internal-Server error occured: " + err.Message.ToString() }
                    });
                }
            }
            else
            {
                //Note: The BackEnd will return 400 just when there is an exception. In case of validation errors or backend message, it will return an 200 OK
                //(because the backend don't generate an error) but with a "False" on the Success boolean flag, and the respective message to fix the errors.
                //FrontEnd apps should intercept the flag, and show the respective message to the user. So 200 but "false" on Success is an error that should be
                //fixed by the User. Remember that inside the "Errors" there is an array, that i should open and get all errors, showing them to user
                return Ok(new
                {
                    Success = false,
                    Message = baseCommandResult.Message,
                    ResponseDataObj = baseCommandResult.ResponseDataObj
                });
            }
        }
    }
}