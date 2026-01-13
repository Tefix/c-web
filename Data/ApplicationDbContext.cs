using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{
    public DbSet<WebApplication2.Models.Pyha> Pyha { get; set; } = default!;
    public DbSet<WebApplication2.Models.Kylaline> Kylalained { get; set; } = default!;
}