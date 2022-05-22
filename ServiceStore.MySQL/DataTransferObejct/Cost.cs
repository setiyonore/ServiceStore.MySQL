namespace ServiceStore.MySQL.DataTransferObejct;

public class Cost
{
    public rajaOngkirCost? rajaongkir { get; set; }
}

public class rajaOngkirCost
{
    public queryCost? query { get; set; }
    public statusCost? status { get; set; }
    public origin_details? origin_details { get; set; }
    public destination_details? destination_details { get; set; }
    public List<resultCost>? results { get; set; }
}

public class queryCost
{
    public string origin { get; set; }
    public string destination { get; set; }
    public int weight { get; set; }
    public string courier { get; set; }
}

public class statusCost
{
    public int code { get; set; }
    public string description { get; set; }
    
}

public class origin_details
{
    public string city_id { get; set; }
    public string province_id { get; set; }
    public string province { get; set; }
    public string type { get; set; }
    public string city_name { get; set; }
    public string postal_code { get; set; }
}

public class destination_details
{
    public string city_id { get; set; }
    public string province_id { get; set; }
    public string province { get; set; }
    public string type { get; set; }
    public string city_name { get; set; }
    public string postal_code { get; set; }
}

public class resultCost
{
    public string code { get; set; }
    public string name { get; set; }
    public List<resultCostDescription>? costs { get; set; }

}

public class resultCostDescription
{
    public string service { get; set; } 
    public string description { get; set; }
    public List<resultCostValue> cost { get; set; }
    //public resultCost cost { set; get; }

}

public class resultCostValue
{
    public int value { get; set; }
    public string etd { get; set; }
    public string note { get; set; }
}