using System.Collections.Generic;
using Infra;
using Services.Interfaces;

namespace Services.Commons
{
    public abstract class BaseService : IServiceScoped
    {
        protected readonly ApplicationContext context;
        public readonly IDictionary<string, string> Notifications;

        protected BaseService(ApplicationContext context)
        {
            this.context = context;
            Notifications = new Dictionary<string, string>();
        }
    }
}