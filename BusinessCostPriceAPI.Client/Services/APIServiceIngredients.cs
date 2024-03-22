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

            return await GetReponse<List<IngredientDTO>>(request);
        }
        [Method(Method.Get)]
        [ControllerRoute("Ingredients/GetIngredient")]
        public async Task<IngredientDTO> GetIngredientAsync(int ingredientId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(ingredientId), ingredientId.ToString());

            return await GetReponse<IngredientDTO>(request);
        }
        [Method(Method.Get)]
        [ControllerRoute("Ingredients/GetIngredientPriceDetails")]
        public async Task<List<IngredientPriceInfoDTO>> GetIngredientPriceDetailsAsync(int ingredientId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(ingredientId), ingredientId.ToString());

            return await GetReponse<List<IngredientPriceInfoDTO>>(request);
        }
        [Method(Method.Get)]
        [ControllerRoute("Ingredients/GetIngredientStockDetails")]
        public async Task<List<IngredientStockInfoDTO>> GetIngredientStockDetails(int ingredientId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(ingredientId), ingredientId.ToString());

            return await GetReponse<List<IngredientStockInfoDTO>>(request);
        }


        [Method(Method.Post)]
        [ControllerRoute("Ingredients/AddIngredient")]
        public async Task<IngredientDTO> AddIngredientAsync(IngredientDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetReponse<IngredientDTO>(request);
        }
        [Method(Method.Post)]
        [ControllerRoute("Ingredients/AddIngredientPrice")]
        public async Task<IngredientPriceInfoDTO> AddIngredientPriceAsync(IngredientPriceInfoDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetReponse<IngredientPriceInfoDTO>(request);
        }
        [Method(Method.Post)]
        [ControllerRoute("Ingredients/AddIngredientStock")]
        public async Task<IngredientStockInfoDTO> AddIngredientStockAsync(IngredientStockInfoDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetReponse<IngredientStockInfoDTO>(request);
        }


        [Method(Method.Put)]
        [ControllerRoute("Ingredients/UpdateIngredient")]
        public async Task<IngredientDTO> UpdateIngredientAsync(IngredientDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetReponse<IngredientDTO>(request);
        }
        [Method(Method.Delete)]
        [ControllerRoute("Ingredients/RemoveIngredient")]
        public async Task RemoveIngredientAsync(int ingredientId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(ingredientId), ingredientId.ToString());

            await GetReponse(request);
        }
    }
}
