using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AKSoftware.WebApi.Client;
using PlannerApp.Shared.Models;

namespace PlannerApp.Shared.Services
{

    //ttps://plannerappserver20200228091432.azurewebsites.net/
    public class AuthenticationService
    {

        private readonly string _baseURL;

        private ServiceClient _client = new ServiceClient();
        public AuthenticationService(string strBaseUrl)
        {
            _baseURL = strBaseUrl;
        }

        public async Task<UserManagerResponse> RegisterUserAsync(RegisterRequest request)
        {
            var response = await _client.PostAsync<UserManagerResponse>($"{_baseURL}/api/auth/register", request);

            return response.Result;
        }

        public async Task<UserManagerResponse> LoginUserAsync(LoginRequest request)
        {
            var response = await _client.PostAsync<UserManagerResponse>($"{_baseURL}/api/auth/login", request);

            return response.Result;
        }
    }
}
