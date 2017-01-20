using System;
using Digipolis.DataAccess.Entities;
using Tata.Models;

namespace Tata.Entities
{
    public class Tracking : EntityBase
    {
        public Tracking()
        {
            CreatedDate = DateTime.Now;
        }

        public string CreatedUserId { get; set; }
        public ApplicationUser CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
