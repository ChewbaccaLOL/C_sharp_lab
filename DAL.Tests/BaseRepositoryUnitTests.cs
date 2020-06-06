using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.EF;
using DAL.Repository.Interfaces;
using DAL.Repository.Impl;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Moq;


namespace DAL.Tests
{
    class TestPostRepository
            : BaseRepository<posts>
    {
        public TestPostRepository(DbContext context)
            : base(context)
        {

        }
    }
    public class BaseRepositoryUnitTests
    {
        [Fact]

        public void Create_InputPostInstance_CalledAddMethodOfDBSetWithPostInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<PostContext>()
                .Options;
            var mockContext = new Mock<PostContext>(opt);
            var mockDbSet = new Mock<DbSet<posts>>();
            mockContext
               .Setup(context =>
                    context.Set<posts>(
                        ))
                .Returns(mockDbSet.Object);
            var repository = new TestPostRepository(mockContext.Object);
            posts expectedPost = new Mock<posts>().Object;
            //Act
            repository.Create(expectedPost);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedPost
                    ), Times.Once());
        }
    }
}
