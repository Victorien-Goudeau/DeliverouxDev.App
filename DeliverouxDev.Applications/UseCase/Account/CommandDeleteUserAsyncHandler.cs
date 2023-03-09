namespace DeliverouxDev.Applications.UseCase.Account;

using Interfaces;
using MediatR;

public record InputCommandDeleteUserAsyncHandler(string UserId, string token) : IRequest<bool>;
public class CommandDeleteUserAsyncHandler : IRequestHandler<InputCommandDeleteUserAsyncHandler, bool> {
    
    private readonly IAccountRepository _accountRepository;
    
    public CommandDeleteUserAsyncHandler(IAccountRepository accountRepository) {
        _accountRepository = accountRepository;
    }

    public async Task<bool> Handle(InputCommandDeleteUserAsyncHandler request, CancellationToken cancellationToken)
        => await _accountRepository.DeleteUserAsync(request.UserId, request.token);
}
