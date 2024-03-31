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
        [ControllerRoute("Recipes/GetRecipes")]
        public async Task<List<RecipeDTO>> GetRecipesAsync(int page)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(page), page.ToString());

            return await GetReponse<List<RecipeDTO>>(request);
        }
        [Method(Method.Get)]
        [ControllerRoute("Recipes/GetRecipe")]
        public async Task<RecipeDTO> GetRecipeAsync(int recipeId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(recipeId), recipeId.ToString());

            return await GetReponse<RecipeDTO>(request);
        }
        [Method(Method.Get)]
        [ControllerRoute("Recipes/GetRecipeIngredients")]
        public async Task<List<RecipeIngredientDTO>> GetRecipeIngredientsAsync(int recipeId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(recipeId), recipeId.ToString());

            return await GetReponse< List<RecipeIngredientDTO>>(request);
        }
        [Method(Method.Get)]
        [ControllerRoute("Recipes/GetRecipeFromSubRecipe")]
        public async Task<List<RecipeDTO>> GetRecipeFromSubRecipeAsync(int recipeId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(recipeId), recipeId.ToString());

            return await GetReponse<List<RecipeDTO>>(request);
        }


        [Method(Method.Post)]
        [ControllerRoute("Recipes/AddRecipe")]
        public async Task<RecipeDTO> AddRecipeAsync(RecipeDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetReponse<RecipeDTO>(request);
        }
        [Method(Method.Post)]
        [ControllerRoute("Recipes/AddRecipeIngredient")]
        public async Task<RecipeIngredientDTO> AddRecipeIngredientAsync(RecipeIngredientDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body.ToSend());

            return await GetReponse<RecipeIngredientDTO>(request);
        }

        [Method(Method.Put)]
        [ControllerRoute("Recipes/UpdateRecipe")]
        public async Task<RecipeDTO> UpdateRecipeAsync(RecipeDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetReponse<RecipeDTO>(request);
        }
        [Method(Method.Put)]
        [ControllerRoute("Recipes/UpdateRecipeIngredient")]
        public async Task<RecipeIngredientDTO> UpdateRecipeIngredientAsync(RecipeIngredientDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body.ToSend());

            return await GetReponse<RecipeIngredientDTO>(request);
        }


        [Method(Method.Delete)]
        [ControllerRoute("Recipes/RemoveRecipe")]
        public async Task RemoveRecipeAsync(int recipeId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(recipeId), recipeId.ToString());

            await GetReponse(request);
        }
        [Method(Method.Delete)]
        [ControllerRoute("Recipes/RemoveRecipeIngredient")]
        public async Task RemoveRecipeIngredientAsync(int recipeIngredientId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(recipeIngredientId), recipeIngredientId.ToString());

            await GetReponse(request);
        }
    }
}
