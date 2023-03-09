namespace DeliverouxDev.Pages.Account.ViewModel; 

public class UserViewModel {
    public string id { get; set; }
    public string mail { get; set; }
    public string password { get; set; }
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string phone { get; set; }
    public string addressId { get; set; }
    public bool isdisabled { get; set; }
    public int roleId { get; set; }
    
    public UserViewModel Copy() => new UserViewModel {
        id = this.id,
        mail = this.mail,
        password = this.password,
        firstname = this.firstname,
        lastname = this.lastname,
        phone = this.phone,
        addressId = this.addressId,
        isdisabled = this.isdisabled,
        roleId = this.roleId
    };
}
