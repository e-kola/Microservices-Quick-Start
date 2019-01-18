using System;
using Xunit;

namespace MicroservicesQuickStart.PostsService.UnitTests.Business
{
    using PostsService.Business;
    using PostsService.Business.Interfaces;

    public class PostsServiceTests
    {
        private readonly IPostsService _service;

        public PostsServiceTests()
        {
            _service = new PostsService();
        }

        [Fact]
        public void GetServiceDescriptor()
        {
            // Arrange

            // Act
            var actual = _service.GetServiceDescriptor();

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(_service.ServiceID, actual.Id);
            Assert.Equal(nameof(PostsService), actual.Name);
        }
    }
}
