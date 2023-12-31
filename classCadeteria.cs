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

    public Cadete CrearCadete(int id, string nombre, string direccion, int telefono)
    {
        Cadete cadete = new Cadete(id,nombre,direccion,telefono);
        return cadete;
    }
    public void AgregarCadete(Cadete cadete)
    {
        Listaempleados.Add(cadete);
    }
    public void EliminarCadete(string nombreEmpleado)
    {
        Listaempleados.RemoveAll(e => e.Nombre == nombreEmpleado );
    }
    public Pedido CrearPedido(int numeroPedido, string? observacion,string nombreCliente, string direccion, int telefono, string datosreferencia)
    {
        Pedido pedido = new Pedido(numeroPedido, observacion, nombreCliente, direccion, telefono, datosreferencia);
        return pedido;
    }
    public void AgregarPedidoCadete(Pedido pedido)
    {
        if(listaempleados.Count() != 0)
        {
            var rand= new Random();
            listaempleados[rand.Next(0,listaempleados.Count)].AgregarPedido(pedido);
        }
        else
        {
            Console.WriteLine("No hay cadetes.");
        }
    }
    public bool ReasignarPedido(int codigoCadete1, int codigoCadete2, int codigoPedido)
    {
        foreach (var cadete in listaempleados)
        {
            if(cadete.Id == codigoCadete1)
            {
                foreach (var pedido in cadete.Listapedido)
                {
                    if(pedido.NumeroPedido == codigoPedido)
                    {
                       foreach (var cadete2B in Listaempleados)
                       {
                            if(cadete2B.Id == codigoCadete2)
                            {
                                cadete2B.AgregarPedido(pedido);
                                break;
                            }
                       }
                       cadete.EliminarPedio(codigoPedido);
                       return true;
                    }
                }
            }
        }
        return false;
    }
    public bool CambiarEstado(int codigoCadete, int codigoPedido)
    {
        foreach (var cadete in Listaempleados)
        {
            if(cadete.Id == codigoCadete)
            {
                return cadete.CambiarEstado(codigoPedido);
            }
        }
        return false;
    }
}


