namespace DeliverouxDev.Applications.Interfaces;

using Domains.Command;

public interface ICommandRepository {
    Task<List<Command>> GetAllCommandAsync(string token);
}
