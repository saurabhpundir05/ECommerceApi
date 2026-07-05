using ECommerce.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.DataAccess.Entities
{
    public class Discount
    {
        public int Id { get; set; } 
        public int ProductId { get; set; }
        public DiscountType Type { get; set; }
        public decimal DiscountValue { get; set; }
    }
}
