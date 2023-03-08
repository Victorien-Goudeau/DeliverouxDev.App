namespace DeliverouxDev.Domains.Connexion;

public class Data
{
    public Guid id { get; set; }
    public int roleId { get; set; }
    public string addressId { get; set; }
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string phone { get; set; }
    public string mail { get; set; }
    public string password { get; set; }
    public bool isdisabled { get; set; }
    public string restaurantId { get; set; }
}