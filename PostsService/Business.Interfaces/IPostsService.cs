using System;

namespace MicroservicesQuickStart.PostsService.Business.Interfaces
{
    using Core;

    public interface IPostsService : IMicroserviceDescriptor
    {
        int ServiceID { get; }
    }
}
