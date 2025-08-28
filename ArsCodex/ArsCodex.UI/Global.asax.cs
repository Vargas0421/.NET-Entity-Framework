using ArsCodex.LogicaDeNegocios.Comunes.ManejoDeErrores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ArsCodex.UI
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
		protected void Application_Error()
		{
			// Manejo de errores globales
			var exception = Server.GetLastError();
            GlobalErrorHandler globalErrorHandler = new GlobalErrorHandler(); // Instancia del manejador de errores globales 
            globalErrorHandler.HandleError(HttpContext.Current, exception);// Llamada al método HandleError para registrar el error
            Response.Clear();
			Server.ClearError();
			Response.Redirect("~/Home/Error");
        }
    }
}
