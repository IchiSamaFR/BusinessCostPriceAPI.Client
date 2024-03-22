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
        [ControllerRoute("Recipes/GetRecipes")]
        public static async Task<List<RecipeDTO>> GetRecipesAsync(int page)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(page), page.ToString());

            return await GetReponse<List<RecipeDTO>>(request);
        }
        [Method(Method.Get)]
        [ControllerRoute("Recipes/GetRecipe")]
        public static async Task<RecipeDTO> GetRecipeAsync(int recipeId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(recipeId), recipeId.ToString());

            return await GetReponse<RecipeDTO>(request);
        }
        [Method(Method.Get)]
        [ControllerRoute("Recipes/GetRecipeIngredients")]
        public static async Task<List<RecipeIngredientDTO>> GetRecipeIngredientsAsync(int recipeId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(recipeId), recipeId.ToString());

            return await GetReponse< List<RecipeIngredientDTO>>(request);
        }


        [Method(Method.Post)]
        [ControllerRoute("Recipes/AddRecipe")]
        public static async Task<RecipeDTO> AddRecipeAsync(RecipeDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetReponse<RecipeDTO>(request);
        }
        [Method(Method.Post)]
        [ControllerRoute("Recipes/AddRecipeIngredient")]
        public static async Task<RecipeIngredientDTO> AddRecipeIngredientAsync(RecipeIngredientDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body.ToSend());

            return await GetReponse<RecipeIngredientDTO>(request);
        }

        [Method(Method.Put)]
        [ControllerRoute("Recipes/UpdateRecipe")]
        public static async Task<RecipeDTO> UpdateRecipeAsync(RecipeDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetReponse<RecipeDTO>(request);
        }
        [Method(Method.Put)]
        [ControllerRoute("Recipes/UpdateRecipeIngredient")]
        public static async Task<RecipeIngredientDTO> UpdateRecipeIngredientAsync(RecipeIngredientDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body.ToSend());

            return await GetReponse<RecipeIngredientDTO>(request);
        }


        [Method(Method.Delete)]
        [ControllerRoute("Recipes/RemoveRecipe")]
        public static async Task<AuthenticateDTO> RemoveRecipeAsync(int recipeId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(recipeId), recipeId.ToString());

            return await GetReponse<AuthenticateDTO>(request);
        }
        [Method(Method.Delete)]
        [ControllerRoute("Recipes/RemoveRecipeIngredient")]
        public static async Task<AuthenticateDTO> RemoveRecipeIngredientAsync(int recipeIngredientId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(recipeIngredientId), recipeIngredientId.ToString());

            return await GetReponse<AuthenticateDTO>(request);
        }
    }
}
