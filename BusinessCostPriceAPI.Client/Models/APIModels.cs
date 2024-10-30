using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCostPriceAPI.Client.Models
{
    public partial class AuthenticateDTO
    {
        [JsonProperty("email", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty("password", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; }

        [JsonProperty("token", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Token { get; set; }

    }

    public partial class AuthenticateUpdateDTO
    {
        [JsonProperty("password", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; }

        [JsonProperty("newPassword", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string NewPassword { get; set; }

        [JsonProperty("token", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Token { get; set; }

    }

    public partial class FurnitureDTO
    {
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("unit", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Unit Unit { get; set; }

        [JsonProperty("unitPrice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double UnitPrice { get; set; }

        [JsonProperty("stockQuantity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double StockQuantity { get; set; }

    }

    public partial class FurniturePriceInfoDTO
    {
        [JsonProperty("furnitureId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int FurnitureId { get; set; }

        [JsonProperty("date", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public System.DateTimeOffset Date { get; set; }

        [JsonProperty("unitPrice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double UnitPrice { get; set; }
    }

    public partial class FurnitureStockInfoDTO
    {
        [JsonProperty("furnitureId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int FurnitureId { get; set; }

        [JsonProperty("date", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public System.DateTimeOffset Date { get; set; }

        [JsonProperty("stockQuantity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double StockQuantity { get; set; }
    }

    public partial class IIngredientDTO
    {
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public virtual int Id { get; set; }

        [JsonProperty("name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Name { get; set; }

        [JsonProperty("unit", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public virtual Unit Unit { get; set; }

        [JsonProperty("unitPrice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public virtual double UnitPrice { get; set; }
    }

    public partial class IngredientDTO : IIngredientDTO
    {
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public override int Id { get; set; }

        [JsonProperty("name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public override string Name { get; set; }

        [JsonProperty("unit", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public override Unit Unit { get; set; }

        [JsonProperty("unitPrice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public override double UnitPrice { get; set; }

        [JsonProperty("stockQuantity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double StockQuantity { get; set; }

    }

    public partial class IngredientPriceInfoDTO
    {
        [JsonProperty("ingredientId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int IngredientId { get; set; }

        [JsonProperty("date", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public System.DateTimeOffset Date { get; set; }

        [JsonProperty("unitPrice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double UnitPrice { get; set; }

    }

    public partial class IngredientStockInfoDTO
    {
        [JsonProperty("ingredientId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int IngredientId { get; set; }

        [JsonProperty("date", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public System.DateTimeOffset Date { get; set; }

        [JsonProperty("stockQuantity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double StockQuantity { get; set; }

    }

    public partial class RecipeDTO : IIngredientDTO
    {
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public override int Id { get; set; }

        [JsonProperty("name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public override string Name { get; set; }

        [JsonProperty("unit", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public override Unit Unit { get; set; }

        [JsonProperty("recipeQuantity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double RecipeQuantity { get; set; }

        [JsonProperty("charges", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double Charges { get; set; }

        [JsonProperty("unitPrice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public override double UnitPrice { get; set; }

        [JsonProperty("recipePriceNoFee", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double RecipePriceNoFee { get; set; }

        [JsonProperty("recipePrice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double RecipePrice { get; set; }

    }

    public partial class RecipeIngredientDTO
    {
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("quantity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double Quantity { get; set; }

        [JsonProperty("recipeId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int RecipeId { get; set; }

        [JsonProperty("ingredientRecipeId", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int? IngredientRecipeId { get; set; }

        [JsonProperty("ingredientId", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int? IngredientId { get; set; }

        [JsonProperty("iIngredient", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public IIngredientDTO IIngredient { get; set; }

        [JsonProperty("price", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double Price { get; set; }

        public RecipeIngredientDTO ToSend()
        {
            return new RecipeIngredientDTO()
            {
                Id = Id,
                RecipeId = RecipeId,
                IngredientId = IngredientId,
                IngredientRecipeId = IngredientRecipeId,
                Price = Price,
                Quantity = Quantity,
            };
        }
    }

    public enum Unit
    {

        [System.Runtime.Serialization.EnumMember(Value = @"kilogram")]
        Kilogram = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"liter")]
        Liter = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"piece")]
        Piece = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"dozen")]
        Dozen = 3,
    }

    public enum Period
    {

        [System.Runtime.Serialization.EnumMember(Value = @"day")]
        Day = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"month")]
        Month = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"year")]
        Year = 2
    }
}
