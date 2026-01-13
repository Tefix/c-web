using System.ComponentModel.DataAnnotations;
namespace WebApplication2.Models;

public class Pyha
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Nimetus on kohustlik")]
    public string Nimetus { get; set; }
    [DataType(DataType.Date)]
    public DateTime Kuupaev { get; set; }

}