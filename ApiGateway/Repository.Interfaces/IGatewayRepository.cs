using System;

namespace MicroservicesQuickStart.ApiGateway.Repository.Interfaces
{
    public interface IGatewayRepository
    {
        /// <summary>
        /// Saves status of given microservice to persistent storage.
        /// </summary>
        /// <param name="serviceId">The identifier of a microservice</param>
        /// <param name="status">Actual status of a microservice</param>
        /// <returns>True if the status has saved successfully; otherwise it returns False.</returns>
        bool SaveOnlineStatus(int serviceId, bool status);

        /// <summary>
        /// Gets online status of given microservice from persistent storage without checking actual status by communicating to microservice end-point.
        /// </summary>
        /// <param name="serviceId">The identifier of a microservice</param>
        /// <returns>True if the status has cached and it is online; otherwise it returns False or Null.</returns>
        bool? GetOnlineStatus(int serviceId);
    }
}
