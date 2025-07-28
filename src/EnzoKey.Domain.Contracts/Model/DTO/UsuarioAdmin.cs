using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnzoKey.Domain.Contracts.Model.DTO;

/// <summary>
/// Usuários do sistema interno de administração.
/// </summary>
[Table("UsuariosAdmin")]
public class UsuarioAdmin
{
    [Key]
    public Guid IdUsuarioAdmin { get; set; } = Guid.NewGuid(); // Gera um GUID único para cada usuário

    [Required]
    [StringLength(100)]
    public string Nome { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string SenhaHash { get; set; }
}
