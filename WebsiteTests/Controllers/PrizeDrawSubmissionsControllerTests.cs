using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Website.Controllers;

namespace WebsiteTests.Controllers
{
    public class PrizeDrawSubmissionsControllerTests
    {
        [Fact]
        public void Index_Should_Returns_AViewResult()
        {
            // Arrange
            var mockRepo = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(mockRepo.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
        }
    }
}
