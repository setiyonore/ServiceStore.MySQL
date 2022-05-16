namespace ServiceStore.MySQL.DataTransferObejct
{
    public class City
    {
        public rajaOngkirCity? rajaongkir { get; set; }
        
    }

    public class rajaOngkirCity
    {
        public queryCity? query { get; set; }
        public statusCity? status { get; set; }
        public List<resultsCity>? results { get; set; }
    }

    public class queryCity
    {
        public string id { get; set; }
        public string province { get; set; }
    }
    
    public class statusCity
    {
        public string code { get; set; }
        public string description { get; set; }
    }
    public class resultsCity
    {
        public string city_id { get; set; }
        public string province_id { get; set; }
        public string province { get; set; }
        public string type { get; set; }
        public string city_name { get; set; }
        public string postal_code { get; set; }
    }
    
}

