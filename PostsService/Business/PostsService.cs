using System;

namespace TVX.Test.PostsService.Business
{
    using Core;
    using Interfaces;
    using ApiGateway.Models;

    public class PostsService : IPostsService
    {
        public int ServiceID { get; } = 1;

        public IMicroService GetServiceDescriptor()
        {
            return new MicroService
            {
                Id = ServiceID,
                IsOnline = true,
                Name = nameof(PostsService),
                EndpointUrl = "http://tvx-test-postsservice.azurewebsites.net/api/"
            };
        }
    }
}
