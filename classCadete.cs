namespace CadeteUtilizar;
using PedidoUtilizar;
class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private int telefono;
    private List<Pedido> listapedido;

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    internal List<Pedido> Listapedido { get => listapedido; set => listapedido = value; }
    public Cadete()
    {
        Listapedido = new List<Pedido>();
    }

    public Cadete(int id, string nombre, string direccion, int telefono)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        Listapedido = new List<Pedido>();
    }

    public void JornalACobrar()
    {
        int cont = 0;
        double cobrar;
        foreach (var item in Listapedido)
        {
            if(item.VerEstado())
            {
                cont++;
            }
        }
        cobrar = 500*cont;
        Console.WriteLine($"Cobrará: ${cobrar}");
    }
    public void AgregarPedido(Pedido pedido)
    {
        Listapedido.Add(pedido);
    }
    public void EliminarPedio(int numeroPedido)
    {
        Listapedido.RemoveAll(p => p.NumeroPedido == numeroPedido);
    }
    public void CambiarEstado(Pedido pedido)
    {
        foreach (var item in Listapedido)
        {
            if(item.NumeroPedido == pedido.NumeroPedido)
            {
                item.Estado = true;
            }
        }
    }
}