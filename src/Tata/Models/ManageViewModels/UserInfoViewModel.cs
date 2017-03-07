using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Tata.Models.ManageViewModels
{
    public class UserInfoViewModel
    {
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
    }
}
