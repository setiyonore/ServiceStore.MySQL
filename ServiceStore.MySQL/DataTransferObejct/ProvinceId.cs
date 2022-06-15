namespace ServiceStore.MySQL.DataTransferObejct;

public class ProvinceId
{
    public RajaOngkir? RajaOngkir { get; set; }
}

public class RajaOngkir
{
    public query? Query { get; set; }
    public status? Status { get; set; }
    public results? Results { get; set; }
}

public class query
{
    public int Id { get; set; }
}

