using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace taximeter.Entity;

public class Taxi
{
    [Key]
    public int TaxiId { get; set; }

    [Required]
    public int ConductorId { get; set; }

    [Required, MaxLength(10)]
    public string? Placa { get; set; }

    [Required, MaxLength(20)]
    public string? Marca { get; set; }

    [Required, MaxLength(20)]
    public string? Model { get; set; }

    [Required, MaxLength(4), Display(Name = "Año")]
    public string? Anho { get; set; }

    [ForeignKey("ConductorId")]
    public virtual Conductor? Conductor { get; set; }
}
