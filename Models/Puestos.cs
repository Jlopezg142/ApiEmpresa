using System.ComponentModel.DataAnnotations;

namespace ApiEmpresa.models;
public class Puestos {
    [Key]
    public Int16 idpuesto { get; set; }
    public string? puestos { get; set; }
    
    }