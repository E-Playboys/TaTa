﻿using System;
using Tata.Models;
using TaTa.DataAccess.Entities;

namespace Tata.Entities
{
    public class Tracking : EntityBase
    {
        public Tracking()
        {
            CreatedDate = DateTime.Now;
        }

        public string CreatedUserId { get; set; }
        public User CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
