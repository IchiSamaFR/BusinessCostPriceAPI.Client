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
        public Task<List<FurnitureDTO>> GetFurnituresAsync(int? page)
        {
            return Task.FromResult(Furnitures.Select(i => GetFurnitureAsync(i.Id).Result).ToList());
        }
        public Task<FurnitureDTO> GetFurnitureAsync(int? furnitureId)
        {
            var tmp = Furnitures.FirstOrDefault(i => i.Id == furnitureId);
            tmp.UnitPrice = GetFurniturePriceInfosAsync(furnitureId ?? 0).Result.LastOrDefault()?.UnitPrice ?? 0;
            tmp.StockQuantity = GetFurnitureStockInfosAsync(furnitureId ?? 0).Result.LastOrDefault()?.StockQuantity ?? 0;
            return Task.FromResult(tmp);
        }

        public Task<List<FurniturePriceInfoDTO>> GetFurniturePriceInfosAsync(int furnitureId)
        {
            return Task.FromResult(FurniturePriceInfos.Where(r => r.FurnitureId == furnitureId).OrderBy(r => r.Date).ToList());
        }
        public Task<List<FurniturePriceInfoDTO>> GetFurniturePriceInfosByAsync(int furnitureId, Period period, int limit)
        {
            throw new NotImplementedException();
        }

        public Task<List<FurnitureStockInfoDTO>> GetFurnitureStockInfosAsync(int furnitureId)
        {
            return Task.FromResult(FurnitureStockInfos.Where(r => r.FurnitureId == furnitureId).OrderBy(r => r.Date).ToList());
        }
        public Task<List<FurnitureStockInfoDTO>> GetFurnitureStockInfosByAsync(int furnitureId, Period period, int limit)
        {
            throw new NotImplementedException();
        }

        public async Task<FurnitureDTO> AddFurnitureAsync(FurnitureDTO body)
        {
            body.Id = Furnitures.LastOrDefault()?.Id + 1 ?? 1;
            Furnitures.Add(body);
            await AddFurniturePriceAsync(new FurniturePriceInfoDTO()
            {
                Date = DateTime.Now.Date,
                UnitPrice = body.UnitPrice,
                FurnitureId = body.Id
            });
            await AddFurnitureStockAsync(new FurnitureStockInfoDTO()
            {
                Date = DateTime.Now.Date,
                StockQuantity = body.StockQuantity,
                FurnitureId = body.Id
            });
            return body;
        }
        public Task<FurniturePriceInfoDTO> AddFurniturePriceAsync(FurniturePriceInfoDTO body)
        {
            var sel = FurniturePriceInfos.Find((f) => f.FurnitureId == body.FurnitureId && f.Date.Date == DateTime.Now.Date);

            if (sel == null)
            {
                body.Date = DateTime.Now.Date;
                FurniturePriceInfos.Add(body);
                return Task.FromResult(body);
            }
            sel.UnitPrice = body.UnitPrice;
            return Task.FromResult(sel);
        }
        public Task<FurnitureStockInfoDTO> AddFurnitureStockAsync(FurnitureStockInfoDTO body)
        {
            var sel = FurnitureStockInfos.Find((f) => f.FurnitureId == body.FurnitureId && f.Date.Date == DateTime.Now.Date);

            if (sel == null)
            {
                body.Date = DateTime.Now.Date;
                FurnitureStockInfos.Add(body);
                return Task.FromResult(body);
            }
            sel.StockQuantity = body.StockQuantity;
            return Task.FromResult(sel);
        }


        public async Task<FurnitureDTO> UpdateFurnitureAsync(FurnitureDTO body)
        {
            var sel = Furnitures.FirstOrDefault(f => f.Id == body.Id);
            Furnitures.Remove(sel);
            Furnitures.Add(body);

            if (sel.UnitPrice != body.UnitPrice)
            {
                await AddFurniturePriceAsync(new FurniturePriceInfoDTO()
                {
                    Date = DateTime.Now.Date,
                    UnitPrice = body.UnitPrice,
                    FurnitureId = body.Id
                });
            }
            if (sel.StockQuantity != body.StockQuantity)
            {
                await AddFurnitureStockAsync(new FurnitureStockInfoDTO()
                {
                    Date = DateTime.Now.Date,
                    StockQuantity = body.StockQuantity,
                    FurnitureId = body.Id
                });
            }
            return body;
        }

        public Task RemoveFurnitureAsync(int? furnitureId)
        {
            var tmp = Furnitures.FirstOrDefault(f => f.Id == furnitureId);
            Furnitures.Remove(tmp);
            return Task.CompletedTask;
        }
    }
}
