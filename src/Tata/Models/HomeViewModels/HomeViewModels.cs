using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tata.Entities;

namespace Tata.Models
{
    public class HomeViewModels
    {
        public IEnumerable<Setting> CommonSettings { get; set; }
    }
}
