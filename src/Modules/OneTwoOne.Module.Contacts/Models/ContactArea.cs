using System.ComponentModel.DataAnnotations;
using OneTwoOne.Infrastructure.Models;

namespace OneTwoOne.Module.Contacts.Models
{
    public class ContactArea : EntityBase
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
