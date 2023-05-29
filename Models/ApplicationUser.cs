using Microsoft.AspNetCore.Identity;

namespace AutenticacaoUsuario.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    public string Name { get; set; } = string.Empty;
}