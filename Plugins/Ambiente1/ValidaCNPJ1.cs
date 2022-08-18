﻿using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Uteis.Implementos;
using System;
using System.Linq;
using static Plugins.Utilidades.MeuEnum;

namespace Plugins.Ambiente1
{

    public class ValidaCNPJ : PluginImplement
    {

        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {

            Entity conta = (Entity)this.Context.InputParameters["Target"];
            string cnpj = conta["log_cnpj"].ToString();

            if (this.Context.Stage == (int)PluginStages.PreValidation)
            {
                QueryExpression recuperacnpjconta = new QueryExpression("account");
                recuperacnpjconta.Criteria.AddCondition("log_cnpj", ConditionOperator.Equal, cnpj);
                EntityCollection contas = this.Service.RetrieveMultiple(recuperacnpjconta);

                if (contas.Entities.Count() > 0)
                {
                    throw new InvalidPluginExecutionException("Já existe uma conta com este CNPJ, cadastro não pode ser realizado!");
                }
            }
        }
    }
}