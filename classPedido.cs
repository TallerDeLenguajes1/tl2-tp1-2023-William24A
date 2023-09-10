namespace PedidoUtilizar;

using CadeteUtilizar;
using ClienteUtilizar;
public class Pedido
{
    private int numeroPedido;
    private string? observacion;
    private Cliente cliente;
    private bool estado;
    private Cadete cadete;

    public int NumeroPedido { get => numeroPedido; }
    public string? Observacion { get => observacion; }
    public Cliente Cliente { get => cliente; }
    public bool Estado { get => estado; }
    public Cadete Cadete { get => cadete;}
    public Pedido()
    {
        cliente = new Cliente();
        cadete = new Cadete();
    }
    public Pedido(int numeroPedido, string? observacion)
    {
        this.numeroPedido = numeroPedido;
        this.observacion = observacion;
        this.cliente = new Cliente();
        this.estado = false;
        this.cadete = new Cadete();
    }
    public bool VerEstado()
    {
        return Estado;
    }
    public bool CambiarEstado(bool estado)
    {
        this.estado = estado;
        return true;
    }
    public void CambiarDatosCadete(int id, string nombre, string direccion, int telefono)
    {
        this.cadete.CambiarDatos(id,nombre,direccion,telefono);
    }
    public void CambiarDatosCliente(string nombreCliente, string direccion, int telefono, string datosreferencia)
    {
        this.cliente.CambiarDatos(nombreCliente, direccion,telefono,datosreferencia);
    }

}