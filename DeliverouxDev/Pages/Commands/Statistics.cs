namespace DeliverouxDev.Pages.Commands;

using Applications.UseCase.Commands;
using Extensions;
using MediatR;
using Microsoft.AspNetCore.Components;
using ViewModel;

public partial class Statistics {
    [Inject] IMediator _mediator { get; set; } = null!;

    public StatisticsViewModel statisticsViewModel { get; set; } = new();

    public int dataSize = 3;

    public int Index = -1;
    public string[] dataLabel = { "Acceptée par le restaurateur", "En livraison", "Terminée" };
    public double[] data = {0,0,0};
    
    protected async override Task OnInitializedAsync() {
        await RefreshStatistics();
    }

    private async Task RefreshStatistics() {
        var token = await SecureStorage.GetAsync("accounttoken");
        var stats = await _mediator.Send(new InputGetStatsCommandsUseCase(token));
        statisticsViewModel = stats.ToViewModel();
        data = new double[] {statisticsViewModel.AcceptedByRestaurateur, statisticsViewModel.InDelivery, statisticsViewModel.Finished};
        
        StateHasChanged();
    }
}
