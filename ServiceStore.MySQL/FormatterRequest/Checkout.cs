namespace ServiceStore.MySQL.FormatterRequest;

public class Checkout
{
    public class products
    {
        public List<product>? Products { get; set; }
        public string shipping_adress { get; set; }
        public string province_id { get; set; }
        public string city_id { get; set; }
        public int shipping_cost { get; set; }
        public int amount_products_price { get; set; }
        public int total_price { get; set; }
    }
    
    public class product
    {
        public int product_id { get; set; }
        public int quantity { get; set; }
    }
}