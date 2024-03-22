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
        [Method(Method.Post)]
        [ControllerRoute("Authenticate/Register")]
        public static async Task<AuthenticateDTO> RegisterAsync(AuthenticateDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetReponse<AuthenticateDTO>(request);
        }

        [Method(Method.Post)]
        [ControllerRoute("Authenticate/Login")]
        public static async Task<AuthenticateDTO> LoginAsync(AuthenticateDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetReponse<AuthenticateDTO>(request);
        }

        [Method(Method.Post)]
        [ControllerRoute("Authenticate/UpdatePassword")]
        public static async Task<AuthenticateDTO> UpdatePasswordAsync(AuthenticateDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetReponse<AuthenticateDTO>(request);
        }
    }
}
