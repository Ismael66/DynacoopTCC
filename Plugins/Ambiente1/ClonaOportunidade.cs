using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Plugins.Models;
using Plugins.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uteis.Implementos;

namespace Plugins.Ambiente1
{
    public class ClonaOportunidade : PluginImplement
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            IOrganizationService serviceAmbienteDois = Conexao.GetService();
            Oportunidade opp = new Oportunidade();


            if (Context.MessageName == "Create")
            {
                var opportunity = (Entity)Context.InputParameters["Target"];
                var integrationOpportunity = new Entity("opportunity");

                foreach (var field in opportunity.Attributes)
                {
                    if (field.Value != null)
                    {
                        if (field.Value.GetType() == new EntityReference().GetType())
                        {
                            if (!opp.getIgnoreFields().ToList().Contains(((EntityReference)field.Value).LogicalName) && field.Key != $"{((EntityReference)field.Value).LogicalName}id")
                                integrationOpportunity[field.Key] = opp.ValidateLookup(field, Service, serviceAmbienteDois);
                        }
                        else
                        {
                            integrationOpportunity[field.Key] = field.Value;
                        }
                    }
                }


                integrationOpportunity["log2_idalfa"] = opportunity["log_idalfa"];
                integrationOpportunity["log2_integracao"] = true;



                serviceAmbienteDois.Create(integrationOpportunity);
            }
        }
    }
}
