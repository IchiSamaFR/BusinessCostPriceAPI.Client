using BusinessCostPriceAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCostPriceAPI.Client.Services.Mock
{
    public partial class APIServiceMock
    {
        public Task<List<IngredientDTO>> GetIngredientsAsync(int page)
        {
            return Task.FromResult(Ingredients.Select(i => GetIngredientAsync(i.Id).Result).ToList());
        }
        public Task<IngredientDTO> GetIngredientAsync(int ingredientId)
        {
            var tmp = Ingredients.FirstOrDefault(i => i.Id == ingredientId);
            tmp.UnitPrice = GetIngredientPriceInfosAsync(ingredientId).Result.LastOrDefault()?.UnitPrice ?? 0;
            tmp.StockQuantity = GetIngredientStockInfosAsync(ingredientId).Result.LastOrDefault()?.StockQuantity ?? 0;
            return Task.FromResult(tmp);
        }

        public Task<List<IngredientPriceInfoDTO>> GetIngredientPriceInfosAsync(int ingredientId)
        {
            return Task.FromResult(IngredientPriceInfos.Where(r => r.IngredientId == ingredientId).OrderBy(r => r.Date).ToList());
        }
        public Task<List<IngredientStockInfoDTO>> GetIngredientStockInfosAsync(int ingredientId)
        {
            return Task.FromResult(IngredientStockInfos.Where(r => r.IngredientId == ingredientId).OrderBy(r => r.Date).ToList());
        }

        public Task<List<IngredientPriceInfoDTO>> GetIngredientPriceInfosByAsync(int ingredientId, Period period, int limit)
        {
            throw new NotImplementedException();
        }
        public Task<List<IngredientStockInfoDTO>> GetIngredientStockInfosByAsync(int ingredientId, Period period, int limit)
        {
            throw new NotImplementedException();
        }

        public async Task<IngredientDTO> AddIngredientAsync(IngredientDTO body)
        {
            body.Id = Ingredients.LastOrDefault()?.Id + 1 ?? 1;
            Ingredients.Add(body);
            await AddIngredientPriceAsync(new IngredientPriceInfoDTO()
            {
                Date = DateTime.Now.Date,
                UnitPrice = body.UnitPrice,
                IngredientId = body.Id
            });
            await AddIngredientStockAsync(new IngredientStockInfoDTO()
            {
                Date = DateTime.Now.Date,
                StockQuantity = body.StockQuantity,
                IngredientId = body.Id
            });
            return body;
        }
        public Task<IngredientPriceInfoDTO> AddIngredientPriceAsync(IngredientPriceInfoDTO body)
        {
            var sel = IngredientPriceInfos.Find((f) => f.Date.Date == DateTime.Now.Date);

            if (sel == null)
            {
                body.Date = DateTime.Now.Date;
                IngredientPriceInfos.Add(body);
                return Task.FromResult(body);
            }
            sel.UnitPrice = body.UnitPrice;
            return Task.FromResult(sel);
        }
        public Task<IngredientStockInfoDTO> AddIngredientStockAsync(IngredientStockInfoDTO body)
        {
            var sel = IngredientStockInfos.Find((f) => f.IngredientId == body.IngredientId && f.Date.Date == DateTime.Now.Date);

            if (sel == null)
            {
                body.Date = DateTime.Now.Date;
                IngredientStockInfos.Add(body);
                return Task.FromResult(body);
            }
            else
            {
                sel.StockQuantity = body.StockQuantity;
            }
            return Task.FromResult(sel);
        }

        public async Task<IngredientDTO> UpdateIngredientAsync(IngredientDTO body)
        {
            var sel = Ingredients.FirstOrDefault(f => f.Id == body.Id);
            Ingredients.Remove(sel);
            Ingredients.Add(body);

            if (sel.UnitPrice != body.UnitPrice)
            {
                await AddIngredientPriceAsync(new IngredientPriceInfoDTO()
                {
                    Date = DateTime.Now.Date,
                    UnitPrice = body.UnitPrice,
                    IngredientId = body.Id
                });
            }
            if (sel.StockQuantity != body.StockQuantity)
            {
                await AddIngredientStockAsync(new IngredientStockInfoDTO()
                {
                    Date = DateTime.Now.Date,
                    StockQuantity = body.StockQuantity,
                    IngredientId = body.Id
                });
            }
            return body;
        }

        public Task RemoveIngredientAsync(int ingredientId)
        {
            var tmp = Ingredients.FirstOrDefault(f => f.Id == ingredientId);
            Ingredients.Remove(tmp);
            return Task.CompletedTask;
        }

    }
}
