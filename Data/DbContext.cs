using AutenticacaoUsuario.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutenticacaoUsuario.Data;

public class DbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public DbContext(DbContextOptions<DbContext> options) : base(options)
    {
    }
}