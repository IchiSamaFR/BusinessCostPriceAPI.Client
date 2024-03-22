using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCostPriceAPI.Client.Service
{
    public class ControllerRouteAttribute : Attribute
    {
        public string ControllerRoute { get; set; }
        public ControllerRouteAttribute(string controllerRoute)
        {
            ControllerRoute = controllerRoute;
        }
    }
}
