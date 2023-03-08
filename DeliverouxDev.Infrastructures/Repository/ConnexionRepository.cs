using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DeliverouxDev.Applications.Interfaces;
using DeliverouxDev.Domains.Connexion;

namespace DeliverouxDev.Infrastructures.Repository;

public class ConnexionRepository : IConnexionRepository
{
    private readonly string _baseUrl = "http://localhost:8080/";
    public ConnexionRepository()
    {
    }

    public async Task<LoginModel?> Login(string email, string passwordUser)
    {
        var loginModel = new LoginModel();
        var url = _baseUrl + "auth/login";
        var httpClient = new HttpClient();
        var requestBody = new
        {
            mail = email,
            password = passwordUser
        };
        
        var json = JsonSerializer.Serialize(requestBody);
        
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        var response = await httpClient.PostAsync(url, content);
        
        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            loginModel  = JsonSerializer.Deserialize<LoginModel>(responseContent);
            
            return loginModel;
        }

        return null;
    }
}