
using System.ComponentModel.DataAnnotations;

namespace TestForBart.Models
{
    public class CreateIncidentViewModel
    {
        public string AccountName { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactEmail { get; set; }
        public string Description { get; set; }
    }
}
