using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AppFullStackDemo.Domain.Handlers;
using AppFullStackDemo.Domain.Repositories;
using AppFullStackDemo.Infra.Transactions;
using AppFullStackDemo.Domain.Commands.Manufacturer;
using System;
using System.Collections.Generic;

namespace AppFullStackDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : BaseController
    {
        private readonly ManufacturerHandler _handler;

        private readonly IManufacturerRepository _repository;

        private readonly IUow _uow;

        public ManufacturerController(IUow uow, IManufacturerRepository repository, ManufacturerHandler handler) : base(uow)
        {
            _uow = uow;
            _repository = repository;
            _handler = handler;
        }

        [HttpPost]
        [Route("v1")]
        [Authorize(Roles = "manufacturer")]
        public async Task<IActionResult> Post([FromBody] CreateManufacturerCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result);
        }

        [HttpPut]
        [Route("v1/{Id}")]
        [Authorize(Roles = "manufacturer")]
        public async Task<IActionResult> Put([FromRoute] Guid Id, [FromBody] UpdateManufacturerCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result);
        }

        [HttpDelete]
        [Route("v1/{Id}")]
        [Authorize(Roles = "manufacturer")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            var result = _handler.Handle(Id);
            return await Response(result);
        }

        [HttpGet]
        [Route("v1")]
        [Authorize(Roles = "manufacturer")]
        public IEnumerable<GetManufacturerResult> GetManufacturers()
        {
            return _repository.GetManufacturers();
        }

        [HttpGet]
        [Route("v1/{Id}")]
        [Authorize(Roles = "manufacturer")]
        public GetManufacturerResult GetManufacturer([FromRoute] Guid Id)
        {
            return _repository.GetManufacturer(Id);
        }
    }
}