using BusinessCostPriceAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCostPriceAPI.Client.Services.Mock
{
    public class APIServiceMock : IAPIService
    {
        public List<IngredientDTO> Ingredients { get; private set; }
        public List<IngredientPriceInfoDTO> IngredientPriceInfos { get; private set; }
        public List<IngredientStockInfoDTO> IngredientStockInfos { get; private set; }
        public List<FurnitureDTO> Furnitures { get; private set; }
        public List<FurniturePriceInfoDTO> FurniturePriceInfos { get; private set; }
        public List<FurnitureStockInfoDTO> FurnitureStockInfos { get; private set; }
        public List<RecipeDTO> Recipes { get; private set; }
        public List<RecipeIngredientDTO> RecipeIngredients { get; private set; }

        public APIServiceMock()
        {
            PopulateFurnitures();
            PopulateFurniturePrices();
            PopulateFurnitureStocks();

            PopulateIngredients();
            PopulateIngredientStocks();
            PopulateIngredientPrices();

            PopulateRecipes();
            PopulateRecipeIngredients();
        }

        public Task<FurnitureDTO> AddFurnitureAsync(FurnitureDTO body)
        {
            body.Id = Furnitures.LastOrDefault()?.Id + 1 ?? 1;
            Furnitures.Add(body);
            return Task.FromResult(body);
        }
        public Task<FurnitureStockInfoDTO> AddFurnitureStockAsync(FurnitureStockInfoDTO body)
        {
            FurnitureStockInfos.Add(body);
            return Task.FromResult(body);
        }
        public Task<IngredientDTO> AddIngredientAsync(IngredientDTO body)
        {
            body.Id = Ingredients.LastOrDefault()?.Id + 1 ?? 1;
            Ingredients.Add(body);
            return Task.FromResult(body);
        }
        public Task<IngredientPriceInfoDTO> AddIngredientPriceAsync(IngredientPriceInfoDTO body)
        {
            IngredientPriceInfos.Add(body);
            return Task.FromResult(body);
        }
        public Task<IngredientStockInfoDTO> AddIngredientStockAsync(IngredientStockInfoDTO body)
        {
            IngredientStockInfos.Add(body);
            return Task.FromResult(body);
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


        public Task<List<FurnitureDTO>> GetFurnituresAsync(int? page)
        {
            return Task.FromResult(Furnitures.Select(i => GetFurnitureAsync(i.Id).Result).ToList());
        }
        public Task<FurnitureDTO> GetFurnitureAsync(int? furnitureId)
        {
            var tmp = Furnitures.FirstOrDefault(i => i.Id == furnitureId);
            tmp.UnitPrice = GetFurniturePriceInfosAsync(furnitureId).Result.LastOrDefault()?.UnitPrice ?? 0;
            tmp.StockQuantity = GetFurnitureStockInfosAsync(furnitureId).Result.LastOrDefault()?.StockQuantity ?? 0;
            return Task.FromResult(tmp);
        }
        public Task<List<FurniturePriceInfoDTO>> GetFurniturePriceInfosAsync(int? furnitureId)
        {
            return Task.FromResult(FurniturePriceInfos.Where(r => r.FurnitureId == furnitureId).ToList());
        }
        public Task<List<FurnitureStockInfoDTO>> GetFurnitureStockInfosAsync(int? furnitureId)
        {
            return Task.FromResult(FurnitureStockInfos.Where(r => r.FurnitureId == furnitureId).ToList());
        }

        public Task<List<IngredientDTO>> GetIngredientsAsync(int page)
        {
            return Task.FromResult(Ingredients.Select(i => GetIngredientAsync(i.Id).Result).ToList());
        }
        public Task<IngredientDTO> GetIngredientAsync(int ingredientId)
        {
            var tmp = Ingredients.FirstOrDefault(i => i.Id == ingredientId);
            tmp.UnitPrice = GetIngredientPriceDetailsAsync(ingredientId).Result.LastOrDefault()?.UnitPrice ?? 0;
            tmp.StockQuantity = GetIngredientStockDetailsAsync(ingredientId).Result.LastOrDefault()?.StockQuantity ?? 0;
            return Task.FromResult(tmp);
        }
        public Task<List<IngredientPriceInfoDTO>> GetIngredientPriceDetailsAsync(int ingredientId)
        {
            return Task.FromResult(IngredientPriceInfos.Where(r => r.IngredientId == ingredientId).ToList());
        }
        public Task<List<IngredientStockInfoDTO>> GetIngredientStockDetailsAsync(int ingredientId)
        {
            return Task.FromResult(IngredientStockInfos.Where(r => r.IngredientId == ingredientId).ToList());
        }

        public Task<RecipeDTO> GetRecipeAsync(int recipeId)
        {
            return Task.FromResult(Recipes.FirstOrDefault(r => r.Id == recipeId));
        }
        public Task<List<RecipeIngredientDTO>> GetRecipeIngredientsAsync(int recipeId)
        {
            return Task.FromResult(RecipeIngredients.Where(r => r.RecipeId == recipeId).ToList());
        }
        public Task<List<RecipeDTO>> GetRecipesAsync(int page)
        {
            return Task.FromResult(Recipes);
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

        public Task<AuthenticateDTO> LoginAsync(AuthenticateDTO body)
        {
            body.Password = string.Empty;
            body.Token = Guid.NewGuid().ToString();
            return Task.FromResult(body);
        }
        public Task<AuthenticateDTO> RegisterAsync(AuthenticateDTO body)
        {
            body.Password = string.Empty;
            body.Token = new Guid().ToString();
            return Task.FromResult(body);
        }

        public Task RemoveFurnitureAsync(int? furnitureId)
        {
            var tmp = Furnitures.FirstOrDefault(f => f.Id == furnitureId);
            Furnitures.Remove(tmp);
            return Task.CompletedTask;
        }

        public Task RemoveIngredientAsync(int ingredientId)
        {
            var tmp = Ingredients.FirstOrDefault(f => f.Id == ingredientId);
            Ingredients.Remove(tmp);
            return Task.CompletedTask;
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

        public Task<FurnitureDTO> UpdateFurnitureAsync(FurnitureDTO body)
        {
            Furnitures.Remove(Furnitures.FirstOrDefault(f => f.Id == body.Id));
            Furnitures.Add(body);
            return Task.FromResult(body);
        }
        public Task<IngredientDTO> UpdateIngredientAsync(IngredientDTO body)
        {
            Ingredients.Remove(Ingredients.FirstOrDefault(f => f.Id == body.Id));
            Ingredients.Add(body);
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

        public Task<AuthenticateDTO> UpdatePasswordAsync(AuthenticateDTO body)
        {
            body.Password = string.Empty;
            return Task.FromResult(body);
        }


        private void PopulateIngredients()
        {
            Ingredients = new List<IngredientDTO>
            {
                new IngredientDTO
                {
                    Id = 5,
                    Name = "Farine",
                    Unit = Unit.Kilogram
                },
                new IngredientDTO
                {
                    Id = 8,
                    Name = "Oeuf",
                    Unit = Unit.Piece
                },
                new IngredientDTO
                {
                    Id = 9,
                    Name = "Pommes",
                    Unit = Unit.Kilogram
                },
                new IngredientDTO
                {
                    Id = 10,
                    Name = "Beurre",
                    Unit = Unit.Kilogram
                },
            };
        }
        private void PopulateIngredientPrices()
        {
            IngredientPriceInfos = new List<IngredientPriceInfoDTO>
            {
                new IngredientPriceInfoDTO()
                {
                    IngredientId = 5,
                    Date = DateTime.Parse("14/01/2024"),
                    UnitPrice = 1.12d
                },
                new IngredientPriceInfoDTO()
                {
                    IngredientId = 8,
                    Date = DateTime.Parse("16/01/2024"),
                    UnitPrice = 1.20d
                }
            };
        }
        private void PopulateIngredientStocks()
        {
            IngredientStockInfos = new List<IngredientStockInfoDTO>
            {
                new IngredientStockInfoDTO()
                {
                    IngredientId = 5,
                    Date = DateTime.Parse("20/01/2024"),
                    StockQuantity = 52d
                }
            };
        }
        private void PopulateFurnitures()
        {
            Furnitures = new List<FurnitureDTO>
            {
                new FurnitureDTO
                {
                    Id = 3,
                    Name = "Emballage",
                    Unit = Unit.Piece
                },
                new FurnitureDTO
                {
                    Id = 4,
                    Name = "Sac papier",
                    Unit = Unit.Piece
                },
                new FurnitureDTO
                {
                    Id = 5,
                    Name = "Cagette en bois",
                    Unit = Unit.Piece
                }
            };
        }
        private void PopulateFurniturePrices()
        {
            FurniturePriceInfos = new List<FurniturePriceInfoDTO>
            {
                new FurniturePriceInfoDTO()
                {
                    FurnitureId = 3,
                    Date = DateTime.Parse("15/01/2024"),
                    UnitPrice = 0.08d
                },
                new FurniturePriceInfoDTO()
                {
                    FurnitureId = 3,
                    Date = DateTime.Parse("15/03/2024"),
                    UnitPrice = 0.11d
                },
                new FurniturePriceInfoDTO()
                {
                    FurnitureId = 4,
                    Date = DateTime.Parse("20/01/2024"),
                    UnitPrice = 0.09d
                },
                new FurniturePriceInfoDTO()
                {
                    FurnitureId = 4,
                    Date = DateTime.Parse("20/02/2024"),
                    UnitPrice = 0.14d
                },
                new FurniturePriceInfoDTO()
                {
                    FurnitureId = 4,
                    Date = DateTime.Parse("20/03/2024"),
                    UnitPrice = 0.13d
                },
                new FurniturePriceInfoDTO()
                {
                    FurnitureId = 5,
                    Date = DateTime.Parse("20/01/2024"),
                    UnitPrice = 2.2d
                },
                new FurniturePriceInfoDTO()
                {
                    FurnitureId = 5,
                    Date = DateTime.Parse("20/03/2024"),
                    UnitPrice = 3.1d
                }
            };
        }
        private void PopulateFurnitureStocks()
        {
            FurnitureStockInfos = new List<FurnitureStockInfoDTO>
            {
                new FurnitureStockInfoDTO()
                {
                    FurnitureId = 3,
                    Date = DateTime.Parse("15/01/2024"),
                    StockQuantity = 12d
                },
                new FurnitureStockInfoDTO()
                {
                    FurnitureId = 4,
                    Date = DateTime.Parse("20/01/2024"),
                    StockQuantity = 52d
                },
                new FurnitureStockInfoDTO()
                {
                    FurnitureId = 5,
                    Date = DateTime.Parse("20/01/2024"),
                    StockQuantity = 12d
                }
            };
        }
        private void PopulateRecipes()
        {
            Recipes = new List<RecipeDTO>
            {
                new RecipeDTO()
                {
                    Id = 2,
                    Name = "Pate feuilleté",
                    Charges = 10,
                    RecipeQuantity = 1,
                    Unit = Unit.Piece
                },
                new RecipeDTO()
                {
                    Id = 3,
                    Name = "Tarte aux pommes",
                    Charges = 10,
                    RecipeQuantity = 1,
                    Unit = Unit.Piece
                },
                new RecipeDTO()
                {
                    Id = 4,
                    Name = "Compote de pommes",
                    Charges = 10,
                    RecipeQuantity = 1,
                    Unit = Unit.Liter
                }
            };

        }
        private void PopulateRecipeIngredients()
        {
            RecipeIngredients = new List<RecipeIngredientDTO>
            {
                new RecipeIngredientDTO()
                {
                    Id = 3,
                    RecipeId = 2,
                    IngredientId = 5,
                    Quantity = 0.35d
                },
                new RecipeIngredientDTO()
                {
                    Id = 4,
                    RecipeId = 2,
                    IngredientId = 10,
                    Quantity = 0.45d
                },
                new RecipeIngredientDTO()
                {
                    Id = 5,
                    RecipeId = 3,
                    IngredientId = 9,
                    Quantity = 0.5d
                },
                new RecipeIngredientDTO()
                {
                    Id = 6,
                    RecipeId = 3,
                    IngredientRecipeId = 2,
                    Quantity = 1
                },
                new RecipeIngredientDTO()
                {
                    Id = 7,
                    RecipeId = 4,
                    IngredientId = 9,
                    Quantity = 1
                },
            };

        }
    }
}
