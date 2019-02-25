using FlandersOpen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FlandersOpen.Persistence.Test
{
    public class PitchRepositoryFact
    {
        private ApplicationDbContext _context;
        private PitchRepository _repository;

        public PitchRepositoryFact()
        {
            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestCatalog")
                .Options;
            _context = new ApplicationDbContext(dbOptions);
            _repository = new PitchRepository(_context);
        }

        [Fact]
        public void AddsAnItem()
        {
            //Arrange
            var pitch = Pitch.Build("Test", 1, 1);

            //Act
            _repository.Add(pitch);

            //Assert
            Assert.NotNull(_repository.GetById(pitch.Id));
        }
    }
}