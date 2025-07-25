using EnzoKey.Domain.Contracts.Contracts.Context;
using EnzoKey.Domain.Contracts.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace EnzoKey.Database.SqLite.Context;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    /// <summary>
    /// Dbset para a entidade <see cref="Cliente"/>.
    /// </summary>
    public DbSet<Cliente> Clientes { get; set; }

    /// <summary>
    /// Dbset para a entidade <see cref="Produto"/>.
    /// </summary>
    public DbSet<Produto> Produtos { get; set; }

    /// <summary>
    /// Dbset para a entidade <see cref="Licenca"/>.
    /// </summary>
    public DbSet<Licenca> Licencas { get; set; }

    /// <summary>
    /// Dbset para a entidade <see cref="UsuarioAdmin"/>.
    /// </summary>
    public DbSet<UsuarioAdmin> UsuariosAdmin { get; set; }
}
