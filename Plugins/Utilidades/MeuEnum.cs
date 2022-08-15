using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.Utilidades
{
    public static class MeuEnum
    {

        public enum PluginStages
        {
            PreValidation = 10,
            PreOperation = 20,
            PostOperation = 30
        }
    }
}