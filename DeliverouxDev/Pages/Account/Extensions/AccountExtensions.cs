namespace DeliverouxDev.Pages.Account.Extensions;

using ViewModel;
using DeliverouxDev.Domains.Account;
public static class AccountExtensions {
    public static List<UserViewModel> ToViewModel(this List<User> users) {
        var userViewModels = new List<UserViewModel>();
        foreach (var user in users) {
            userViewModels.Add(new UserViewModel {
                id = user.id,
                mail = user.mail,
                password = user.password,
                firstname = user.firstname,
                lastname = user.lastname,
                phone = user.phone,
                addressId = user.addressId,
                isdisabled = user.isdisabled,
                roleId = user.roleId
            });
        }

        return userViewModels;
    }
    
    public static User ToDomain(this UserViewModel userViewModel) => new User {
        id = userViewModel.id,
        mail = userViewModel.mail,
        password = userViewModel.password,
        firstname = userViewModel.firstname,
        lastname = userViewModel.lastname,
        phone = userViewModel.phone,
        addressId = userViewModel.addressId,
        isdisabled = userViewModel.isdisabled,
        roleId = userViewModel.roleId
    };
}
