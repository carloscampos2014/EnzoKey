using EnzoKey.Domain.Contracts.Model.DTO;
using Bogus.Extensions.Brazil;
using EnzoKey.Domain.Contracts.Enum;

namespace EnzoKey.Database.SqLite.Test.Faker;

public static class ClienteFaker
{
    public static IEnumerable<Cliente> Faker(int quantidade)
    {
        var faker = new Bogus.Faker<Cliente>()
            .RuleFor(c => c.IdCliente, f => Guid.NewGuid())
            .RuleFor(c => c.NomeEmpresa, f => f.Name.FullName())
            .RuleFor(c => c.EmailContato, f => f.Internet.Email())
            .RuleFor(c => c.DataCadastro, f => f.Date.Past(1))
            .RuleFor(c => c.Personalidade, f => f.PickRandom<TipoPersonalidade>())
            .RuleFor(c => c.Documento, f => f.Company.Cnpj());

        return faker.Generate(quantidade);
    }

    public static Cliente Faker()
    {
        return Faker(1).FirstOrDefault()!;
    }
}