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
                "Username=IsmaelMateus@Academia404.onmicrosoft.com;" +
                "Password=WD7eHF@E2UYtaGf;" +
                "Url=https://org16648a2c.crm2.dynamics.com/;" +
                "AppId=7e224302-bee1-428c-9e5f-e80a24ceeced;" +
                "RedirectUri=app://9896d91c-3ad3-4762-918f-3024bebc5d1a;";

            CrmServiceClient crmServiceClient = new CrmServiceClient(connectionString);
            return crmServiceClient.OrganizationWebProxyClient;
        }
    }
}
