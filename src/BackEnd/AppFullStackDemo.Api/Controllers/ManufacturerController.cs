using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AppFullStackDemo.Domain.Handlers;
using AppFullStackDemo.Domain.Repositories;
using AppFullStackDemo.Infra.Transactions;
using AppFullStackDemo.Domain.Commands.Manufacturer;

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

        // [HttpGet]
        // [Route("v1")]
        // [Authorize(Roles = "manufacturer.list")]
        // public async Task<IEnumerable<GetManufacturerResult>> Get()
        // {
        //     return await _repository.GetAsync();
        // }

        // [HttpGet]
        // [Route("v1/{id}")]
        // [Authorize(Roles = "manufacturer.list")]
        // public async Task<UpdateManufacturerCommand> GetById(Guid id)
        // {
        //     return await _repository.GetEntityByIdAsync(id);
        // }

        [HttpPost]
        [Route("v1")]
        [Authorize(Roles = "manufacturer.create")]
        public async Task<IActionResult> Post([FromBody]CreateManufacturerCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result);
        }

        [HttpPut]
        [Route("v1")]
        [Authorize(Roles = "manufacturer.update")]
        public async Task<IActionResult> Put([FromBody]UpdateManufacturerCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result);
        }
    }
}