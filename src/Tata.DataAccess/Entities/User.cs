using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TaTa.DataAccess.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public UserType UserType { get; set; }
        public string Organization { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum UserType
    {
        Personal,
        Organization
    }
}
