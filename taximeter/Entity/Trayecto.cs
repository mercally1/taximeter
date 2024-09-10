using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace taximeter.Entity;

public class Trayecto
{
    [Key]
    public int TrayectoId { get; set; }

    [Required, Display(Name = "Ubicacion Inicial")]
    public string? Ubicacion_Inicial { get; set; }

    [Required, Display(Name = "Ubicacion Final")]
    public string? Ubicacion_Final { get; set; }

    [Required, MinLength(5)]
    public string? Kilometraje { get; set; }

    [Required]
    public int TaxiId { get; set; }

    [ForeignKey("TaxiId")]
    public virtual Taxi? Taxi { get; set; }
}
