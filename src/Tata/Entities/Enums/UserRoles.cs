using System.ComponentModel.DataAnnotations;

namespace Tata.Entities.Enums
{
    public static class UserRoles
    {
        public const string Guest = "Guest";
        public const string Standard = "Standard";
        public const string Seller = "Seller";
        public const string ContentManager = "ContentManager";
        public const string Administrator = "Administrator";
    }

    public enum UserRoleValue
    {
        [Display(Name = "Guest")]
        Guest,

        [Display(Name = "Standard")]
        Standard,

        [Display(Name = "Seller")]
        Seller,

        [Display(Name = "Content Manager")]
        ContentManager,

        [Display(Name = "Administrator")]
        Administrator
    }
}
