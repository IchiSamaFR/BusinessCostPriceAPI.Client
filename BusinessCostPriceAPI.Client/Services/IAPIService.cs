﻿using BusinessCostPriceAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCostPriceAPI.Client.Services
{
    public interface IAPIService
    {
        string JwtToken { get; set; }
        void SetUrl(string url);
        Task<AuthenticateDTO> RegisterAsync(AuthenticateDTO body);
        Task<AuthenticateDTO> LoginAsync(AuthenticateDTO body);
        Task<AuthenticateDTO> UpdatePasswordAsync(AuthenticateDTO body);

        Task<List<FurnitureDTO>> GetFurnituresAsync(int? page);
        Task<FurnitureDTO> GetFurnitureAsync(int? furnitureId);
        Task<List<FurniturePriceInfoDTO>> GetFurniturePriceInfosAsync(int furnitureId);
        Task<List<FurniturePriceInfoDTO>> GetFurniturePriceInfosByAsync(int furnitureId, Period period, int limit);
        Task<List<FurnitureStockInfoDTO>> GetFurnitureStockInfosAsync(int furnitureId);
        Task<List<FurnitureStockInfoDTO>> GetFurnitureStockInfosByAsync(int furnitureId, Period period, int limit);
        Task<FurnitureDTO> AddFurnitureAsync(FurnitureDTO body);
        Task<FurnitureStockInfoDTO> AddFurnitureStockAsync(FurnitureStockInfoDTO body);
        Task<FurniturePriceInfoDTO> AddFurniturePriceAsync(FurniturePriceInfoDTO body);
        Task<FurnitureDTO> UpdateFurnitureAsync(FurnitureDTO body);
        Task RemoveFurnitureAsync(int? furnitureId);

        Task<List<IngredientDTO>> GetIngredientsAsync(int page);
        Task<IngredientDTO> GetIngredientAsync(int ingredientId);
        Task<List<IngredientPriceInfoDTO>> GetIngredientPriceInfosAsync(int ingredientId);
        Task<List<IngredientPriceInfoDTO>> GetIngredientPriceInfosByAsync(int ingredientId, Period period, int limit);
        Task<List<IngredientStockInfoDTO>> GetIngredientStockInfosAsync(int ingredientId);
        Task<List<IngredientStockInfoDTO>> GetIngredientStockInfosByAsync(int ingredientId, Period period, int limit);
        Task<IngredientDTO> AddIngredientAsync(IngredientDTO body);
        Task<IngredientPriceInfoDTO> AddIngredientPriceAsync(IngredientPriceInfoDTO body);
        Task<IngredientStockInfoDTO> AddIngredientStockAsync(IngredientStockInfoDTO body);
        Task<IngredientDTO> UpdateIngredientAsync(IngredientDTO body);
        Task RemoveIngredientAsync(int ingredientId);

        Task<List<RecipeDTO>> GetRecipesAsync(int page);
        Task<RecipeDTO> GetRecipeAsync(int recipeId);
        Task<List<RecipeDTO>> GetRecipeFromSubRecipeAsync(int recipeId);
        Task<List<RecipeIngredientDTO>> GetRecipeIngredientsAsync(int recipeId);
        Task<RecipeDTO> AddRecipeAsync(RecipeDTO body);
        Task<RecipeIngredientDTO> AddRecipeIngredientAsync(RecipeIngredientDTO body);
        Task<RecipeDTO> UpdateRecipeAsync(RecipeDTO body);
        Task<RecipeIngredientDTO> UpdateRecipeIngredientAsync(RecipeIngredientDTO body);
        Task RemoveRecipeAsync(int recipeId);
        Task RemoveRecipeIngredientAsync(int recipeIngredientId);
    }
}
