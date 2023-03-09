namespace DeliverouxDev.Pages.Account;

using Applications.UseCase.Account;
using Extensions;
using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using ViewModel;

public partial class Account : ComponentBase {
    [Inject] IMediator _mediator { get; set; } = null!;

    private string search = "";

    private MudTable<UserViewModel>? table;
    
    private List<UserViewModel> users = new List<UserViewModel>();
    
    private UserViewModel? currentSelectModel = null!;
    private UserViewModel? previousSelectModel = null!;
    
    protected override async Task OnInitializedAsync()
    {
        await RefreshUsers();
    }
    
    private async Task RefreshUsers() {
        var token = await SecureStorage.GetAsync("accounttoken");
        var usersDomain = await _mediator.Send(new InputQueryGetAllUserHandler(token));
        users = usersDomain.ToViewModel();
    }

    private async Task DeleteUser(object selectElement) {
        await Task.Delay(10);

        if (currentSelectModel != null)
            await RemoveUser(currentSelectModel);
        
        await RefreshUsers();
        
        StateHasChanged();
    }

    private async Task RemoveUser(UserViewModel user) {
        await _mediator.Send(new InputCommandDeleteUserAsyncHandler(currentSelectModel.id, await SecureStorage.GetAsync("accounttoken")));
    }

    private async Task SaveUser() {
        await Task.Delay(10);

        if (currentSelectModel != null){
            var user = currentSelectModel.ToDomain();
            await _mediator.Send(new InputCommandUpdateUserAsyncHandler(user, await SecureStorage.GetAsync("accounttoken")));
            this.currentSelectModel = null;
        }
    }

    private void ItemHasBeenChanged(object selectElement) {
        if (selectElement is not UserViewModel currentSelectElement) return;
        this.currentSelectModel = currentSelectElement.Copy();
    }
    
    private void ItemPreviewChanged(object selectElement)
    {
        if (selectElement is not UserViewModel currentSelectElement) return;
        previousSelectModel = currentSelectElement.Copy();
    }
}
