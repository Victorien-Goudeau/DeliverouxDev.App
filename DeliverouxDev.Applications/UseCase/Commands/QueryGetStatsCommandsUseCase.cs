namespace DeliverouxDev.Applications.UseCase.Commands;

using Interfaces;
using MediatR;

public record InputGetStatsCommandsUseCase(string token) : IRequest<OutputGetStatsCommandsUseCase>{}


public class QueryGetStatsCommandsUseCase : IRequestHandler<InputGetStatsCommandsUseCase, OutputGetStatsCommandsUseCase> {
    private readonly ICommandRepository _commandRepository;
    
    public QueryGetStatsCommandsUseCase(ICommandRepository commandRepository) {
        _commandRepository = commandRepository;
    }
    
    public async Task<OutputGetStatsCommandsUseCase> Handle(InputGetStatsCommandsUseCase request, CancellationToken cancellationToken) {
        var commands = await _commandRepository.GetAllCommandAsync(request.token);
        var output = new OutputGetStatsCommandsUseCase();
        
        foreach (var command in commands) {
            if (command.isAcceptedByRestaurateur && !command.isInDelivery &&  !command.isFinished) {
                output.AcceptedByRestaurateur++;
            } else if (command.isAcceptedByRestaurateur && command.isInDelivery &&  !command.isFinished) {
                output.InDelivery++;
            } else if (command.isAcceptedByRestaurateur && command.isInDelivery &&  command.isFinished) {
                output.Finished++;
            }
        }

        return output;
    }
}
