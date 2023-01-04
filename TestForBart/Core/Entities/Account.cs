using Microsoft.EntityFrameworkCore;

namespace TestForBart.Core.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Incident Incident { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
