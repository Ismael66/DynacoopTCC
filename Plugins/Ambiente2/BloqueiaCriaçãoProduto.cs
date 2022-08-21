using Microsoft.Xrm.Sdk;
using Uteis.Implementos;
using System;
using Plugins.Utilidades;

namespace Plugins.Ambiente2
{
    public class BloqueiaCriaçãoProduto : PluginImplement
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            if (ValidatePlugin.Validate(Context, MeuEnum.MessageName.Create, MeuEnum.PluginStages.PreValidation, MeuEnum.Mode.Synchronous))
            {
                if (Context.InputParameters.Contains("Target") &&
                Context.InputParameters["Target"] is Entity)
                {
                    Entity produto = (Entity)this.Context.InputParameters["Target"];
                    bool bloqueaCriacao = produto.GetAttributeValue<bool>("log2_bloquearcriacao");
                    if (bloqueaCriacao)
                    {
                        throw new InvalidPluginExecutionException("Não é possivel criar produto no Ambiente 2, " +
                                                            "a criação de produtos é permitida somente no Ambiente 1");
                    }
                }
            }
        }
    }
}
