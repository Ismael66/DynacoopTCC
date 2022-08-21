using System;
using Microsoft.Xrm.Sdk;
using Plugins.Models;
using Plugins.Utilidades;
using Uteis.Implementos;

namespace Plugins.Ambiente1
{
    public class ClonaProduto : PluginImplement
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            if (ValidatePlugin.Validate(Context, MeuEnum.MessageName.Create, MeuEnum.PluginStages.PostOperation, MeuEnum.Mode.Synchronous))
            {
                if (Context.InputParameters.Contains("Target") &&
                    Context.InputParameters["Target"] is Entity)
                {
                    Entity produto = (Entity)this.Context.InputParameters["Target"];
                    produto["log2_bloquearcriacao"] = false;
                    Produto.CopiaProduto(this.Service, produto);
                }
            }
        }
    }
}
