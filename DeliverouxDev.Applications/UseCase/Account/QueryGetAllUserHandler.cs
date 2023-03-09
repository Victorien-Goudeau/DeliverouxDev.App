namespace DeliverouxDev.Applications.UseCase.Account;

using Domains.Account;
using Interfaces;
using MediatR;

public record InputQueryGetAllUserHandler(string token) : IRequest<List<User>>;
public class QueryGetAllUserHandler : IRequestHandler<InputQueryGetAllUserHandler, List<User>> {
    
    private readonly IAccountRepository _accountRepository;
    
    public QueryGetAllUserHandler(IAccountRepository accountRepository) {
        _accountRepository = accountRepository;
    }
    
    public async Task<List<User>> Handle(InputQueryGetAllUserHandler request, CancellationToken cancellationToken)
        => await _accountRepository.GetAllUserAsync(request.token);
}
