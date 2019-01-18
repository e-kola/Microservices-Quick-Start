using System;

namespace MicroservicesQuickStart.Core
{
    public interface IMicroserviceDescriptor
    {
        /// <summary>
        /// Gets microservice descriptor.
        /// </summary>
        /// <returns><see cref="IMicroService"/> object with all initialized properties.</returns>
        IMicroService GetServiceDescriptor();
    }
}
