using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AppFullStackDemo.Domain.Handlers;
using AppFullStackDemo.Domain.Repositories;
using AppFullStackDemo.Infra.Transactions;
using System;
using System.Collections.Generic;
using AppFullStackDemo.Domain.Results.Equipment;
using AppFullStackDemo.Domain.Commands.Equipment;

namespace AppFullStackDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : BaseController
    {
        private readonly EquipmentHandler _handler;

        private readonly IEquipmentRepository _repository;

        private readonly IUow _uow;

        public EquipmentController(IUow uow, IEquipmentRepository repository, EquipmentHandler handler) : base(uow)
        {
            _uow = uow;
            _repository = repository;
            _handler = handler;
        }

        [HttpPost]
        [Route("v1")]
        [Authorize(Roles = "equipment")]
        public async Task<IActionResult> Post([FromBody] CreateEquipmentCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result);
        }

        [HttpDelete]
        [Route("v1/{id}")]
        [Authorize(Roles = "equipment")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = _handler.Handle(id);
            return await Response(result);
        }

        [HttpGet]
        [Route("v1")]
        [Authorize(Roles = "equipment")]
        public IEnumerable<GetEquipmentResultResumed> GetEquipments()
        {
            return _repository.GetEquipments();
        }

        [HttpGet]
        [Route("v1/{id}")]
        [Authorize(Roles = "equipment")]
        public GetEquipmentResult GetEquipment([FromRoute] Guid id)
        {
            return _repository.GetEquipment(id);
        }

        [HttpGet]
        [Route("v1/user/{userId}")]
        [Authorize(Roles = "equipment")]
        public IEnumerable<GetEquipmentResultResumed> GetEquipmentsByUser([FromRoute] Guid userId)
        {
            return _repository.GetEquipmentsByUser(userId);
        }
    }
}