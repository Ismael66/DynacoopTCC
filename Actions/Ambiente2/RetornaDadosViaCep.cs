using Actions.Requisicoes;
using System;
using Uteis.Implementos;

namespace Actions.Ambiente2
{
    public class Action : PluginImplement
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            var cep = this.Context.InputParameters["Cep"].ToString();
            var dadosCep = ViaCep.RequisicaoViaCep(cep).Result;
            this.Context.OutputParameters["DadosCep"] = dadosCep;
        }
    }
}
