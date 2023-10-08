using System.Net.Http.Json;
using System.Text.Json;
using Interfaces;
using Microsoft.Extensions.Configuration;
using Serilog;
using Types.Models.User;
using Types.Models.Settings;

namespace Implementation
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger _logger;

        public UserService(
            IConfiguration configuration,
            IHttpClientFactory httpClientFactory,
            ILogger logger)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<User[]> GetUsersAsync()
        {
            //var httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Add("Authorization", "SomeToken");
            //httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");

            using HttpClient client = _httpClientFactory.CreateClient();

            var apiSettings = new ApiSettings();

            //var url = _configuration.GetValue<string>("UsersEndpoint");
            _configuration.GetSection("ApiSettings").Bind(apiSettings);


            try
            {
                _logger.Information("UserService.GetUsersAsync started.");

                User[]? users = await client.GetFromJsonAsync<User[]>(
                    apiSettings.UsersEndpoint, 
                    new JsonSerializerOptions(JsonSerializerDefaults.Web)
                );

                _logger.Information("UserService.GetUsersAsync finished.");
                _logger.Information("---------------------------------");

                return users ?? Array.Empty<User>();
                
            }
            catch (System.Exception)
            {
                
                throw;
            }

        }
        
        public async Task<User> GetUserByIdAsync(int userId)
        {
            using HttpClient client = _httpClientFactory.CreateClient();

            var apiSettings = new ApiSettings();

            //var url = _configuration.GetValue<string>("UsersEndpoint");
            _configuration.GetSection("ApiSettings").Bind(apiSettings);


            try
            {
                _logger.Information("UserService.GetUserByIdAsync started.");

                User? user = await client.GetFromJsonAsync<User>(
                    apiSettings.UsersEndpoint + userId, 
                    new JsonSerializerOptions(JsonSerializerDefaults.Web)
                );

                _logger.Information("UserService.GetUserByIdAsync finished.");
                _logger.Information("---------------------------------");

                return user ?? new User();
                
            }
            catch (System.Exception)
            {
                
                throw;
            }

        }
    }

}
