﻿using System.Collections.Generic;

namespace OneTwoOne.Module.ProductComparison.Areas.ProductComparison.ViewModels
{
    public class ProductComparisonVm
    {
        public IList<ComparingProductVm> Products { get; set; } = new List<ComparingProductVm>();

        public IList<AttributeVm> Attributes { get; set; } = new List<AttributeVm>();
    }
}
