using EnzoKey.Domain.Contracts.Contracts.Context;
using EnzoKey.Domain.Contracts.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EnzoKey.Database.SqLite.Repositories;

/// <summary>
/// Implementação abstrata genérica do padrão repositório para operações básicas de acesso a dados.
/// Utiliza Entity Framework Core para manipulação das entidades no contexto do banco de dados.
/// </summary>
public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected readonly IApplicationDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    /// <summary>
    /// Inicializa uma nova instância do repositório genérico.
    /// </summary>
    /// <param name="context">Contexto do banco de dados.</param>
    protected GenericRepository(IApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = ((DbContext)_context).Set<TEntity>();
    }

    /// <summary>
    /// Adiciona uma nova entidade ao conjunto de dados.
    /// </summary>
    /// <param name="entity">Entidade a ser adicionada.</param>
    public virtual async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Remove uma entidade do conjunto de dados pelo identificador único.
    /// </summary>
    /// <param name="id">Identificador único da entidade a ser removida.</param>
    public virtual async Task DeleteAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Busca entidades que atendem ao critério especificado.
    /// </summary>
    /// <param name="predicate">Expressão que define o critério de busca.</param>
    /// <returns>Lista de entidades que correspondem ao critério.</returns>
    public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet
            .Where(predicate)
            .ToListAsync();
    }

    /// <summary>
    /// Obtém todas as entidades do conjunto de dados.
    /// </summary>
    /// <returns>Lista de todas as entidades.</returns>
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    /// <summary>
    /// Obtém uma entidade pelo identificador único.
    /// </summary>
    /// <param name="id">Identificador único da entidade.</param>
    /// <returns>Entidade encontrada ou nulo se não existir.</returns>
    public virtual async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    /// <summary>
    /// Atualiza uma entidade existente no conjunto de dados.
    /// </summary>
    /// <param name="entity">Entidade a ser atualizada.</param>
    public virtual async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
}
