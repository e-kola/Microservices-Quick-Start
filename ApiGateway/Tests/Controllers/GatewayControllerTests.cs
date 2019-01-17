using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TVX.Test.ApiGateway.UnitTests.Controllers
{
    using ApiGateway.Controllers;
    using ApiGateway.Business;
    using ApiGateway.Business.Interfaces;
    using ApiGateway.Repository.Interfaces;
    using Models;
    using PostsService.Business;
    using PostsService.Business.Interfaces;

    public class GatewayControllerTests
    {
        [Fact]
        public async Task GetServiceDescriptor_ReturnsAModel()
        {
            // Arrange
            var expectedId = 123;
            var mockSrvc = new Mock<IGatewayService>();
            mockSrvc.Setup(srv => srv.GetServiceDescriptor(expectedId)).Returns(GetTestObject());
            var mockRepo = new Mock<IGatewayRepository>();
            var controller = new GatewayController(mockSrvc.Object, mockRepo.Object);

            // Act
            var result = await controller.GetServiceDescriptor(expectedId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<MicroService>(result);
        }

        private MicroService GetTestObject()
        {
            return new MicroService();
        }

        [Fact]
        public async Task GetServiceDescriptor_Integration()
        {
            // Arrange
            var expectedId = 1;
            var mockRepo = new Mock<IGatewayRepository>();

            var service = new GatewayService(new PostsService());
            var controller = new GatewayController(service, mockRepo.Object);

            // Act
            var actual = await controller.GetServiceDescriptor(expectedId);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedId, actual.Id);
        }
    }
}
