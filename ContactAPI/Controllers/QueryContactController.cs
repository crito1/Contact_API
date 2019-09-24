using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryContactController : ControllerBase
    {

        private readonly ContactContext _context;


        public QueryContactController(ContactContext context)
        {
            _context = context;
        }


        //GET api/QueryContact/email/test@Email.com
        [HttpGet("email/{email}")]
        public async Task<ActionResult<Contact>> GetContactEmail(string email)
        {
            var contact = _context.Contacts.Where(x => x.Email == email).FirstOrDefault() ;

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        //GET api/QueryContact/phone/5555555555
        [HttpGet("phone/{phone}")]
        public async Task<ActionResult<Contact>> GetContactPhone(long phone)
        {
            var contact = _context.Contacts.Where(x => x.PhonePersonal == phone  || x.PhoneWork == phone).FirstOrDefault();

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        //GET api/QueryContact/state/OH
        //Retrieves all contacts from state
        [HttpGet("state/{state}")]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContactState(string state)
        {
            var contact = _context.Contacts.Where(x => x.State == state).ToList();

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        //GET api/QueryContact/city/chicago
        //Retrieves all contacts from city
        [HttpGet("city/{city}")]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContactCity(string city)
        {
            var contact = _context.Contacts.Where(x => x.City == city).ToList();

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }



    }
}
