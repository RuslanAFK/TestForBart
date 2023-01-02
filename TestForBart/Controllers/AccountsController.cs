using Microsoft.AspNetCore.Mvc;
using TestForBart.Core.Entities;
using TestForBart.Models;
using TestForBart.Persistence;

namespace TestForBart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AccountsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Account>> CreateAccount(CreateAccountViewModel model)
        {
            var inc = _context.Incidents.SingleOrDefault(i => i.Name == model.IncidentName);
            // Nothing to link to
            if (inc == null)
            {
                return NotFound();
            }
            var contact = new Contact
            {
                FirstName = model.ContactFirstName,
                LastName = model.ContactLastName,
                Email = model.ContactEmail
            };
            var acc = new Account
            {
                Name = model.Name,
                Contacts = { contact },
                Incident = inc
            };
            _context.Accounts.Add(acc);
            await _context.SaveChangesAsync();

            return acc;
        }
    }
}
