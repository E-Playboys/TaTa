using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tata.Entities;
using Tata.Entities.Enums;

namespace Tata.Areas.Backend.Models.Product
{
    public class ProductPropertyGroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductPropertyGroupType Type { get; set; }
        public bool ForDefaultSetup { get; set; }
        public bool ForUserCustomize { get; set; }

        public List<ProductPropertyGroupValueModel> Values { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int SelectedValue { get; set; }
    }
}
