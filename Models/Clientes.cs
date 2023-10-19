using System.ComponentModel.DataAnnotations;

namespace ApiEmpresa.models;
public class Clientes {
    [Key]
    public Int32 idcliente { get; set; }
    public string? nombres { get; set; }
    public string? apellidos { get; set; }
    public string? direccion { get; set; }
    public string? telefono { get; set; }
    public DateTime? fecha_nacimiento { get; set; }
}