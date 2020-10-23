using AKSoftware.WebApi.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlannerApp.Shared.Services
{
    public abstract class ServicesBase
    {
        protected readonly string _baseURL;

        protected ServiceClient _client = new ServiceClient();
        public ServicesBase(string strBaseUrl)
        {
            _baseURL = strBaseUrl;
        }

        public string AccessToken
        {
            get => _client.AccessToken;
            set
            {
                _client.AccessToken = value;
            }
        }
    }
}
