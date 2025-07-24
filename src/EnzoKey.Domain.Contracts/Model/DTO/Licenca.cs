using EnzoKey.Domain.Contracts.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnzoKey.Domain.Contracts.Model.DTO;

/// <summary>
/// Entidade central que representa a licença de um produto para um cliente.
/// </summary>
[Table("Licencas")]
public class Licenca
{
    [Key]
    public int IdLicenca { get; set; }

    [Required]
    public Guid ChaveLicenca { get; set; } // A chave única que será validada

    [Required]
    public int IdCliente { get; set; } // FK

    [Required]
    public int IdProduto { get; set; } // FK

    [Required]
    public TipoLicenciamento Tipo { get; set; }

    public DateTime DataEmissao { get; set; }

    public DateTime? DataExpiracao { get; set; } // Nulo para licenças permanentes

    public int? MaximoUsuarios { get; set; } // Nulo se não for por usuário

    public int? MaximoInstalacoes { get; set; } // Nulo se não for por instalação

    public bool Ativa { get; set; }

    // Propriedades de navegação para o Entity Framework
    [ForeignKey("IdCliente")]
    public virtual Cliente Cliente { get; set; }

    [ForeignKey("IdProduto")]
    public virtual Produto Produto { get; set; }
}
