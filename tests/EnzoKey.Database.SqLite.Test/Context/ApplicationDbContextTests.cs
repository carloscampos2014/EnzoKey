using EnzoKey.Database.SqLite.Context;
using EnzoKey.Database.SqLite.Test.Faker;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace EnzoKey.Database.SqLite.Test.Context;

public class ApplicationDbContextTests
{
    private ApplicationDbContext CreateInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Garante banco isolado
            .Options;

        return new ApplicationDbContext(options);
    }

    [Fact]
    public void DeveAdicionarERecuperarCliente()
    {
        // Arrange
        using var context = CreateInMemoryContext();
        var cliente = ClienteFaker.Faker();

        // Act
        context.Clientes.Add(cliente);
        context.SaveChanges();

        // Assert
        var clienteDoBanco = context.Clientes.Find(cliente.IdCliente);
        clienteDoBanco.Should().BeEquivalentTo(cliente);
    }

    [Fact]
    public void DeveAdicionarERecuperarProduto()
    {
        // Arrange
        using var context = CreateInMemoryContext();
        var produto = ProdutoFaker.Faker();

        // Act
        context.Produtos.Add(produto);
        context.SaveChanges();

        // Assert
        var produtoDoBanco = context.Produtos.Find(produto.IdProduto);
        produtoDoBanco.Should().BeEquivalentTo(produto);
    }

    [Fact]
    public void DeveAdicionarERecuperarLicenca()
    {
        // Arrange
        using var context = CreateInMemoryContext();
        var licenca = LicencaFaker.Faker();

        // Act
        context.Licencas.Add(licenca);
        context.SaveChanges();

        // Assert
        var licencaDoBanco = context.Licencas.Find(licenca.IdLicenca);
        licencaDoBanco.Should().BeEquivalentTo(licenca);
    }

    [Fact]
    public void DeveAdicionarERecuperarUsuarioAdmin()
    {
        // Arrange
        using var context = CreateInMemoryContext();
        var usuarioAdmin = UsuarioAdminFaker.Faker();

        // Act
        context.UsuariosAdmin.Add(usuarioAdmin);
        context.SaveChanges();

        // Assert
        var usuarioAdminDoBanco = context.UsuariosAdmin.Find(usuarioAdmin.IdUsuarioAdmin);
        usuarioAdminDoBanco.Should().BeEquivalentTo(usuarioAdmin);
    }
}
