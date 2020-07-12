using AutoMapper;
using CRM.API.Commands;
using CRM.API.DTOs;
using CRM.API.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public ContactsController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDTO>>> GetAllContacts()
        {
            GetAllContactsQuery query = new GetAllContactsQuery();

            return Ok(await mediator.Send(query));
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDTO>> GetContactById([FromRoute] Guid id)
        {
            GetContactByIdQuery query = new GetContactByIdQuery(id);

            ContactDTO contact = await mediator.Send(query);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        // POST: api/Contacts
        [HttpPost]
        public async Task<ActionResult<ContactDTO>> CreateContact([FromBody] ContactCreateDTO contactCreateDTO)
        {
            CreateContactCommand command = mapper.Map<CreateContactCommand>(contactCreateDTO);

            ContactDTO contact = await mediator.Send(command);

            return CreatedAtAction("GetContactById", new { id = contact.Id }, contact);
        }

        // TODO
        //// PUT: api/Contacts/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateContact(Guid id, Contact contact)
        //{
        //    if (id != contact.Id)
        //    {
        //        return BadRequest();
        //    }

        //    context.Entry(contact).State = EntityState.Modified;

        //    try
        //    {
        //        await context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ContactExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// DELETE: api/Contacts/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Contact>> DeleteContact([FromRoute] Guid id)
        //{
        //    var contact = await context.Contact.FindAsync(id);
        //    if (contact == null)
        //    {
        //        return NotFound();
        //    }

        //    context.Contact.Remove(contact);
        //    await context.SaveChangesAsync();

        //    return contact;
        //}

        //private bool ContactExists(Guid id)
        //{
        //    return context.Contact.Any(e => e.Id == id);
        //}
    }
}
