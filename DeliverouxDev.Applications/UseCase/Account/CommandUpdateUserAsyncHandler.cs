namespace DeliverouxDev.Applications.UseCase.Account;

using Domains.Account;
using Interfaces;
using MediatR;

public record InputCommandUpdateUserAsyncHandler(User user, string token) : IRequest<bool>;
public class CommandUpdateUserAsyncHandler : IRequestHandler<InputCommandUpdateUserAsyncHandler, bool> {
    
    private readonly IAccountRepository _accountRepository;
    
    public CommandUpdateUserAsyncHandler(IAccountRepository accountRepository) {
        _accountRepository = accountRepository;
    }
    
    public async Task<bool> Handle(InputCommandUpdateUserAsyncHandler request, CancellationToken cancellationToken)
        => await _accountRepository.UpdateUserAsync(request.user, request.token);
}
