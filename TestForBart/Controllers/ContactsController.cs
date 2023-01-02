using Microsoft.AspNetCore.Mvc;
using TestForBart.Core.Entities;
using TestForBart.Models;
using TestForBart.Persistence;

namespace TestForBart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContactsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> CreateContact(CreateContactViewModel model)
        {
            var acc = _context.Accounts.SingleOrDefault(a => a.Name == model.AccountName);
            // If there is no account to link to
            if(acc == null)
                return NotFound();

            var contact = _context.Contacts.SingleOrDefault(c => c.Email == model.Email);
            // Add if contact doesn't exist
            if(contact == null)
            {
                contact = new Contact
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Account = acc
                };
                _context.Contacts.Add(contact);
            }
            // Update if contact does exist
            else
            {
                contact.Account = acc;
                contact.FirstName = model.FirstName;
                contact.LastName = model.LastName;
            }

            await _context.SaveChangesAsync();

            return contact;
        }
    }
}
