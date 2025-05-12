using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PROG7311_POE_PART_2.Models
{
    public class Farmer
    {
        public int Id { get; set; }
        public string UserId { get; set; } // Foreign key to IdentityUser
        public IdentityUser User { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Surname { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string FarmName { get; set; }

        public string FarmAddress { get; set; }

        public string FarmType { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
