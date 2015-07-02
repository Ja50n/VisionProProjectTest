using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MVCWebApiSample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "AddDataMatrixInfoApi",
                routeTemplate: "api/DataMatrixInfo/Add",
                defaults: new { controller = "DataMatrixInfo", action = "Add" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
