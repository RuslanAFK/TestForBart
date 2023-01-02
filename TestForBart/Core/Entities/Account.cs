using Microsoft.EntityFrameworkCore;

namespace TestForBart.Core.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Incident Incident { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
