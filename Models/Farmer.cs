using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PROG7311_POE_PART_2.Models
{
    public class Farmer
    {
        public int Id { get; set; }
        public string UserId { get; set; } // Foreign key to IdentityUser
        public IdentityUser User { get; set; }

        public string FullName { get; set; }
        public string FarmName { get; set; }
        public string Location { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
