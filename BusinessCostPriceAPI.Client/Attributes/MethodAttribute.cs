using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCostPriceAPI.Client.Services
{
    public class MethodAttribute : Attribute
    {
        public Method Method { get; set; }
        public MethodAttribute(Method method)
        {
            Method = method;
        }
    }
}
