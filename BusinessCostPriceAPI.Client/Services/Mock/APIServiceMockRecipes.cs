using BusinessCostPriceAPI.Client.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCostPriceAPI.Client.Services.Mock
{
    public partial class APIServiceMock
    {
        public Task<List<RecipeDTO>> GetRecipesAsync(int page)
        {
            var recipes = Recipes;
            foreach (var item in recipes)
            {
                SetRecipePrices(item);
            }
            return Task.FromResult(Recipes);
        }
        public Task<RecipeDTO> GetRecipeAsync(int recipeId)
        {
            var recipe = Recipes.FirstOrDefault(r => r.Id == recipeId);
            SetRecipePrices(recipe);
            return Task.FromResult(recipe);
        }
        private void SetRecipePrices(RecipeDTO recipe)
        {
            double charges = recipe.Charges > 0 ? (1 + recipe.Charges / 100) : 1;
            recipe.UnitPrice = GetRecipeIngredientsAsync(recipe.Id).Result.Sum(i => i.Price);
            recipe.RecipePriceNoFee = recipe.UnitPrice * recipe.RecipeQuantity;
            recipe.RecipePrice = recipe.RecipePriceNoFee * charges;
        }
        public Task<List<RecipeIngredientDTO>> GetRecipeIngredientsAsync(int recipeId)
        {
            var recipesIng = RecipeIngredients.Where(r => r.RecipeId == recipeId).ToList();
            foreach (var item in recipesIng)
            {
                item.IIngredient = item.IngredientId != null ? GetIngredientAsync(item.IngredientId ?? 0).Result : GetRecipeAsync(item.IngredientRecipeId ?? 0).Result;
                item.Price = item.IIngredient.UnitPrice * item.Quantity;
            }
            return Task.FromResult(recipesIng);
        }
        public Task<List<RecipeDTO>> GetRecipeFromSubRecipeAsync(int recipeId)
        {
            var tmp = new List<RecipeDTO>();
            return Task.FromResult(Recipes.Where(r => RecipeIsInSubRecipe(recipeId, r.Id)).ToList());
        }
        private bool RecipeIsInSubRecipe(int recipeSearchedId, int recipeId)
        {
            if (recipeSearchedId == recipeId)
            {
                return true;
            }
            foreach (var recipeIng in RecipeIngredients.Where(r => r.IngredientRecipeId == recipeId))
            {
                if (recipeIng.IngredientRecipeId > 0 && RecipeIsInSubRecipe(recipeId, recipeIng.IngredientRecipeId ?? 0))
                {
                    return true;
                }
            }
            return false;
        }

        public Task<RecipeDTO> AddRecipeAsync(RecipeDTO body)
        {
            body.Id = Recipes.LastOrDefault()?.Id + 1 ?? 1;
            Recipes.Add(body);
            return Task.FromResult(body);
        }
        public Task<RecipeIngredientDTO> AddRecipeIngredientAsync(RecipeIngredientDTO body)
        {
            RecipeIngredients.Add(body);
            return Task.FromResult(body);
        }

        public Task<RecipeDTO> UpdateRecipeAsync(RecipeDTO body)
        {
            Recipes.Remove(Recipes.FirstOrDefault(f => f.Id == body.Id));
            Recipes.Add(body);
            return Task.FromResult(body);
        }
        public Task<RecipeIngredientDTO> UpdateRecipeIngredientAsync(RecipeIngredientDTO body)
        {
            RecipeIngredients.Remove(RecipeIngredients.FirstOrDefault(f => f.Id == body.Id));
            RecipeIngredients.Add(body);
            return Task.FromResult(body);
        }

        public Task RemoveRecipeAsync(int recipeId)
        {
            var tmp = Recipes.FirstOrDefault(f => f.Id == recipeId);
            Recipes.Remove(tmp);
            return Task.CompletedTask;
        }
        public Task RemoveRecipeIngredientAsync(int recipeIngredientId)
        {
            var tmp = RecipeIngredients.FirstOrDefault(f => f.Id == recipeIngredientId);
            RecipeIngredients.Remove(tmp);
            return Task.CompletedTask;
        }
    }
}
