using EnzoKey.Domain.Contracts.Model.DTO;

namespace EnzoKey.Database.SqLite.Test.Faker;

public static class UsuarioAdminFaker
{
    public static IEnumerable<UsuarioAdmin> Faker(int quantidade)
    {
        var faker = new Bogus.Faker<UsuarioAdmin>()
            .RuleFor(u => u.IdUsuarioAdmin, f => Guid.NewGuid())
            .RuleFor(u => u.Nome, f => f.Name.FullName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.SenhaHash, f => f.Internet.Password());

        return faker.Generate(quantidade);
    }

    public static UsuarioAdmin Faker()
    {
        return Faker(1).FirstOrDefault()!;
    }
}
