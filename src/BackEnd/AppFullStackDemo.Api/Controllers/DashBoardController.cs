using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AppFullStackDemo.Domain.Handlers;
using AppFullStackDemo.Domain.Repositories;
using AppFullStackDemo.Infra.Transactions;
using AppFullStackDemo.Domain.Commands.Manufacturer;
using System;
using System.Collections.Generic;
using AppFullStackDemo.Domain.Results.Manufacturer;
using AppFullStackDemo.Domain.Results.DashBoard;
using AppFullStackDemo.Domain.Results;

namespace AppFullStackDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : BaseController
    {
        private readonly DashBoardHandler _handler;
        private readonly IUow _uow;

        public DashBoardController(IUow uow, DashBoardHandler handler) : base(uow)
        {
            _uow = uow;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1")]
        [Authorize(Roles = "dashboard")]
        public BaseCommandResult Get()
        {
            return _handler.HandleDashBoard();
        }
    }
}