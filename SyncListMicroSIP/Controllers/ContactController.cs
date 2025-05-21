using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SyncListMicroSIP.Dtos;
using SyncListMicroSIP.Interface;
using SyncListMicroSIP.Models;

namespace SyncListMicroSIP.Controllers
{
    [ApiController]
    [Route("v1/contact")]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [Authorize]
        [HttpPost("")]
        public async Task<IActionResult> PostContact([FromBody] PostContactDto postContactDto)
        {
            var contact = new Contact()
            {
                Name = postContactDto.Name,
                Number = postContactDto.Number,
            };

            await _contactRepository.InsertContact(contact);

            if (!(await _contactRepository.SaveChanges()))
            {
                return BadRequest(new ResponseDto<string>("Erro no banco! Não foi possivel salvar"));
            }

            return Created($"v1/contact/{contact.Number}", new ResponseDto<string>($"Usuario Ramal = {contact.Number} criado com sucesso!"));
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            var contacts = await _contactRepository.GetContacts();

            return Ok(new ResponseDto<IEnumerable<Contact>>(contacts));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact([FromRoute] string id)
        {
            var contact = await _contactRepository.DeleteContact(id);

            if (contact == null) 
            {
                return NotFound(new ResponseDto<string>($"Ramal {id} não encontrado!"));
            }

            if (!(await _contactRepository.SaveChanges()))
            {
                return BadRequest(new ResponseDto<string>("Erro no banco! Não foi possivel salvar"));
            }

            return Ok(new ResponseDto<string>($"Usuario Id = {contact.Number} removido com sucesso!"));
        }
    }
}
