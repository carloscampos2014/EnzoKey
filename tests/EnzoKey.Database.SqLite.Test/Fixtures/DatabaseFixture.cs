using EnzoKey.Database.SqLite.Context;
using EnzoKey.Domain.Contracts.Contracts.Context;
using Microsoft.EntityFrameworkCore;

namespace EnzoKey.Database.SqLite.Test.Fixtures;
public class DatabaseFixture : IDisposable
{
    private IApplicationDbContext _context;

    public DatabaseFixture()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Garante banco isolado
            .Options;

        _context = new ApplicationDbContext(options);
    }

    public IApplicationDbContext Context => _context;

    public async Task AddAsync<T>(T entity) where T : class
    {
        ((DbContext)_context).Set<T>().Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAll<T>() where T : class
    {
        var dbSet = ((DbContext)_context).Set<T>();
        dbSet.RemoveRange(dbSet);
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context = null;
    }
}


[CollectionDefinition("Database")]
public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
{
    // Essa classe não contém código, serve apenas como ponto de definição.
}