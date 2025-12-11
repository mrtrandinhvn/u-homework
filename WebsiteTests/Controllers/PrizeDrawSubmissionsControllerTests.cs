using Application.Common;
using Application.Services.PrizeDrawSubmissions.Read;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Website.Controllers;

namespace WebsiteTests.Controllers
{
    public class PrizeDrawSubmissionsControllerTests
    {
        [Fact]
        public async Task Index_Should_Returns_AViewResult()
        {
            // setup
            var input = new GetPaginatedSubmissionsInput
            {
                Page = 1,
                PageSize = 10,
            };
            var mockRepo = new Mock<IPrizeDrawSubmissionReadRepository>();
            mockRepo.Setup(x => x.GetPaginatedResultAsync(input))
            .ReturnsAsync(new PaginationOutput<ProductPrizeDrawSubmissionReadModel>
            {
                CurrentPage = 1,
                Data = new List<ProductPrizeDrawSubmissionReadModel>
                {
                        new ProductPrizeDrawSubmissionReadModel
                        {
                            Id = 1,
                            OwnerEmail = string.Empty,
                            OwnerFirstName = string.Empty,
                            OwnerLastName = string.Empty,
                            ProductSerialNumber = string.Empty,
                        }
                },
                TotalRecords = 10,
            });
            var controller = new PrizeDrawSubmissionsController(mockRepo.Object);

            // execution
            var result = await controller.Index(input);

            // asserts
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<PaginationOutput<ProductPrizeDrawSubmissionReadModel>>(viewResult.ViewData.Model);
            Assert.NotNull(viewResult);
            Assert.NotNull(model);
            Assert.Equal(1, model.CurrentPage);
            Assert.Equal(10, model.TotalRecords);
            Assert.Single(model.Data);
        }
    }
}
