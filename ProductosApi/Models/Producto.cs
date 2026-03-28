using System.Text.Json.Serialization;

namespace ProductosApi.Models;

public class Producto
{
    public int Id { get; set; }

    [JsonPropertyName("nombre")]
    public string Nombre { get; set; } = "";

    public decimal Precio { get; set; }
    public int Stock { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Descripcion { get; set; }

    public string Categoria { get; set; } = "";
}

public class ProductoDto
{
    public string Nombre { get; set; } = "";
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public string Categoria { get; set; } = "";
}