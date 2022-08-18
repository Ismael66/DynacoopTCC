using Microsoft.Xrm.Sdk;
using Uteis.Implementos;
using System;

namespace Plugins.Ambiente2
{
    public class BloqueiaCriaçãoProduto : PluginImplement
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            throw new InvalidPluginExecutionException("Não é possivel criar produto no ambiente Dynamics2, " +
                                                        "a criação de produtos é permitida somente no ambiente Dynamics1");
        }
    }
}
