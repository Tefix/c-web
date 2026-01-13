using System.ComponentModel.DataAnnotations;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;
namespace WebApplication2.Models;

public class IdentityModels : DbContext
{
    public IdentityModels(DbContextOptions<IdentityModels> options) : base(options)
    {
    }
    
    public DbSet<Kylaline> Kylalained { get; set; }
    public DbSet<Pyha> pyha { get; set; }
}