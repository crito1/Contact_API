using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private readonly ContactContext _context;

        //Creates Test Contact 
        public ContactController(ContactContext context)
        {
            _context = context;

            if (_context.Contacts.Count() == 0)
            {
                _context.Contacts.Add(new Contact
                {
                    FirstName = "Test",
                    LastName = "Contact",
                    PhonePersonal = 5555555555,
                    Email = "Test@Gmail.com",
                    Address = "231 N. Pine Grove",
                    City = "Chicago",
                    State = "IL"
                });

                _context.SaveChanges();
            }
        }


        //GET api/Contact 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            return await _context.Contacts.ToListAsync();
        }


        //GET api/Contact/5
        [HttpGet("{contactId}")]
        public async Task<ActionResult<Contact>> GetContact(int contactId)
        {
            var contact = await _context.Contacts.FindAsync(contactId);

            if(contact == null)
            {
                return NotFound();
            }

            return contact;
        }


        //GET: api/Contact
        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContact), new { contactId = contact.ContactId }, contact);

        }

        //PUT: api/Contact
        [HttpPut("{contactId}")]
        public async Task<ActionResult<Contact>> PutContact(int contactId, Contact contact)
        {

            if (contactId != contact.ContactId)
                return BadRequest();


            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();

        }


        //DELETE: api/Contact/3
        [HttpDelete("{contactId}")]
        public async Task<ActionResult<Contact>> DeleteContact(int contactId)
        {

            var contact = await _context.Contacts.FindAsync(contactId);

            if (contact == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return NoContent();

        }

    }

}
