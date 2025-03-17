using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAddressQueryHandler _addressQueryHandler;
        private readonly GetAddressByIdQueryHandler _addressByIdQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
        private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;
        public AddressesController(GetAddressQueryHandler addressQueryHandler, GetAddressByIdQueryHandler addressByIdQueryHandler, CreateAddressCommandHandler createAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler, RemoveAddressCommandHandler removeAddressCommandHandler)
        {
            _addressQueryHandler = addressQueryHandler;
            _addressByIdQueryHandler = addressByIdQueryHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
            _removeAddressCommandHandler = removeAddressCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var values =await _addressQueryHandler.Handle();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await _createAddressCommandHandler.Handle(command);
            return Ok("The Address Had Been Created Successfully");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> AddressListById(int id)
        {
            var values =await _addressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(values);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
        {
            await _updateAddressCommandHandler.Handle(command);
            return Ok("The Address Had been Updated Successfully");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await _removeAddressCommandHandler.Handle(new RemoveAddressCommand(id));
            return Ok("The Address Had Been Deleted Successfully");
        }

    }

    
}
