

using Microsoft.AspNetCore.Mvc;

public class CatalogoController : Controller
{
    private readonly ICatalogo catalogo;
    private readonly IPedidos pedidos;

    public CatalogoController(ICatalogo catalogo, IPedidos pedidos)
    {
        this.catalogo = catalogo;
        this.pedidos = pedidos;
    }

    [HttpGet("catalogo")]
    public IActionResult Listar()
    {
        return View(catalogo.Listar());
    }

    [HttpGet("catalogo/{id:int:min(1)}")]
    public IActionResult Buscar(int id)
    {
        var producto = catalogo.Buscar(id);
        if (producto is null)
        {
            return NotFound();
        }
        return View(producto);
    }

    [HttpGet("catalogo/{id:int:min(1)}/pedir")]
    public IActionResult Pedir(int id)
    {
        var producto = catalogo.Buscar(id);
        if (producto is null)
        {
            return NotFound();
        }
        return View(new NuevoPedido { Producto = producto.Nombre });
    }

    [HttpPost("catalogo/pedir")]
    [ValidateAntiForgeryToken]
    public IActionResult Confirmar(NuevoPedido nuevo)
    {
        if (!catalogo.Existe(nuevo.Producto))
        {
            ModelState.AddModelError(string.Empty, $"No vendemos {nuevo.Producto}");
        }
        if (!ModelState.IsValid)
        {
            return View("Pedir", nuevo);
        }

        var pedido = pedidos.Guardar(nuevo);
        return RedirectToAction(nameof(Gracias), new { id = pedido.Id });
    }

    [HttpGet("catalogo/gracias/{id:int:min(1)}")]
    public IActionResult Gracias(int id)
    {
        var pedido = pedidos.Buscar(id);
        if (pedido is null)
        {
            return NotFound();
        }
        return View(pedido);
    }
}