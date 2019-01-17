using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TVX.Test.ApiGateway.Business
{
    using Core;
    using Interfaces;
    using Models;
    using PostsService.Business.Interfaces;

    public class GatewayService : IGatewayService
    {
        private readonly IPostsService _postsService;

        public GatewayService(IPostsService postsService)
        {
            _postsService = postsService;
        }

        public const int PostsServiceID = 1;
        public const int CommentsServiceID = 2;

        public int PostsCount => throw new NotImplementedException();

        public int CommentsCount => throw new NotImplementedException();

        public Task<bool> IsCommentsServiceOnlineAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsPostsServiceOnlineAsync()
        {
            var descriptor = _postsService.GetServiceDescriptor();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(descriptor.EndpointUrl + "values");
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody.Contains("value1") && responseBody.Contains("value2");
                }
                catch (HttpRequestException)
                {
                    return false;
                }
            }
        }

        public IMicroService GetServiceDescriptor(int serviceId)
        {
            switch (serviceId)
            {
                case PostsServiceID:
                    return _postsService.GetServiceDescriptor();
                default:
                    return new MicroService { Id = -1 };
            }
        }
    }
}
