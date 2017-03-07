using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TaTa.DataAccess.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }

        public string Address { get; set; }
    }
}
