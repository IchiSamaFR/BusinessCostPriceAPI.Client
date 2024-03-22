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
        [ControllerRoute("Furnitures/GetFurnitures")]
        public static async Task<List<FurnitureDTO>> GetFurnituresAsync(int? page)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(page), page.ToString());

            return await GetReponse<List<FurnitureDTO>>(request);
        }

        [Method(Method.Get)]
        [ControllerRoute("Furnitures/GetFurniture")]
        public static async Task<FurnitureDTO> GetFurnitureAsync(int? furnitureId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(furnitureId), furnitureId.ToString());

            return await GetReponse<FurnitureDTO>(request);
        }

        [Method(Method.Get)]
        [ControllerRoute("Furnitures/GetFurnitureStockInfos")]
        public static async Task<List<FurnitureStockInfoDTO>> GetFurnitureStockInfosAsync(int? furnitureId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(furnitureId), furnitureId.ToString());

            return await GetReponse<List<FurnitureStockInfoDTO>>(request);
        }

        [Method(Method.Post)]
        [ControllerRoute("Furnitures/AddFurniture")]
        public static async Task<FurnitureDTO> AddFurnitureAsync(FurnitureDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetReponse<FurnitureDTO>(request);
        }

        [Method(Method.Post)]
        [ControllerRoute("Furnitures/AddFurnitureStock")]
        public static async Task<FurnitureStockInfoDTO> AddFurnitureStockAsync(FurnitureStockInfoDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetReponse<FurnitureStockInfoDTO>(request);
        }

        [Method(Method.Put)]
        [ControllerRoute("Furnitures/UpdateFurniture")]
        public static async Task<FurnitureDTO> UpdateFurnitureAsync(FurnitureDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetReponse<FurnitureDTO>(request);
        }

        [Method(Method.Delete)]
        [ControllerRoute("Furnitures/RemoveFurniture")]
        public static async Task RemoveFurnitureAsync(int? furnitureId)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddParameter(nameof(furnitureId), furnitureId.ToString());

            await GetReponse(request);
        }
    }
}
