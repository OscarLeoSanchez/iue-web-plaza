using System.ComponentModel.DataAnnotations;

public class NuevoPedido
{
    [Required(ErrorMessage = "El nombre del cliente es obligatorio")]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 60 letras")]
    public string Cliente { get; set; } = string.Empty;

    public string Producto { get; set; } = string.Empty;

    [Required(ErrorMessage = "La cantidad es obligatoria")]
    [Range(1, 100, ErrorMessage = "La cantidad debe estar entre 1 y 100")]
    public int Cantidad { get; set; } = 1;
}