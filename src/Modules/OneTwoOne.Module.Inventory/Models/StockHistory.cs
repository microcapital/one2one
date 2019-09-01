﻿using System;
using System.ComponentModel.DataAnnotations;
using OneTwoOne.Infrastructure.Models;
using OneTwoOne.Module.Catalog.Models;
using OneTwoOne.Module.Core.Models;

namespace OneTwoOne.Module.Inventory.Models
{
    public class StockHistory : EntityBase
    {
        public long ProductId { get; set; }

        public Product Product { get; set; }

        public long WarehouseId { get; set; }

        public Warehouse Warehouse { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public long CreatedById { get; set; }

        public User CreatedBy { get; set; }

        public long AdjustedQuantity { get; set; }

        [StringLength(1000)]
        public string Note { get; set; }
    }
}
