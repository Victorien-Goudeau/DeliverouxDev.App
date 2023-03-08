using DeliverouxDev.Domains.Connexion;

namespace DeliverouxDev.Applications.Interfaces;

public interface IConnexionRepository
{
    Task<LoginModel?> Login(string email, string passwordUser);
}