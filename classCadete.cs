namespace CadeteUtilizar;
using PedidoUtilizar;
class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private int telefono;
    private List<Pedido> listapedido;
    public Cadete(int id, string nombre, string direccion, int telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        listapedido = new List<Pedido>();
    }

    public void JornalACobrar()
    {
        int cont = 0;
        double cobrar;
        foreach (var item in listapedido)
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
        listapedido.Add(pedido);
    }
}