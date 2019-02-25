using FlandersOpen.Domain.Entities;
using FlandersOpen.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FlandersOpen.Persistence.Test
{
    public class CompetitionRepositoryFact
    {
        private ApplicationDbContext _context;
        private CompetitionRepository _repository;

        public CompetitionRepositoryFact()
        {
            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestCatalog")
                .Options;
            _context = new ApplicationDbContext(dbOptions);
            _repository = new CompetitionRepository(_context);
        }

        [Fact]
        public void AddsAnItem()
        {
            //Arrange
            var competition = Competition.Build("Test", new ShortName("T"), new ColorString("FFFFFF"));

            //Act
            _repository.Add(competition);

            //Assert
            Assert.NotNull(_repository.GetById(competition.Id));
        }
    }
}
