namespace DeliverouxDev.Domains.Command;

using System.Runtime.InteropServices.JavaScript;

public class Command {
    public string customerId { get; set; }
    public string restorantId { get; set; }
    public JSType.Date date { get; set; }
    public int price { get; set; }
    public string adress { get; set; }
    public string city { get; set; }
    public string codePostal { get; set; }
    public bool isPaid { get; set; }
    public bool isAcceptedByRestaurateur { get; set; }
    public bool isInDelivery { get; set; }
    public bool isFinished { get; set; }
}
