namespace PedidoUtilizar;
using ClienteUtilizar;
class Pedido
{
    private int numeroPedido;
    private string? observacion;
    private Cliente cliente;
    private bool estado;

    public int NumeroPedido { get => numeroPedido; set => numeroPedido = value; }
    public string? Observacion { get => observacion; set => observacion = value; }
    internal Cliente Cliente { get => cliente; set => cliente = value; }
    public bool Estado { get => estado; set => estado = value; }

    public Pedido(int numeroPedido, string? observacion,string nombreCliente, string direccion, int telefono, string datosreferencia)
    {
        this.NumeroPedido = numeroPedido;
        this.Observacion = observacion;
        Cliente = new Cliente(nombreCliente,direccion,telefono,datosreferencia);
        Estado = false;
    }

    public void VerDireccionDelCliente()
    {
        Cliente.getDireccion();
    }
    public void DatosCliente()
    {
        Cliente.getDatos();
    }
    public bool VerEstado()
    {
        return Estado;
    }

}