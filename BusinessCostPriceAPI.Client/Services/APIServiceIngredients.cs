using BusinessCostPriceAPI.Client.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCostPriceAPI.Client.Services
{
    public partial class APIService
    {
        [Method(Method.Get)]
        [ControllerRoute("Ingredients/GetIngredients")]
        public async Task<List<IngredientDTO>> GetIngredientsAsync(int page)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(page), page.ToString());

            return await GetResponse<List<IngredientDTO>>(request);
        }
        [Method(Method.Get)]
        [ControllerRoute("Ingredients/GetIngredient")]
        public async Task<IngredientDTO> GetIngredientAsync(int ingredientId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(ingredientId), ingredientId.ToString());

            return await GetResponse<IngredientDTO>(request);
        }
        [Method(Method.Get)]
        [ControllerRoute("Ingredients/GetIngredientPriceInfos")]
        public async Task<List<IngredientPriceInfoDTO>> GetIngredientPriceInfosAsync(int ingredientId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(ingredientId), ingredientId.ToString());

            return await GetResponse<List<IngredientPriceInfoDTO>>(request);
        }
        [Method(Method.Get)]
        [ControllerRoute("Ingredients/GetIngredientPriceInfosBy")]
        public async Task<List<IngredientPriceInfoDTO>> GetIngredientPriceInfosByAsync(int ingredientId, Period period, int limit)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(ingredientId), ingredientId.ToString());
            request.AddParameter(nameof(period), period.ToString());
            request.AddParameter(nameof(limit), limit.ToString());

            return await GetResponse<List<IngredientPriceInfoDTO>>(request);
        }
        [Method(Method.Get)]
        [ControllerRoute("Ingredients/GetIngredientStockInfos")]
        public async Task<List<IngredientStockInfoDTO>> GetIngredientStockInfosAsync(int ingredientId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(ingredientId), ingredientId.ToString());

            return await GetResponse<List<IngredientStockInfoDTO>>(request);
        }
        [Method(Method.Get)]
        [ControllerRoute("Ingredients/GetIngredientStockInfosBy")]
        public async Task<List<IngredientStockInfoDTO>> GetIngredientStockInfosByAsync(int ingredientId, Period period, int limit)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(ingredientId), ingredientId.ToString());
            request.AddParameter(nameof(period), period.ToString());
            request.AddParameter(nameof(limit), limit.ToString());

            return await GetResponse<List<IngredientStockInfoDTO>>(request);
        }


        [Method(Method.Post)]
        [ControllerRoute("Ingredients/AddIngredient")]
        public async Task<IngredientDTO> AddIngredientAsync(IngredientDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetResponse<IngredientDTO>(request);
        }
        [Method(Method.Post)]
        [ControllerRoute("Ingredients/AddIngredientPrice")]
        public async Task<IngredientPriceInfoDTO> AddIngredientPriceAsync(IngredientPriceInfoDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetResponse<IngredientPriceInfoDTO>(request);
        }
        [Method(Method.Post)]
        [ControllerRoute("Ingredients/AddIngredientStock")]
        public async Task<IngredientStockInfoDTO> AddIngredientStockAsync(IngredientStockInfoDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetResponse<IngredientStockInfoDTO>(request);
        }


        [Method(Method.Put)]
        [ControllerRoute("Ingredients/UpdateIngredient")]
        public async Task<IngredientDTO> UpdateIngredientAsync(IngredientDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetResponse<IngredientDTO>(request);
        }
        [Method(Method.Delete)]
        [ControllerRoute("Ingredients/RemoveIngredient")]
        public async Task RemoveIngredientAsync(int ingredientId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(ingredientId), ingredientId.ToString());

            await GetResponse(request);
        }
    }
}
