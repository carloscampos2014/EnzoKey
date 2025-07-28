using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnzoKey.Domain.Contracts.Model.DTO;

/// <summary>
/// Representa os produtos ou softwares que serão licenciados.
/// </summary>
[Table("Produtos")]
public class Produto
{
    [Key]
    public Guid IdProduto { get; set; } = Guid.NewGuid(); // Gera um GUID único para cada produto

    [Required]
    [StringLength(100)]
    public string Nome { get; set; }

    [StringLength(500)]
    public string Descricao { get; set; }

    [StringLength(20)]
    public string Versao { get; set; }

    // Propriedade de navegação: um produto pode estar em várias licenças
    public virtual ICollection<Licenca> Licencas { get; set; } = new HashSet<Licenca>();
}
