using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.Contact;
using MultiShop.Catalog.Services.ContactServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> ContactListAsync()
        { 
            var values=await _contactService.ContactListAsync();
            return Ok(values);
        }
        [HttpGet("{contactId}")]
        public async Task<IActionResult> GetContactByIdAsync(string contactId)
        { 
            var value=await _contactService.GetContactByIdAsync(contactId);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContactAsync(CreateContactDto createContactDto)
        {
            await _contactService.CreateContactAsync(createContactDto);
            return Ok($"The {createContactDto.FullName} Contact message had added successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            await _contactService.UpdateContactAsync(updateContactDto);
            return Ok("Contact message had updated successfully");
        }
        [HttpDelete("{contactId}")]
        public async Task<IActionResult> DeleteContactAsync(string contactId)
        {
            await _contactService.DeleteContactAsync(contactId);
            return Ok($"The Contact message number of {contactId} had deleted successfully");
        }


    }
}
