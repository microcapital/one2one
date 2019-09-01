using System.Collections.Generic;
using OneTwoOne.Module.Catalog.Models;

namespace OneTwoOne.Module.ProductComparison.Areas.ProductComparison.ViewModels
{
    public class ComparingProductVm
    {
        public long ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public CalculatedProductPrice CalculatedProductPrice { get; set; }

        public IList<AttributeValueVm> AttributeValues { get; set; } = new List<AttributeValueVm>();
    }
}
