using BusinessCostPriceAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCostPriceAPI.Client.Services.Mock
{
    public partial class APIServiceMock : IAPIService
    {
        public string JwtToken { get; set; }

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
        public void SetUrl(string url)
        {

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
                },
                new IngredientPriceInfoDTO()
                {
                    IngredientId = 9,
                    Date = DateTime.Parse("16/01/2024"),
                    UnitPrice = 1.04d
                },
                new IngredientPriceInfoDTO()
                {
                    IngredientId = 10,
                    Date = DateTime.Parse("16/01/2024"),
                    UnitPrice = 2.66d
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
