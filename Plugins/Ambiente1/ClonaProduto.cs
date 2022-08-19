using System;
using Microsoft.Xrm.Sdk;
using Plugins.Models;
using Uteis.Implementos;

namespace Plugins.Ambiente1
{
    public class ClonaProduto : PluginImplement
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            if (this.Context.InputParameters.Contains("Target") &&
                this.Context.InputParameters["Target"] is Entity)
            {
                Entity produto = (Entity)this.Context.InputParameters["Target"];
                produto["log2_bloquearcriacao"] = false;
                Produto.CopiaProduto(this.Service, produto);
            }
        }
    }
}
