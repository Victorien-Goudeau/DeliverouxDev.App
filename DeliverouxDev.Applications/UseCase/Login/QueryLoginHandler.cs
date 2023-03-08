using DeliverouxDev.Domains.Connexion;
using MediatR;

namespace DeliverouxDev.Applications.UseCase.Login;

using Interfaces;

public record InputLoginUseCase(string email, string passwordUser) : IRequest<LoginModel?>;
public class QueryLoginHandler : IRequestHandler<InputLoginUseCase, LoginModel?>
{
    private readonly IConnexionRepository _connexionRepository;
    
    public QueryLoginHandler(IConnexionRepository connexionRepository)
    {
        _connexionRepository = connexionRepository;
    }
    
    public async Task<LoginModel?> Handle(InputLoginUseCase request, CancellationToken cancellationToken)
        => await _connexionRepository.Login(request.email, request.passwordUser);
}