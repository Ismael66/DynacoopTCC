using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uteis.Implementos;

namespace Actions.Ambiente2
{
    public class ClonaProposta : PluginImplement
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            string opportunityid = this.Context.InputParameters["idoportunidade"].ToString();

            QueryExpression queryoportunidade = new QueryExpression("opportunity");
            queryoportunidade.ColumnSet = new ColumnSet { AllColumns = true };
            queryoportunidade.Criteria.AddCondition("opportunityid", ConditionOperator.Equal, opportunityid);
            Entity retri = Service.RetrieveMultiple(queryoportunidade).Entities.FirstOrDefault();

            Entity newOpp = retri;
            newOpp.Id = Guid.Empty;
            newOpp.Attributes.Remove("opportunityid");
            Service.Create(newOpp);

        }
    }
}
