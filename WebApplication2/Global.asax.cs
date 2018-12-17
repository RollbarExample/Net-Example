using Rollbar;
using Rollbar.DTOs;
using Rollbar.Telemetry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApplication2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            const string postServerItemAccessToken = "d903ca7d69e044908479c96e8c4af17a";
            RollbarLocator.RollbarInstance.Configure(new RollbarConfig(postServerItemAccessToken)
            {
                Environment = "production"
            });
            SetRollbarReportingUser("007", "jbond@mi6.uk", "JBOND");
            ConfigureRollbarTelemetry();
            ConfigureRollbarServer();



        }

        private static void SetRollbarReportingUser(string id, string email, string userName)
        {
            Person person = new Person(id);
            person.Email = email;
            person.UserName = userName;
            RollbarLocator.RollbarInstance.Config.Person = person;
            
        }

    
        private static void ConfigureRollbarTelemetry()
        {
            TelemetryConfig telemetryConfig = new TelemetryConfig(
              telemetryEnabled: true,
              telemetryQueueDepth: 3
            );
            TelemetryCollector.Instance.Config.Reconfigure(telemetryConfig);
        }

        private static void ConfigureRollbarServer()
        {
            TelemetryConfig telemetryConfig = new TelemetryConfig(
              telemetryEnabled: true,
              telemetryQueueDepth: 3
            );
            Server server = new Server();
            server.CodeVersion = "2";
            RollbarLocator.RollbarInstance.Config.Server = server;
        }
    }
}
