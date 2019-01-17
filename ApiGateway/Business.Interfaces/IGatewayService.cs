using System;
using System.Threading.Tasks;

namespace TVX.Test.ApiGateway.Business.Interfaces
{
    using Core;
    using Models;

    public interface IGatewayService
    {
        /// <summary>
        /// Checks online status of the Posts microservice.
        /// </summary>
        /// <returns>True if the Posts service has Online status; otherwise it returns False.</returns>
        Task<bool> IsPostsServiceOnlineAsync();

        /// <summary>
        /// Checks online status of the Comments microservice.
        /// </summary>
        /// <returns>True if the Comments service has Online status; otherwise it returns False.</returns>
        Task<bool> IsCommentsServiceOnlineAsync();

        /// <summary>
        /// Gets the count of posts in the Posts storage.
        /// </summary>
        int PostsCount { get; }

        /// <summary>
        /// Gets the count of comments in the Comments storage.
        /// </summary>
        int CommentsCount { get; }

        /// <summary>
        /// Gets microservice descriptor by ID.
        /// </summary>
        /// <param name="serviceId">Identifier of a service</param>
        /// <returns><see cref="MicroService"/> object with all initialized properties.</returns>
        IMicroService GetServiceDescriptor(int serviceId);
    }
}
