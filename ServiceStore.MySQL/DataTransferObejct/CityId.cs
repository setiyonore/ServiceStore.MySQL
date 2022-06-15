namespace ServiceStore.MySQL.DataTransferObejct
{
    public class CityId
    {
        public rajaOngkirCityId? rajaongkir { get; set; }
        
    }

    public class rajaOngkirCityId
    {
        public queryCityId? query { get; set; }
        public statusCityId? status { get; set; }
        public resultsCityId? results { get; set; }
    }

    public class queryCityId
    {
        public string id { get; set; }
        public string province { get; set; }
    }
    
    public class statusCityId
    {
        public string code { get; set; }
        public string description { get; set; }
    }
    public class resultsCityId
    {
        public string city_id { get; set; }
        public string province_id { get; set; }
        public string province { get; set; }
        public string type { get; set; }
        public string city_name { get; set; }
        public string postal_code { get; set; }
    }
    
}