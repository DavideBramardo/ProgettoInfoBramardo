using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppAzienda.Models;

namespace WebAppAzienda.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebAppAzienda.Models.Ordine> Ordine { get; set; } = default!;
        public DbSet<WebAppAzienda.Models.Prodotto> Prodotto { get; set; } = default!;
        public DbSet<WebAppAzienda.Models.Spedizione> Spedizione { get; set; } = default!;
        public DbSet<WebAppAzienda.Models.Utente> Utente { get; set; } = default!;
    }
}