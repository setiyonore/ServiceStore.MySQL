using System;
using System.Collections.Generic;

namespace ServiceStore.Models
{
    public partial class TransactionDetail
    {
        public int Id { get; set; }
        public int? IdTransaction { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
    }
}
