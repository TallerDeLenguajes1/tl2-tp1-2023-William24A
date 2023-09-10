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

    public int NumeroPedido { get => numeroPedido; set => numeroPedido = value; }
    public string? Observacion { get => observacion; set => observacion = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public bool Estado { get => estado; set => estado = value; }
    public Cadete Cadete { get => cadete;}
    public Pedido()
    {
        cliente = new Cliente();
        cadete = new Cadete();
    }
    public Pedido(int numeroPedido, string? observacion)
    {
        this.NumeroPedido = numeroPedido;
        this.Observacion = observacion;
        this.cliente = new Cliente();
        this.estado = false;
        this.cadete = new Cadete();
    }
    public bool VerEstado()
    {
        return Estado;
    }
    public bool CambiarEstado()
    {
        this.Estado = true;
        return true;
    }

}