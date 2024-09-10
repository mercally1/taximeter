using System.ComponentModel.DataAnnotations;

namespace taximeter.Entity;

public class Conductor
{
    [Key]
    public int ConductorId { get; set; }

    [Required, MaxLength(50)]
    public string? Nombre { get; set; }

    [Required, MaxLength(50)]
    public string? Apellido { get; set; }

    [Required, MaxLength(20)]
    public string? Licencia { get; set; }

    [Required, MaxLength(20)]
    public string? Contacto { get; set; }
}
