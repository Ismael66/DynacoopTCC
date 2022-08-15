using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Plugins.Utilidades;
using System;
using static Plugins.Utilidades.MeuEnum;

namespace Plugins.Ambiente1
{
    public class ContadordeNumero : PluginImplement
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            if (Context.InputParameters.Contains("Target") && Context.InputParameters["Target"] is Entity)
            {
                if (this.Context.Stage == (int)PluginStages.PostOperation)
                {

                    Entity entity = (Entity)Context.InputParameters["Target"];

                    QueryExpression queryautocontador = new QueryExpression("log_autocontador");
                    queryautocontador.ColumnSet.AddColumns("log_autocontadorid", "log_numerocorrente");
                    queryautocontador.AddOrder("log_numerocorrente", OrderType.Ascending);
                    queryautocontador.Criteria.AddCondition("log_regra", ConditionOperator.Equal, "AUTONUMBER");
                    EntityCollection ecAuto = Service.RetrieveMultiple(queryautocontador);


                    Entity entAuto = ecAuto[0];
                    var autoNumberRecordId = entAuto.Id;

                    Entity Tabelacontador = new Entity("log_autocontador");
                    Tabelacontador.Attributes["log_contano"] = "trancar " + DateTime.Now;
                    Tabelacontador.Id = autoNumberRecordId;
                    Service.Update(Tabelacontador);

                    Entity AutoPost = Service.Retrieve("log_autocontador", autoNumberRecordId, new ColumnSet(true));
                    var registroatual = AutoPost.GetAttributeValue<String>("log_numerocorrente");

                    var valorcontador = Convert.ToInt32(registroatual) + 1;

                    Entity updateid = new Entity();
                    updateid.LogicalName = entity.LogicalName;
                    updateid.Id = entity.Id;
                    updateid["log_idalfa"] = "OPP-" + valorcontador.ToString() + "-A1A2";
                    Service.Update(updateid);

                    Entity updateidconfig = new Entity();
                    updateidconfig.LogicalName = "log_autocontador";
                    updateidconfig.Id = autoNumberRecordId;
                    updateidconfig["log_numerocorrente"] = valorcontador.ToString();
                    Service.Update(updateidconfig);

                }
            }
        }
    }
}
