using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace MicroservicesQuickStart.ApiGateway.UnitTests.Business
{
    using ApiGateway.Business;
    using ApiGateway.Business.Interfaces;
    using ApiGateway.Repository;
    using ApiGateway.Repository.Interfaces;
    using PostsService.Business;
    using PostsService.Repository;
    using PostsService.Repository.Interfaces;
    using PostsService.Models;

    /// <summary>
    /// TDD tests for the <see cref="GatewayService"/> class.
    /// </summary>
    public class GatewayServiceTests
    {
        private readonly IGatewayService _service;
        private readonly IGatewayRepository _repository;

        public GatewayServiceTests()
        {
            _service = new GatewayService(new PostsService());
            _repository = new GatewayRepository();
        }

        [Fact]
        public async Task IsPostsServiceOnline()
        {
            // Assert
            await AssertServiceOnlineStatus(GatewayService.PostsServiceID, _service.IsPostsServiceOnlineAsync);
        }

        [Fact]
        public async Task IsCommentsServiceOnline()
        {
            // Assert
            await AssertServiceOnlineStatus(GatewayService.CommentsServiceID, _service.IsCommentsServiceOnlineAsync);
        }

        private async Task AssertServiceOnlineStatus(int serviceId, Func<Task<bool>> actor)
        {
            // Arrange
            var online = true;
            var saved = _repository.SaveOnlineStatus(serviceId, online);
            var expected = _repository.GetOnlineStatus(serviceId);

            // Act
            var actual = await actor();

            // Assert
            Assert.True(saved);
            Assert.Equal(online, expected ?? false);
            Assert.Equal(expected ?? false, actual);
        }

        [Fact]
        public void PostsCount()
        {
            // Arrange
            var posts = GetTestPosts();
            var mockRepo = new Mock<IPostsRepository>();
            mockRepo.Setup(repo => repo.All()).Returns(posts);

            // Act
            var actual = _service.PostsCount;

            // Assert
            Assert.Equal(posts.Count, actual);
        }

        private List<Post> GetTestPosts()
        {
            var list = new List<Post>
            {
                new Post { Id = 1, Text = "1" },
                new Post { Id = 2, Text = "2" }
            };
            return list;
        }

    }
}
