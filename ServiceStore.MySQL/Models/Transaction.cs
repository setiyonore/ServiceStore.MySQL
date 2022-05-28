using System;
using System.Collections.Generic;

namespace ServiceStore.Models
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? TotalPrice { get; set; }
        public int? ShippingCost { get; set; }
        public int? AmountProductsPrice { get; set; }
        public string? InvoiceCode { get; set; }
        public string? ShippingAddress { get; set; }
        public string? ProvinceId { get; set; }
        public string? CityId { get; set; }
        public string? PaymentStatus { get; set; }
        public int? UserId { get; set; }
    }
}
