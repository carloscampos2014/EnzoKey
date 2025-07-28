using EnzoKey.Domain.Contracts.Enum;

namespace EnzoKey.Database.SqLite.Test.Faker;

public static class LicencaFaker
{
    public static IEnumerable<Domain.Contracts.Model.DTO.Licenca> Faker(int quantidade)
    {
        var faker = new Bogus.Faker<Domain.Contracts.Model.DTO.Licenca>()
            .RuleFor(l => l.IdLicenca, f => Guid.NewGuid())
            .RuleFor(l => l.Cliente, f => ClienteFaker.Faker())
            .RuleFor(l => l.Produto, f => ProdutoFaker.Faker())
            .RuleFor(l => l.DataExpiracao, f => f.Date.Future(1))
            .RuleFor(l => l.DataEmissao, f => f.Date.Future(1))
            .RuleFor(l => l.Tipo, f => f.PickRandom<TipoLicenciamento>());
        
        return faker.Generate(quantidade);
    }

    public static Domain.Contracts.Model.DTO.Licenca Faker()
    {
        return Faker(1).FirstOrDefault()!;
    }
}
