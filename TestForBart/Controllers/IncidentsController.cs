using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestForBart.Core.Entities;
using TestForBart.Models;
using TestForBart.Persistence;

namespace TestForBart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public IncidentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Incident>> CreateIncident(CreateIncidentViewModel model)
        {
            var contact = new Contact
            {
                FirstName = model.ContactFirstName,
                LastName = model.ContactLastName,
                Email = model.ContactEmail
            };
            var acc = new Account
            {
                Name = model.AccountName,
                Contacts = { contact }
            };
            var incident = new Incident
            {
                Description = model.Description,
                Accounts = { acc }
            };
            _context.Incidents.Add(incident);
            await _context.SaveChangesAsync();

            return incident;
        }
    }
}
