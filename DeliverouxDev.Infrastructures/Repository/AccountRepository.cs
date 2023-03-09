using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverouxDev.Infrastructures.Repository;

using Applications.Interfaces;
using Domains.Account;
using System.Net.Http.Headers;
using System.Text.Json;

public class AccountRepository : IAccountRepository {

    private readonly string _baseUrl = "http://localhost:8080";
    public AccountRepository() { 
        
    }

    public async Task<bool> DeleteUserAsync(string userId, string token) {
        var url = _baseUrl + "/user/" + userId;
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await httpClient.DeleteAsync(url);
        
        return response.IsSuccessStatusCode;
    }
    
    public async Task<List<User>> GetAllUserAsync(string token) {
        var url = _baseUrl + "/user/all/users";
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await httpClient.GetAsync(url);
        
        if (response.IsSuccessStatusCode) {
            var responseContent = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<User>>(responseContent);
            
            return users;
        }

        return new();
    }
    
    public async Task<bool> UpdateUserAsync(User user, string token) {
        var url = _baseUrl + "/user/" + user.id;
        var address = await GetUserAddressAsync(user.addressId, token);
        var httpClient = new HttpClient();
        var userToUpdate = new  {
            firstName = user.firstname,
            lastName = user.lastname,
            mail = user.mail,
            password = user.password
        };
        
        var addressToUpdate = new {
            adress = address.adress,
            codePostal = address.codePostal,
            city = address.city,
            country = address.country
        };
        
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var requestBody = new {
            user = userToUpdate,
            address = addressToUpdate
        };
        
        var json = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PatchAsync(url, content);
        
        return response.IsSuccessStatusCode;
    }
    
    public async Task<Adress> GetUserAddressAsync(string adressId, string token) {
        var url = _baseUrl + "/user/address/" + adressId;
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await httpClient.GetAsync(url);
        
        if (response.IsSuccessStatusCode) {
            var responseContent = await response.Content.ReadAsStringAsync();
            var address = JsonSerializer.Deserialize<Adress>(responseContent);
            
            return address;
        }

        return new();
    }
}
