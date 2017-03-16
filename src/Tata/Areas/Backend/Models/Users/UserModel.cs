using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tata.Entities.Enums;

namespace Tata.Areas.Backend.Models.Users
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public SettingValueType TypeValue { get; set; }
        public string Section { get; set; }
        public int Priority { get; set; }
        public string CreatedUserId { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
