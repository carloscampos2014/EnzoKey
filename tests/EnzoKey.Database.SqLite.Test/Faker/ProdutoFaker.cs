using EnzoKey.Domain.Contracts.Model.DTO;

namespace EnzoKey.Database.SqLite.Test.Faker;

public static class ProdutoFaker
{
    public static IEnumerable<Produto> Faker(int quantidade)
    {
        var faker = new Bogus.Faker<Produto>()
            .RuleFor(p => p.IdProduto, f => Guid.NewGuid())
            .RuleFor(p => p.Nome, f => f.Commerce.ProductName())
            .RuleFor(p => p.Descricao, f => f.Lorem.Sentence(10))
            .RuleFor(p => p.Versao, f => f.System.Semver());
        
        return faker.Generate(quantidade);
    }

    public static Produto Faker()
    {
        return Faker(1).FirstOrDefault()!;
    }
}
