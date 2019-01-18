using System;
using System.Collections.Generic;

namespace MicroservicesQuickStart.ApiGateway.Repository
{
    using Interfaces;

    public class GatewayRepository : IGatewayRepository
    {
        private static readonly Dictionary<int, bool> onlineStatuses;
        private static readonly object syncRoot;

        static GatewayRepository()
        {
            onlineStatuses = new Dictionary<int, bool>();
            syncRoot = new object();
        }

        public bool? GetOnlineStatus(int serviceId)
        {
            lock (syncRoot)
            {
                return onlineStatuses.ContainsKey(serviceId)
                    ? onlineStatuses[serviceId]
                    : (bool?)null;
            }
        }

        public bool SaveOnlineStatus(int serviceId, bool status)
        {
            lock (syncRoot)
            {
                if (onlineStatuses.ContainsKey(serviceId))
                {
                    onlineStatuses[serviceId] = status;
                }
                else
                {
                    onlineStatuses.Add(serviceId, status);
                }
            }
            return true;
        }
    }
}
