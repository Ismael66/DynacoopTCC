using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;

namespace Plugins.Utilidades
{
    internal class Conexao
    {
        public static IOrganizationService GetService()
        {
            string connectionString =
                "AuthType=OAuth;" +
                "Username=admin@logisticssworkss.onmicrosoft.com;" +
                "Password=@a1b2c3d4;" +
                "Url=https://logisticsdynamics2.crm2.dynamics.com/;" +
                "AppId=5c9792f6-f4b4-4f42-ab73-919768e0fb80;" +
                "RedirectUri=app://9896d91c-3ad3-4762-918f-3024bebc5d1a;";

            CrmServiceClient crmServiceClient = new CrmServiceClient(connectionString);
            return crmServiceClient.OrganizationWebProxyClient;
        }

        public static IOrganizationService GetServiceAmbUm()
        {
            string connectionString =
                "AuthType=OAuth;" +
                "Username=admin@logisticssworkss.onmicrosoft.com;" +
                "Password=@a1b2c3d4;" +
                "Url=https://logisticsdynamics1.crm2.dynamics.com/;" +
                "AppId=5c9792f6-f4b4-4f42-ab73-919768e0fb80;" +
                "RedirectUri=app://9896d91c-3ad3-4762-918f-3024bebc5d1a;";

            CrmServiceClient crmServiceClient = new CrmServiceClient(connectionString);
            return crmServiceClient.OrganizationWebProxyClient;
        }


    }
}
