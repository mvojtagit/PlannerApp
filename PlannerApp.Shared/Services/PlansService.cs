using AKSoftware.WebApi.Client;
using PlannerApp.Shared.Models;
using PlannerAppClient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApp.Shared.Services
{
    public class PlansService
    {
        private readonly string _baseURL;

        private ServiceClient _client = new ServiceClient();
        public PlansService(string strBaseUrl)
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
        /// <summary>
        /// Svi planovi byPage
        /// </summary>
        /// <param name="iPage">broj stranice</param>
        /// <returns></returns>
        public async Task<PlanCollectionPagingResponse> GetAllPlansByPageAsync(int? iPage = 1)
        {

            string strBaseUrl = $"{_baseURL}/api/plans?page={iPage}";


            var response = await _client.GetProtectedAsync<PlanCollectionPagingResponse>(strBaseUrl);

            return response.Result;
        }

        /// <summary>
        /// Search plans
        /// </summary>
        /// <param name="idPage"></param>
        /// <param name="strQuery"></param>
        /// <returns></returns>
        public async Task<PlanCollectionPagingResponse> SearchPlansByPageAsync(string strQuery, int? idPage = 1)
        {
            var response = await _client.GetProtectedAsync<PlanCollectionPagingResponse>($"{_baseURL}/api/plans/search?query={strQuery}&page={idPage}");

            return response.Result;
        }
        /// <summary>
        /// Post plan to DB
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PlanSingleResponse> PostPlanAsync(PlanRequest model)
        {
            var formKeyValuesList = new List<FormKeyValue>()
            {
                
                new StringFormKeyValue("Title", model.Title),
                new StringFormKeyValue("Description", model.Description),
            };

            if (model.CoverFile != null)
            {
                formKeyValuesList.Add(new FileFormKeyValue("CoverFile", model.CoverFile, model.FileName));
            }

            var response = await _client.SendFormProtectedAsync<PlanSingleResponse>($"{_baseURL}/api/plans", ActionType.POST, formKeyValuesList.ToArray());

            return response.Result;
        }

        /// <summary>
        /// Svi planovi byPage
        /// </summary>
        /// <param name="iPage">broj stranice</param>
        /// <returns></returns>
        public async Task<PlanSingleResponse> GetPlanByIdAsync(string strId)
        {

            string strBaseUrl = $"{_baseURL}/api/plans/{strId}";


            var response = await _client.GetProtectedAsync<PlanSingleResponse>(strBaseUrl);

            return response.Result;
        }

        /// <summary>
        /// Edit plan to API
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PlanSingleResponse> EditPlanAsync(PlanRequest model)
        {
            var formKeyValuesList = new List<FormKeyValue>()
            {
                new StringFormKeyValue("Id", model.Id),
                new StringFormKeyValue("Title", model.Title),
                new StringFormKeyValue("Description", model.Description),
            };

            if(model.CoverFile != null)
            {
                formKeyValuesList.Add(new FileFormKeyValue("CoverFile", model.CoverFile, model.FileName));
            }

            var response = await _client.SendFormProtectedAsync<PlanSingleResponse>($"{_baseURL}/api/plans", ActionType.PUT, formKeyValuesList.ToArray());

            return response.Result;
        }
    }
}
