namespace DeliverouxDev.Pages.Commands.Extensions;

using Applications.UseCase.Commands;
using ViewModel;

public static class StatisticsExtensions {
    public static StatisticsViewModel ToViewModel(this OutputGetStatsCommandsUseCase output) {
        return new StatisticsViewModel {
            AcceptedByRestaurateur = output.AcceptedByRestaurateur,
            InDelivery = output.InDelivery,
            Finished = output.Finished
        };
    }
}
