using ECommerce.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.DataAccess.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public PaymentType Type {  get; set; }
        public PaymentStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Price { get; set; }
    }
}
