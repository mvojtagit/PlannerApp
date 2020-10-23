using AKSoftware.WebApi.Client;
using PlannerAppClient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApp.Shared.Services
{
    public class ToDoItemsService : ServicesBase
    {

        public ToDoItemsService(string strBaseUrl) : base(strBaseUrl) { }

        /// <summary>
        /// Add new ToDoItem
        /// </summary>
        /// <param name="model">Object to be added</param>
        /// <returns></returns>
        public async Task<ToDoItemSingleResponse> CreateItemAsync(ToDoItemRequest model)
        {
            string strBaseUrl = $"{base._baseURL}/api/todoitems";
            var response = await base._client.PostProtectedAsync<ToDoItemSingleResponse>(strBaseUrl, model);

            return response.Result;
        }

        /// <summary>
        /// Update ToDoItem
        /// </summary>
        /// <param name="model">Object to be updated</param>
        /// <returns></returns>
        public async Task<ToDoItemSingleResponse> EditItemAsync(ToDoItemRequest model)
        {
            string strBaseUrl = $"{base._baseURL}/api/todoitems";
            var response = await base._client.PutProtectedAsync<ToDoItemSingleResponse>(strBaseUrl, model);

            return response.Result;
        }

        /// <summary>
        /// Change ToDoItem status
        /// </summary>
        /// <param name="strId">Item ID</param>
        /// <returns></returns>
        public async Task<ToDoItemSingleResponse> ChangeItemAsync(string strId)
        {
            string strBaseUrl = $"{base._baseURL}/api/todoitems/{strId}";
            var response = await base._client.PutProtectedAsync<ToDoItemSingleResponse>(strBaseUrl, null);

            return response.Result;
        }

        /// <summary>
        /// Change ToDoItem status
        /// </summary>
        /// <param name="strId">Item ID</param>
        /// <returns></returns>
        public async Task<ToDoItemSingleResponse> DeleteItemByIdAsync(string strId)
        {
            string strBaseUrl = $"{base._baseURL}/api/todoitems/{strId}";
            var response = await base._client.DeleteProtectedAsync<ToDoItemSingleResponse>(strBaseUrl);

            return response.Result;
        }
    }


}
