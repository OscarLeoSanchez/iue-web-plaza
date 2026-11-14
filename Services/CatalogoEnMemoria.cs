
class CatalogoEnMemoria : ICatalogo
{

    private readonly List<Producto> productos = new()
    {
        new Producto { Id = 1, Nombre = "Tomate", Precio = 3500m },
        new Producto { Id = 2, Nombre = "Aguacate", Precio = 6000m },
        new Producto { Id = 3, Nombre = "Papa", Precio = 2800m },
        new Producto { Id = 4, Nombre = "Panela", Precio = 4500m },
    };
    public Producto? Buscar(int id)
    {
        return productos.FirstOrDefault(p => p.Id == id);
    }

    public bool Existe(string nombre)
    {
        return productos.Any(p => p.Nombre == nombre);
    }

    public List<Producto> Listar()
    {
        return productos;
    }
}