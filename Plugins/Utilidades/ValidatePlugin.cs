using Microsoft.Xrm.Sdk;
using System;

namespace Plugins.Utilidades
{
    public static class ValidatePlugin
    {
        public static bool Validate(IPluginExecutionContext Context, MeuEnum.MessageName message, MeuEnum.PluginStages stage, MeuEnum.Mode mode)
        {
            return Context?.MessageName.ToLower() == Enum.GetName(typeof(MeuEnum.MessageName), message).ToLower()
                && Context.Mode == (int)mode
                && Context.Stage == (int)stage;
        }
    }
}
