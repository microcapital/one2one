using System;
using OneTwoOne.Infrastructure.Models;
using OneTwoOne.Module.Catalog.Models;
using OneTwoOne.Module.Core.Models;

namespace OneTwoOne.Module.ProductComparison.Models
{
    public class ComparingProduct : EntityBase
    {
        public DateTimeOffset CreatedOn { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }

        public long ProductId { get; set; }

        public Product Product { get; set; }
    }
}
