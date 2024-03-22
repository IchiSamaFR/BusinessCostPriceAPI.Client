using BusinessCostPriceAPI.Client.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCostPriceAPI.Client.Services
{
    public partial class APIService : IAPIService
    {
        public static string Url = @"http://localhost:5281/";
        public static string JwtToken = "";
        public static bool IsLogged
        {
            get
            {
                return !string.IsNullOrEmpty(JwtToken);
            }
        }

        public static void SetUrl(string url)
        {
            Url = url.LastOrDefault() == '/' ? url : url + "/";
        }

        private async Task<T> GetReponse<T>(RestRequest request)
        {
            if (!string.IsNullOrEmpty(JwtToken))
            {
                request.AddHeader("Authorization", "Bearer " + JwtToken);
            }

            var client = new RestClient(Url);
            RestResponse response = await client.ExecuteAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<T>(response.Content);
            }
            else if (response.StatusCode == 0)
            {
                throw new ApiException("The HTTP status code of the response was not expected (" + response.StatusCode + ").", (int)response.StatusCode, "Server not available.", response.Headers?.ToList() ?? new List<HeaderParameter>(), null);
            }
            else
            {
                throw new ApiException("The HTTP status code of the response was not expected (" + response.StatusCode + ").", (int)response.StatusCode, response.Content, response.Headers?.ToList() ?? new List<HeaderParameter>(), null);
            }
        }
        private async Task GetReponse(RestRequest request)
        {
            if (!string.IsNullOrEmpty(JwtToken))
            {
                request.AddHeader("Authorization", "Bearer " + JwtToken);
            }

            var client = new RestClient(Url);
            RestResponse response = await client.ExecuteAsync(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                if (response.StatusCode == 0)
                {
                    throw new ApiException("The HTTP status code of the response was not expected (" + response.StatusCode + ").", (int)response.StatusCode, "Server not available.", response.Headers?.ToList() ?? new List<HeaderParameter>(), null);
                }
                throw new ApiException("The HTTP status code of the response was not expected (" + response.StatusCode + ").", (int)response.StatusCode, response.Content, response.Headers?.ToList() ?? new List<HeaderParameter>(), null);
            }
        }
        private string GetControllerRoute([CallerMemberName] string caller = "")
        {
            MethodBase method = MethodBase.GetCurrentMethod();
            Type declaringType = method.DeclaringType;

            MethodInfo callingMethod = declaringType.GetMethod(caller);

            object[] attributes = callingMethod.GetCustomAttributes(typeof(ControllerRouteAttribute), true);

            if (attributes.Length > 0 && attributes[0] is ControllerRouteAttribute controllerRouteAttribute)
            {
                return controllerRouteAttribute.ControllerRoute;
            }

            return "";
        }
        private Method GetMethod([CallerMemberName] string caller = "")
        {
            MethodBase method = MethodBase.GetCurrentMethod();
            Type declaringType = method.DeclaringType;

            MethodInfo callingMethod = declaringType.GetMethod(caller);

            object[] attributes = callingMethod.GetCustomAttributes(typeof(MethodAttribute), true);

            if (attributes.Length > 0 && attributes[0] is MethodAttribute methodAttribute)
            {
                return methodAttribute.Method;
            }

            return Method.Get;
        }
    }
}
