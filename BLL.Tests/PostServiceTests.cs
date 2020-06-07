using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;
using BLL.Services.Interfaces;
using BLL.Services.Impl;
using DAL.UnitOfWork;
using DAL.Entities;
using DAL.Repository.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Moq;
using System.Linq;


namespace BLL.Tests
{
    public class PostServiceTests
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(
                () => new PostService(nullUnitOfWork)
            );
        }
        [Fact]
        public void GetPosts_UserIsAdmin_ThrowMethodAccessException()
        {
            // Arrange
            User user = new Admin(1, "test", 1);
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IPostService postService = new PostService(mockUnitOfWork.Object);

            // Act
            // Assert
            Assert.Throws<MethodAccessException>(() => postService.GetPosts(0));
        }
        [Fact]
        public void GetPosts_postsFromDAL_CorrectMappingTopostsDTO()
        {
            // Arrange
            User user = new Admin(1, "test", 1);
            SecurityContext.SetUser(user);
            var postService = GetPostService();

            // Act
            var actualPostDto = postService.GetPosts(0).First();

            // Assert
            Assert.True(
                actualPostDto.postID == 1
                && actualPostDto.postName == "testN"
                && actualPostDto.postDate == "testDate"
                && actualPostDto.postAuthor == 1
                );
        }

        IPostService GetPostService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedPost = new posts() { postID = 1, postName = "testN", postDate = "testDate", postAuthor = 1 };
            var mockDbSet = new Mock<IPostsRepository>();
            mockDbSet.Setup(z =>
                z.Find(
                    It.IsAny<Func<posts, bool>>(),
                    It.IsAny<int>(),
                    It.IsAny<int>()))
                  .Returns(
                    new List<posts>() { expectedPost }
                    );
            mockContext
                .Setup(context =>
                    context.postss)
                .Returns(mockDbSet.Object);

            IPostService postService = new PostService(mockContext.Object);

            return postService;
        }
    }
}
