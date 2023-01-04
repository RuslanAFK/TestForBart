using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestForBart.Core.Entities
{
    public class Incident
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
