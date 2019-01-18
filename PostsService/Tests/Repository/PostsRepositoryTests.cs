using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MicroservicesQuickStart.PostsService.UnitTests.Repository
{
    using PostsService.Repository;
    using PostsService.Repository.Interfaces;
    using Models;

    public class PostsRepositoryTests
    {
        private readonly IPostsRepository _repository;

        public PostsRepositoryTests()
        {
            _repository = new PostsRepository(); // TODO Inject from Host app container
        }

        [Fact]
        public void All()
        {
            // Arrange
            var count = 2;
            for (int i = 1; i <= count; i++)
            {
                _repository.Insert(new Post { Id = i, Text = i.ToString() });
            }

            // Act
            var actual = _repository.All();

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(count, actual.Count());
            for (int i = 1; i <= count; i++)
            {
                Assert.Contains(actual, p => p.Id == i);
            }
        }

        [Fact]
        public void Get()
        {
            // Arrange
            var id = 3;
            _repository.Insert(new Post { Id = id, Text = id.ToString() });

            // Act
            var actual = _repository.Get(id);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(id, actual.Id);
        }

        [Fact]
        public void Insert()
        {
            // Arrange
            var id = 4;

            // Act
            _repository.Insert(new Post { Id = id, Text = id.ToString() });

            // Assert
            var actual = _repository.Get(id);
            Assert.NotNull(actual);
            Assert.Equal(id, actual.Id);
        }

        [Fact]
        public void Update()
        {
            // Arrange
            var id = 5;
            var post = new Post { Id = id, Text = id.ToString() };
            _repository.Insert(post);

            // Act
            post.Text = "OK";
            _repository.Update(post);

            // Assert
            var actual = _repository.Get(id);
            Assert.NotNull(actual);
            Assert.Equal(id, actual.Id);
            Assert.Equal("OK", actual.Text);
        }

        [Fact]
        public void Delete()
        {
            // Arrange
            var id = 6;
            _repository.Insert(new Post { Id = id, Text = id.ToString() });

            // Act
            _repository.Delete(id);

            var actual = _repository.Get(id);
            Assert.Null(actual);
        }
    }
}
