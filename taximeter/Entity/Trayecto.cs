using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace taximeter.Entity;

public class Trayecto
{
    [Key]
    public int TrayectoId { get; set; }

    [Required, MaxLength(100), Display(Name = "Ubicacion Inicial")]
    public string? Ubicacion_Inicial { get; set; }

    [Required, MinLength(100), Display(Name = "Ubicacion Final")]
    public string? Ubicacion_Final { get; set; }

    [Required, MinLength(5)]
    public int Kilometraje { get; set; }

    [Required]
    public int TaxiId { get; set; }

    [ForeignKey(nameof(TaxiId))]
    public virtual Taxi? Taxi { get; set; }
}
