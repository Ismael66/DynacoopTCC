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
            Entity oportunidade = (Entity)this.Context.InputParameters["Target"];

            Guid opportunityid = (Guid)oportunidade.Id;

            QueryExpression queryoportunidade = new QueryExpression("opportunity");
            queryoportunidade.ColumnSet.AddColumns("name", "parentcontactid", "parentcontactid", "purchasetimeframe", "transactioncurrencyid", "budgetamount", "purchaseprocess", "description", "msdyn_forecastcategory", "log_idalfa", "currentsituation", "customerneed");
            queryoportunidade.Criteria.AddCondition("opportunityid", ConditionOperator.Equal, opportunityid);
            EntityCollection retri = this.Service.RetrieveMultiple(queryoportunidade);

            foreach(Entity entidade in retri.Entities)
            {
                Service.Create(entidade);
            }

        }
    }
}
