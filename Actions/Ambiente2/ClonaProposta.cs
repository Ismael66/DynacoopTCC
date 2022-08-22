using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Linq;
using Uteis.Implementos;


namespace Actions.Ambiente2
{
    public class ClonaProposta : PluginImplement
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            string opportunityid = this.Context.InputParameters["idoportunidade"].ToString();
            TracingService.Trace("1");
            QueryExpression queryoportunidade = new QueryExpression("opportunity");
            queryoportunidade.ColumnSet = new ColumnSet { AllColumns = true };
            queryoportunidade.Criteria.AddCondition("opportunityid", ConditionOperator.Equal, opportunityid);
            Entity retri = Service.RetrieveMultiple(queryoportunidade).Entities.FirstOrDefault();

            Entity newOpp = retri;
            newOpp.Id = Guid.Empty;
            newOpp.Attributes.Remove("opportunityid");
            newOpp["stepname"] = "1-Qualificar";
            Service.Create(newOpp);
            
        }
    }
}



