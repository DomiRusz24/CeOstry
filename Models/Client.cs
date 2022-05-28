using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clients.Models;

public class Client
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required, Key, Column(Order = 0)]
    public int Id { get; set; } = 0;


    [Required, StringLength(50)]
    public string? Name { get; set; }

    [Required, StringLength(50)]
    public string? Surname { get; set; }

    [Required, StringLength(11)]
    public string? Pesel { get; set; }

    [Required]
    public int BirthYear { get; set; }

    [Required]
    public int Gender { get; set; }

}