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
        public Task<AuthenticateDTO> RegisterAsync(AuthenticateDTO body)
        {
            body.Password = string.Empty;
            body.Token = new Guid().ToString();
            return Task.FromResult(body);
        }
        public Task<AuthenticateDTO> LoginAsync(AuthenticateDTO body)
        {
            body.Password = string.Empty;
            body.Token = Guid.NewGuid().ToString();
            return Task.FromResult(body);
        }
        public Task<AuthenticateDTO> UpdatePasswordAsync(AuthenticateDTO body)
        {
            body.Password = string.Empty;
            return Task.FromResult(body);
        }
    }
}
