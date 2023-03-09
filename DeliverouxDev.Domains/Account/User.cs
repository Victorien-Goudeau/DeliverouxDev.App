namespace DeliverouxDev.Domains.Account; 

public class User {
    public string id { get; set; }
    public string mail { get; set; }
    public string password { get; set; }
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string phone { get; set; }
    public string addressId { get; set; }
    public bool isdisabled { get; set; }
    public int roleId { get; set; }
}
