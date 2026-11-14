public class CatalogoEf : ICatalogo
{
    private readonly PlazaDbContext db;

    public CatalogoEf(PlazaDbContext db)
    {
        this.db = db;
    }

    public List<Producto> Listar()
    {
        return db.Productos.OrderBy(p => p.Nombre).ToList();
    }

    public Producto? Buscar(int id)
    {
        return db.Productos.Find(id);
    }

    public bool Existe(string nombre)
    {
        return db.Productos.Any(p => p.Nombre == nombre);
    }
}