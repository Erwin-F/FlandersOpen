using System;
using System.Collections.Generic;
using System.Text;
using FlandersOpen.Domain.Entities;
using FlandersOpen.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FlandersOpen.Persistence.Test
{
    public class RefereeRepositoryFact
    {
        private ApplicationDbContext _context;
        private RefereeRepository _repository;

        public RefereeRepositoryFact()
        {
            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestCatalog")
                .Options;
            _context = new ApplicationDbContext(dbOptions);
            _repository = new RefereeRepository(_context);
        }

        [Fact]
        public void AddsAnItem()
        {
            //Arrange
            var referee = Referee.Build("test", new ShortName("T"));

            //Act
            _repository.Add(referee);

            //Assert
            Assert.NotNull(_repository.GetById(referee.Id));
        }

    }
}
