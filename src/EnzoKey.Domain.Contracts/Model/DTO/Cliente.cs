using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnzoKey.Domain.Contracts.Model.DTO;

/// <summary>
/// Representa os clientes que adquirem as licenças de software.
/// </summary>
[Table("Clientes")]
public class Cliente
{
    [Key]
    public int IdCliente { get; set; }

    [Required]
    [StringLength(150)]
    public string NomeEmpresa { get; set; }

    [StringLength(18)] // Suficiente para CNPJ
    public string Documento { get; set; } // Pode ser CPF ou CNPJ

    [Required]
    [StringLength(100)]
    [EmailAddress]
    public string EmailContato { get; set; }

    public DateTime DataCadastro { get; set; }

    // Propriedade de navegação: um cliente pode ter várias licenças
    public virtual ICollection<Licenca> Licencas { get; set; } = new HashSet<Licenca>();
}
