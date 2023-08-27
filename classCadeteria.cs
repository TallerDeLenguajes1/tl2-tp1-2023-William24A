namespace CadeteriaUtilizar;
using CadeteUtilizar;
using PedidoUtilizar;

class Cadeteria 
{
    private string nombre;
    private int telefono;
    private List<Cadete> listaempleados;

    public Cadeteria()
    {
        Listaempleados = new List<Cadete>();
    }
    public Cadeteria(string nombre, int telefono)
    {
        this.Nombre = nombre;
        this.Telefono= telefono;
        Listaempleados = new List<Cadete>();
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    internal List<Cadete> Listaempleados { get => listaempleados; set => listaempleados = value; }
    public void AgregarCadete(Cadete cadete)
    {
        Listaempleados.Add(cadete);
    }
    public void EliminarCadete(string nombreEmpleado)
    {
        Listaempleados.RemoveAll(e => e.Nombre == nombreEmpleado );
    }
    public void ReasignarPedido(Cadete cadete1, Cadete cadete2, Pedido pedido)
    {
        cadete2.AgregarPedido(pedido);
        cadete1.EliminarPedio(pedido.NumeroPedido);
    }
}


