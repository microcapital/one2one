using OneTwoOne.Infrastructure.Models;
using OneTwoOne.Module.Core.Models;

namespace OneTwoOne.Module.Catalog.Models
{
    public class ProductMedia : EntityBase
    {
        public long ProductId { get; set; }

        public Product Product { get; set; }

        public long MediaId { get; set; }

        public Media Media { get; set; }

        public int DisplayOrder { get; set; }
    }
}
