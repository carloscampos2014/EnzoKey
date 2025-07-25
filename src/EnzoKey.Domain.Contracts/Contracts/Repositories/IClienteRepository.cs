using EnzoKey.Domain.Contracts.Model.DTO;

namespace EnzoKey.Domain.Contracts.Contracts.Repositories;

public interface IClienteRepository
{
    /// <summary>
    /// Retorna uma entidade de <see cref="Cliente"/>.
    /// </summary>
    /// <param name="id">O Id do cliente</param>
    /// <returns>The client with the specified identifier.</returns>
    Task<Cliente?> GetByIdAsync(Guid id);
   
    /// <summary>
    /// Retorna uma lista de <see cref="Cliente"/>.
    /// </summary>
    /// <returns>Uma Lista de Clientes.</returns>
    Task<IEnumerable<Cliente>> GetAllAsync();

    /// <summary>
    /// Adicionar uma entidade de <see cref="Cliente"/>.
    /// </summary>
    /// <param name="cliente">Cliente a ser adicionado</param>
    Task AddAsync(Cliente cliente);

    /// <summary>
    /// Atualizar uma entidade de <see cref="Cliente"/>.
    /// </summary>
    /// <param name="cliente">Cliente a ser atualizado.</param>
    Task UpdateAsync(Cliente cliente);

    /// <summary>
    /// Excluir uma entidade de <see cref="Cliente"/>
    /// </summary>
    /// <param name="id">O Id do cliente.</param>
    Task DeleteAsync(Guid id);
}
