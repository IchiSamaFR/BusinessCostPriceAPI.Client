using BusinessCostPriceAPI.Client.Models;
using BusinessCostPriceAPI.Client.Services;
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
        [Method(Method.Post)]
        [ControllerRoute("Authenticate/Register")]
        public async Task<AuthenticateDTO> RegisterAsync(AuthenticateDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetReponse<AuthenticateDTO>(request);
        }

        [Method(Method.Post)]
        [ControllerRoute("Authenticate/Login")]
        public async Task<AuthenticateDTO> LoginAsync(AuthenticateDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetReponse<AuthenticateDTO>(request);
        }

        [Method(Method.Post)]
        [ControllerRoute("Authenticate/UpdatePassword")]
        public async Task<AuthenticateDTO> UpdatePasswordAsync(AuthenticateDTO body)
        {
            var request = new RestRequest(GetControllerRoute(), GetMethod());
            request.AddBody(body);

            return await GetReponse<AuthenticateDTO>(request);
        }
    }
}
