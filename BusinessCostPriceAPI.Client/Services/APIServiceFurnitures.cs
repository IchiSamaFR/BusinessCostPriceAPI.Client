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
        [ControllerRoute("Furnitures/GetFurnitures")]
        public async Task<List<FurnitureDTO>> GetFurnituresAsync(int? page)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(page), page.ToString());

            return await GetResponse<List<FurnitureDTO>>(request);
        }

        [Method(Method.Get)]
        [ControllerRoute("Furnitures/GetFurniture")]
        public async Task<FurnitureDTO> GetFurnitureAsync(int? furnitureId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(furnitureId), furnitureId.ToString());

            return await GetResponse<FurnitureDTO>(request);
        }

        [Method(Method.Get)]
        [ControllerRoute("Furnitures/GetFurniturePriceInfos")]
        public async Task<List<FurniturePriceInfoDTO>> GetFurniturePriceInfosAsync(int? furnitureId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(furnitureId), furnitureId.ToString());

            return await GetResponse<List<FurniturePriceInfoDTO>>(request);
        }

        [Method(Method.Get)]
        [ControllerRoute("Furnitures/GetFurnitureStockInfos")]
        public async Task<List<FurnitureStockInfoDTO>> GetFurnitureStockInfosAsync(int? furnitureId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(furnitureId), furnitureId.ToString());

            return await GetResponse<List<FurnitureStockInfoDTO>>(request);
        }

        [Method(Method.Post)]
        [ControllerRoute("Furnitures/AddFurniture")]
        public async Task<FurnitureDTO> AddFurnitureAsync(FurnitureDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetResponse<FurnitureDTO>(request);
        }

        [Method(Method.Post)]
        [ControllerRoute("Furnitures/AddFurniturePrice")]
        public async Task<FurniturePriceInfoDTO> AddFurnitureStockAsync(FurniturePriceInfoDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetResponse<FurniturePriceInfoDTO>(request);
        }

        [Method(Method.Post)]
        [ControllerRoute("Furnitures/AddFurnitureStock")]
        public async Task<FurnitureStockInfoDTO> AddFurnitureStockAsync(FurnitureStockInfoDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetResponse<FurnitureStockInfoDTO>(request);
        }

        [Method(Method.Put)]
        [ControllerRoute("Furnitures/UpdateFurniture")]
        public async Task<FurnitureDTO> UpdateFurnitureAsync(FurnitureDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetResponse<FurnitureDTO>(request);
        }

        [Method(Method.Delete)]
        [ControllerRoute("Furnitures/RemoveFurniture")]
        public async Task RemoveFurnitureAsync(int? furnitureId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(furnitureId), furnitureId.ToString());

            await GetResponse(request);
        }
    }
}
