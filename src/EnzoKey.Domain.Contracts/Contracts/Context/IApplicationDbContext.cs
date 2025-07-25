using EnzoKey.Domain.Contracts.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace EnzoKey.Domain.Contracts.Contracts.Context;

public interface IApplicationDbContext
{
    /// <summary>
    /// Dbset para a entidade <see cref="Cliente"/>.
    /// </summary>
    DbSet<Cliente> Clientes { get; set; }

    /// <summary>
    /// Dbset para a entidade <see cref="Produto"/>.
    /// </summary>
    DbSet<Produto> Produtos { get; set; }

    /// <summary>
    /// Dbset para a entidade <see cref="Licenca"/>.
    /// </summary>
    DbSet<Licenca> Licencas { get; set; }

    /// <summary>
    /// Dbset para a entidade <see cref="UsuarioAdmin"/>.
    /// </summary>
    DbSet<UsuarioAdmin> UsuariosAdmin { get; set; }

    /// <summary>
    /// Método para salvar as alterações no contexto do banco de dados.
    /// </summary>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>Retorna uma <see cref="Task Int"/></returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
