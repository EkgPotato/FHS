using DataService.Data;
using FHS.Domain.Interfaces.Dto.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Xunit;

namespace FHS.Tests.TestHelpers
{
    public class DatabaseFixture<TEntity> : IDisposable
        where TEntity : class, IBaseEntity, new()
    {
        public AppDbContext DbContext { get; private set; }

        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .EnableSensitiveDataLogging(true)
                .Options;

            DbContext = new AppDbContext(options);

            // Add seed data if needed
            DbContext.AddRange(new List<TEntity>
            {
            new TEntity { Id = 1 },
            new TEntity { Id = 2 },
            new TEntity { Id = 3 },
            });
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
