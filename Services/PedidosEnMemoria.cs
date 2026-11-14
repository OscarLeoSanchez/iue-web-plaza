public class PedidosEnMemoria : IPedidos
{

    private readonly List<Pedido> pedidos = new();
    public Pedido? Buscar(int id)
    {
        return pedidos.FirstOrDefault(p => p.Id == id);
    }

    public Pedido Guardar(NuevoPedido nuevo)
    {
        var pedido = new Pedido
        {
            Id = pedidos.Count + 1,
            Cliente = nuevo.Cliente,
            Producto = nuevo.Producto,
            Cantidad = nuevo.Cantidad,
        };
        pedidos.Add(pedido);
        return pedido;
    }
}