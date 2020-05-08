using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AppFullStackDemo.Domain.Handlers;
using AppFullStackDemo.Domain.Repositories;
using AppFullStackDemo.Infra.Transactions;
using System;
using System.Collections.Generic;
using AppFullStackDemo.Domain.Commands.DeviceModel;
using AppFullStackDemo.Domain.Results.DeviceModel;

namespace AppFullStackDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceModelController : BaseController
    {
        private readonly DeviceModelHandler _handler;

        private readonly IDeviceModelRepository _repository;

        private readonly IUow _uow;

        public DeviceModelController(IUow uow, IDeviceModelRepository repository, DeviceModelHandler handler) : base(uow)
        {
            _uow = uow;
            _repository = repository;
            _handler = handler;
        }

        [HttpPost]
        [Route("v1")]
        [Authorize(Roles = "devicemodel")]
        public async Task<IActionResult> Post([FromBody] CreateDeviceModelCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result);
        }

        [HttpPut]
        [Route("v1/{id}")]
        [Authorize(Roles = "devicemodel")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateDeviceModelCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result);
        }

        [HttpDelete]
        [Route("v1/{id}")]
        [Authorize(Roles = "devicemodel")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = _handler.Handle(id);
            return await Response(result);
        }

        [HttpGet]
        [Route("v1")]
        [Authorize(Roles = "devicemodel")]
        public IEnumerable<GetDeviceModelResult> GetDeviceModels()
        {
            return _repository.GetDeviceModels();
        }

        [HttpGet]
        [Route("v1/{id}")]
        [Authorize(Roles = "devicemodel")]
        public GetDeviceModelResult GetManufacturer([FromRoute] Guid id)
        {
            return _repository.GetDeviceModel(id);
        }
    }
}