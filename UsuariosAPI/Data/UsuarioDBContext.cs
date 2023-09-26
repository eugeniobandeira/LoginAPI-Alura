using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UsuariosAPI.Models;

namespace UsuariosAPI.Data
{
    public class UsuarioDBContext : IdentityDbContext<Usuario>
    {
        public UsuarioDBContext(DbContextOptions<UsuarioDBContext> opts) : base(opts) { }

    }
}
