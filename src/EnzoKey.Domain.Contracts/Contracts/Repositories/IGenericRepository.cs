using System.Linq.Expressions;

namespace EnzoKey.Domain.Contracts.Contracts.Repositories;

/// <summary>
/// Interface genérica para operações básicas de repositório.
/// </summary>
public interface IGenericRepository<TEntity> where TEntity : class
{

    /// <summary>
    /// Adiciona uma nova entidade ao repositório.
    /// </summary>
    /// <param name="entity">Entidade a ser adicionada.</param>
    Task AddAsync(TEntity entity);

    /// <summary>
    /// Remove uma entidade pelo identificador único.
    /// </summary>
    /// <param name="id">Identificador único da entidade a ser removida.</param>
    Task DeleteAsync(Guid id);

    /// <summary>
    /// Busca entidades que atendem ao critério especificado.
    /// </summary>
    /// <param name="predicate">Expressão que define o critério de busca.</param>
    /// <returns>Lista de entidades que correspondem ao critério.</returns>
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

    /// <summary>
    /// Obtém uma entidade pelo identificador único.
    /// </summary>
    /// <param name="id">Identificador único da entidade.</param>
    /// <returns>Entidade encontrada ou nulo se não existir.</returns>
    Task<TEntity?> GetByIdAsync(Guid id);

    /// <summary>
    /// Obtém todas as entidades.
    /// </summary>
    /// <returns>Lista de todas as entidades.</returns>
    Task<IEnumerable<TEntity>> GetAllAsync();

    /// <summary>
    /// Atualiza uma entidade existente no repositório.
    /// </summary>
    /// <param name="entity">Entidade a ser atualizada.</param>
    Task UpdateAsync(TEntity entity);
}
