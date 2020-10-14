using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using PlannerAppClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PlannerAppClient
{
    public class LocalAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;

        public LocalAuthenticationStateProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (await _localStorageService.ContainKeyAsync("User"))
            {
                var userInfo = await _localStorageService.GetItemAsync<LocalUserInfo>("User");

                var claims = new[]
                {
                    new Claim("Email",userInfo.Email),
                    new Claim("AccessToken",userInfo.AccessToken),
                    new Claim("FirstName",userInfo.FirstName),
                    new Claim("LastName",userInfo.LastName),
                    new Claim(ClaimTypes.NameIdentifier,userInfo.Id),
                };

                var identity = new ClaimsIdentity(claims,"BearerToken");
                var user = new ClaimsPrincipal(identity);
                var state= new AuthenticationState(user);

                NotifyAuthenticationStateChanged(Task.FromResult(state));

                return state;
            }
            //ako nije onda nista
            return new AuthenticationState(new ClaimsPrincipal());
        }

        public async Task LogoutAsync()
        {
            
            await _localStorageService.RemoveItemAsync("User");


            var state = new AuthenticationState(new ClaimsPrincipal());
            NotifyAuthenticationStateChanged(Task.FromResult(state));
        }
    }
}
