using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductosApi.Models;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ProductosController : ControllerBase
{
    private readonly AppDbContext _db;

    public ProductosController(AppDbContext db) => _db = db;

    /// <summary>Obtiene la lista completa de productos.</summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Producto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Producto>>> GetAll()
        => Ok(await _db.Productos.ToListAsync());

    /// <summary>Obtiene un producto por su ID.</summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Producto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Producto>> GetById(int id)
    {
        var p = await _db.Productos.FindAsync(id);
        return p == null ? NotFound() : Ok(p);
    }

    /// <summary>Crea un nuevo producto.</summary>
    [HttpPost]
    [ProducesResponseType(typeof(Producto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Producto>> Create(ProductoDto dto)
    {
        var producto = new Producto
        {
            Nombre    = dto.Nombre,
            Precio    = dto.Precio,
            Stock     = dto.Stock,
            Categoria = dto.Categoria
        };
        _db.Productos.Add(producto);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
    }

    /// <summary>Actualiza un producto existente.</summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, ProductoDto dto)
    {
        var p = await _db.Productos.FindAsync(id);
        if (p == null) return NotFound();

        p.Nombre    = dto.Nombre;
        p.Precio    = dto.Precio;
        p.Stock     = dto.Stock;
        p.Categoria = dto.Categoria;

        await _db.SaveChangesAsync();
        return NoContent();
    }

    /// <summary>Elimina un producto por su ID.</summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var p = await _db.Productos.FindAsync(id);
        if (p == null) return NotFound();

        _db.Productos.Remove(p);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}