using System.Web.Http;

namespace GameStore.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            AutofacConfigService.Initialize(GlobalConfiguration.Configuration);
        }
    }
}