public interface ICatalogo
{
    List<Producto> Listar();

    Producto? Buscar(int id);

    bool Existe(string nombre);
}