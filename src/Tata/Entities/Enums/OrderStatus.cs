using System.ComponentModel.DataAnnotations;

namespace Tata.Entities.Enums
{
    public enum OrderStatus
    {
        Unpaid, Paid
    }

    public enum OrderItemStatus
    {
        [Display(Name = "Not Process")]
        NotProcess,

        [Display(Name = "Processed")]
        Processing,

        [Display(Name = "Done")]
        Done
    }
}
