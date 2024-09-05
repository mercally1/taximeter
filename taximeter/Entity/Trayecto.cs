using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace taximeter.Entity;

public class Trayecto
{
    [Key]
    public int TrayectoId { get; set; }

    [Required, MaxLength(100)]
    public string? Ubicacion_Inicial { get; set; }

    [Required, MinLength(100)]
    public string? Ubicacion_Final { get; set; }

    [Required, MinLength(5)]
    public int Kilometraje { get; set; }

    [Required]
    public int TaxiId { get; set; }

    [Required]
    public string? Nombre { get; set; }

    [ForeignKey(nameof(Taxi))]
    public virtual Taxi? Taxi { get; set; }

    [ForeignKey(nameof(Nombre))]
    public virtual Conductor? Conductor { get; set; }
}
