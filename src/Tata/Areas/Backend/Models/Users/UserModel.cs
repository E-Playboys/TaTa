using System.Collections.Generic;
using TaTa.DataAccess.Entities;

namespace Tata.Areas.Backend.Models.Users
{
    public class UserModel
    {
        public string Id { get; set; }
        public int AccessFailedCount { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public UserType UserType { get; set; }
        public string Organization { get; set; }
        public ICollection<string> Roles { get; set; }
        public ICollection<string> Claims { get; set; }
    }
}
