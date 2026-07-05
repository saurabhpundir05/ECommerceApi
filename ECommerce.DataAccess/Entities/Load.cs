using ECommerce.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.DataAccess.Entities
{
    public class Load
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public LoadStatus Status { get; set; }
        public DateTime DeliveredAt { get; set; }
        public ProductRating Rating { get; set; }
    }
}
