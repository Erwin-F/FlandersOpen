using FlandersOpen.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FlandersOpen.Persistence.Test
{
    public abstract class BaseRepositoryFact<T> where T : Entity
    {
        private ApplicationDbContext _context;
        private EfRepository<T> _repository;

        public BaseRepositoryFact()
        {
            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestCatalog")
                .Options;
            _context = new ApplicationDbContext(dbOptions);
            _repository = new EfRepository<T>(_context);
        }

        protected abstract T BuildItem();

        [Fact]
        public void AddsAnItem()
        {
            //Arrange
            var item = BuildItem();

            //Act
            _repository.Add(item);

            //Assert
            Assert.NotNull(_repository.GetById(item.Id));
        }
    }
}
