using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tata.Entities.Enums
{
    public enum UserProductStatus
    {
        [Display(Name = "Not Process")]
        NotProcess,

        [Display(Name = "Processed")]
        Processing,

        [Display(Name = "Done")]
        Done
    }
}
