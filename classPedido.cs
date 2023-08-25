namespace PedidoUtilizar;
using ClienteUtilizar;
class Pedido
{
    private int numeroPedido;
    private string? observacion;
    private Cliente cliente;
    private bool estado;
    public Pedido(int numeroPedido, string? observacion,string nombreCliente, string direccion, int telefono, string datosreferencia)
    {
        this.numeroPedido = numeroPedido;
        this.observacion = observacion;
        cliente = new Cliente(nombreCliente,direccion,telefono,datosreferencia);
        estado = false;
    }

    public void VerDireccionDelCliente()
    {
        cliente.getDireccion();
    }
    public void DatosCliente()
    {
        cliente.getDatos();
    }
    public bool VerEstado()
    {
        return estado;
    }

}