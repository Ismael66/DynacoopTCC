﻿using Microsoft.Xrm.Sdk;
using Uteis.Implementos;
using System;

namespace Plugins.Ambiente2
{
    public class BloqueiaCriaçãoProduto : PluginImplement
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            if (this.Context.InputParameters.Contains("Target") &&
                this.Context.InputParameters["Target"] is Entity)
            {
                Entity produto = (Entity)this.Context.InputParameters["Target"];
                bool bloqueaCriacao = produto.GetAttributeValue<bool>("log2_bloquearcriacao");
                if (bloqueaCriacao)
                {
                    throw new InvalidPluginExecutionException("Não é possivel criar produto no ambiente Ambiente 2, " +
                                                        "a criação de produtos é permitida somente no ambiente Ambiente 1");
                }
            }
        }
    }
}
