using Microsoft.AspNetCore.Mvc;
using Moq;
using Q.Api.Controllers;
using Q.DataAccess;
using Q.Domain;
using System;
using System.Collections.Generic;
using Xunit;

namespace Q.Tests
{
    public class VideoTests
    {
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var repo = new Mock<IBaseRepository<Video>>();
            var list = new List<Video> {new Video {Id = 1, Name = "Test"}};
            repo.Setup(c => c.GetAllAsync()).ReturnsAsync(list);

            var controller = new VideoController(repo.Object);

            // Act
            var okResult = controller.Get().Result;

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_By_Unknown_Id_ReturnsNotFound()
        {
            var repo = new Mock<IBaseRepository<Video>>();
            var id = 12;
            repo.Setup(c => c.GetByIdAsync(id)).ReturnsAsync(default(Video));

            var controller=new VideoController(repo.Object);
            var notFoundResult = controller.Get(id).Result.Result;

            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public async void Get_By_Id_Should_Return_Correct_Item()
        {
            var repo = new Mock<IBaseRepository<Video>>();
            var id = 12;
            repo.Setup(c => c.GetByIdAsync(id)).ReturnsAsync(new Video {Id = id,CreatedOnUtc = DateTime.UtcNow,UpdatedOnUtc = DateTime.UtcNow});

            var controller = new VideoController(repo.Object);
            var found =  (await controller.Get(id)).Result as OkObjectResult;

            Assert.IsType<Video>(found.Value);

            var video = (Video) found.Value;
            Assert.Equal(id, video.Id);
        }
    }
}
