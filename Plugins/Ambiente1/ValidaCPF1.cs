using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Uteis.Implementos;
using System;
using System.Linq;
using static Plugins.Utilidades.MeuEnum;

namespace Plugins.Ambiente1
{
    public class ValidaCPF : PluginImplement
    {

        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {

            Entity contato = (Entity)this.Context.InputParameters["Target"];
            string cpf = contato["log_cpf"].ToString();

            if (this.Context.Stage == (int)PluginStages.PreValidation)
            {
                QueryExpression recuperacpfcontato = new QueryExpression("contact");
                recuperacpfcontato.Criteria.AddCondition("log_cpf", ConditionOperator.Equal, cpf);
                EntityCollection contatos = this.Service.RetrieveMultiple(recuperacpfcontato);

                if (contatos.Entities.Count() > 0)
                {
                    throw new InvalidPluginExecutionException("Já existe uma conta com este CPF, cadastro não pode ser realizado!");
                }
            }
        }
    }
}