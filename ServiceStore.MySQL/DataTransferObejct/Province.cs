using System.Text.Json.Serialization;
namespace ServiceStore.MySQL.DataTransferObejct
{
    [Serializable]
    public class Province
    {
        public rajaongkir? rajaongkir { get; set; }

    }
    public class rajaongkir
    {
        //public Query? query { get; set; }
        public string[]? query = new string[] { };
        public status? status { get; set; }
        public List<results>? results { get; set; }
    }
    public class Query
    {
        public string[] query = new string[0];
    }
    public class status
    {
        public string code { get; set; }
        public string description { get; set; }
    }

    public class results
    {
         public string province_id { get; set; }
        public string province { get; set; }
    }
    public class NewModel
    {
        public List<Province> province { get; set; }
    }
}
