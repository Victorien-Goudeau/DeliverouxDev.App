namespace DeliverouxDev.Applications.Interfaces;

using Domains.Account;

public interface IAccountRepository {
    Task<bool> DeleteUserAsync(string userId, string token);
    Task<List<User>> GetAllUserAsync(string token);
    Task<bool> UpdateUserAsync(User user, string token);
}
