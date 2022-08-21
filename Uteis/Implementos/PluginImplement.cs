using Microsoft.Xrm.Sdk;
using System;
using Plugins.Utilidades;

namespace Uteis.Implementos
{
    public abstract class PluginImplement : IPlugin
    {
        public IPluginExecutionContext Context { get; set; }
        public IOrganizationServiceFactory ServiceFactory { get; set; }
        public IOrganizationService Service { get; set; }
        public ITracingService TracingService { get; set; }

        public void Execute(IServiceProvider serviceProvider)
        {
            Context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            ServiceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            Service = ServiceFactory.CreateOrganizationService(Context.UserId);
            TracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            ExecutePlugin(serviceProvider);
        }
        public abstract void ExecutePlugin(IServiceProvider serviceProvider);
        public bool Validate(MeuEnum.MessageName message, MeuEnum.PluginStages stage, MeuEnum.Mode mode)
        {
            return this.Context?.MessageName.ToLower() == Enum.GetName(typeof(MeuEnum.MessageName), message).ToLower()
                && this.Context.Mode == (int)mode
                && this.Context.Stage == (int)stage;
        }
    }
}
