using BusinessCostPriceAPI.Client.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCostPriceAPI.Client.Service
{
    public partial class APIService
    {
        [Method(Method.Get)]
        [ControllerRoute("Ingredients/GetIngredients")]
        public static async Task<List<IngredientDTO>> GetIngredientsAsync(int page)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(page), page.ToString());

            return await GetReponse<List<IngredientDTO>>(request);
        }
        [Method(Method.Get)]
        [ControllerRoute("Ingredients/GetIngredient")]
        public static async Task<IngredientDTO> GetIngredientAsync(int ingredientId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(ingredientId), ingredientId.ToString());

            return await GetReponse<IngredientDTO>(request);
        }
        [Method(Method.Get)]
        [ControllerRoute("Ingredients/GetIngredientPriceDetails")]
        public static async Task<List<IngredientPriceInfoDTO>> GetIngredientPriceDetailsAsync(int ingredientId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(ingredientId), ingredientId.ToString());

            return await GetReponse<List<IngredientPriceInfoDTO>>(request);
        }
        [Method(Method.Get)]
        [ControllerRoute("Ingredients/GetIngredientStockDetails")]
        public static async Task<List<IngredientStockInfoDTO>> GetIngredientStockDetails(int ingredientId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(ingredientId), ingredientId.ToString());

            return await GetReponse<List<IngredientStockInfoDTO>>(request);
        }


        [Method(Method.Post)]
        [ControllerRoute("Ingredients/AddIngredient")]
        public static async Task<IngredientDTO> AddIngredientAsync(IngredientDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetReponse<IngredientDTO>(request);
        }
        [Method(Method.Post)]
        [ControllerRoute("Ingredients/AddIngredientPrice")]
        public static async Task<IngredientPriceInfoDTO> AddIngredientPriceAsync(IngredientPriceInfoDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetReponse<IngredientPriceInfoDTO>(request);
        }
        [Method(Method.Post)]
        [ControllerRoute("Ingredients/AddIngredientStock")]
        public static async Task<IngredientStockInfoDTO> AddIngredientStockAsync(IngredientStockInfoDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetReponse<IngredientStockInfoDTO>(request);
        }


        [Method(Method.Put)]
        [ControllerRoute("Ingredients/UpdateIngredient")]
        public static async Task<IngredientDTO> UpdateIngredientAsync(IngredientDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetReponse<IngredientDTO>(request);
        }
        [Method(Method.Delete)]
        [ControllerRoute("Ingredients/RemoveIngredient")]
        public static async Task RemoveIngredientAsync(int ingredientId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(ingredientId), ingredientId.ToString());

            await GetReponse(request);
        }
    }
}
