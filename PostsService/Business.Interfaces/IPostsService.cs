using System;

namespace TVX.Test.PostsService.Business.Interfaces
{
    using Core;

    public interface IPostsService : IMicroserviceDescriptor
    {
        int ServiceID { get; }
    }
}
