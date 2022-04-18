using System;
using System.Collections.Generic;

namespace ServiceStore.Models
{
    public partial class Invoice
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime? Date { get; set; }
        public string? InvoiceCode { get; set; }
        public string? ShippingCost { get; set; }
        public string? TotalPrice { get; set; }
        public string? ShippingAddress { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public string? PaymentStatus { get; set; }
    }
}
