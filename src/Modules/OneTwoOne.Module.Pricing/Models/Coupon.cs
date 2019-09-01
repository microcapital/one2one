using System;
using System.ComponentModel.DataAnnotations;
using OneTwoOne.Infrastructure.Models;

namespace OneTwoOne.Module.Pricing.Models
{
    public class Coupon : EntityBase
    {
        public Coupon ()
        {
            CreatedOn = DateTimeOffset.Now;
        }

        public long CartRuleId { get; set; }

        public CartRule CartRule { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string Code { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
    }
}
