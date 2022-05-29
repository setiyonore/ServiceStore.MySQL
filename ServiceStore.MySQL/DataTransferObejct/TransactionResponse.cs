namespace ServiceStore.MySQL.DataTransferObejct;

public class TransactionResponse
{
    public metaData? meta { get; set; }
    public data? dataTransaction { get; set; }
}

public class response
{
    public metaData? meta { get; set; }
    public data? data { get; set; }
}

public class metaData
{
    public string message { get; set; }
    public int code { get; set; }
    public string status { get; set; }
}

public class data
{
    public int Id { get; set; }
    public DateTime? Date { get; set; }
    public int TotalPrice { get; set; }
    public int ShippingCost { get; set; }
    public int AmountProductsPrice { get; set; }
    public string InvoiceCode { get; set; }
    public string ShippingAddress { get; set; }
    public string ProvinceId { get; set; }
    public string CityId { get; set; }
    public string PaymentStatus { get; set; }
    public string UserId { get; set; }
}