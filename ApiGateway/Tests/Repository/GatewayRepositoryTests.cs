using Moq;
using Xunit;

namespace MicroservicesQuickStart.ApiGateway.UnitTests.Repository
{
    using ApiGateway.Repository;
    using ApiGateway.Repository.Interfaces;

    public class GatewayRepositoryTests
    {
        private readonly IGatewayRepository _repository;

        public GatewayRepositoryTests()
        {
            _repository = new GatewayRepository(); // TODO Inject from Gateway app container
        }

        [Fact]
        public void SaveOnlineStatus()
        {
            // Arrange
            var serviceId = 1;
            var online = true;

            // Act
            var saved = _repository.SaveOnlineStatus(serviceId, online);
            var actual = _repository.GetOnlineStatus(serviceId);

            // Assert
            Assert.True(saved);
            Assert.Equal(online, actual ?? false);
        }
    }
}
