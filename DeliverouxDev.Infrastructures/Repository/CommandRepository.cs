namespace DeliverouxDev.Infrastructures.Repository;

using Applications.Interfaces;
using Domains.Command;
using System.Net.Http.Headers;
using System.Text.Json;

public class CommandRepository : ICommandRepository {
    private readonly string _baseUrl = "http://localhost:8080/commands";
    public CommandRepository() {
        
    }
    
    public async Task<List<Command>> GetAllCommandAsync(string token) {
        var url = _baseUrl + "/all/commands";
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await httpClient.GetAsync(url);
        
        if (response.IsSuccessStatusCode) {
            var responseContent = await response.Content.ReadAsStringAsync();
            var commands = JsonSerializer.Deserialize<List<Command>>(responseContent);
            
            return commands;
        }

        return new();
    }
}
