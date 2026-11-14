public interface IPedidos
{
    Pedido Guardar(NuevoPedido nuevo);

    Pedido? Buscar(int id);
}