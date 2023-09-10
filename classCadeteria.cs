namespace CadeteriaUtilizar;
using CadeteUtilizar;
using PedidoUtilizar;

public class Cadeteria 
{
    private string nombre;
    private int telefono;
    private List<Cadete> listaempleados;
    private List<Pedido> listapedidos;

    public Cadeteria()
    {
        Listaempleados = new List<Cadete>();
        listapedidos = new List<Pedido>();
    }
    public Cadeteria(string nombre, int telefono)
    {
        this.Nombre = nombre;
        this.Telefono= telefono;
        Listaempleados = new List<Cadete>();
        listapedidos = new List<Pedido>();
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    internal List<Cadete> Listaempleados { get => listaempleados; set => listaempleados = value; }
    internal List<Pedido> Listapedios {get => listapedidos;}

    public bool CrearCadeteAgregar(int id, string nombre, string direccion, int telefono)
    {
        Cadete cadete = new Cadete(id,nombre,direccion,telefono);
        Listaempleados.Add(cadete);
        return true;
    }
    public void EliminarCadete(string nombreEmpleado)
    {
        Listaempleados.RemoveAll(e => e.Nombre == nombreEmpleado );
    }
    public bool CrearPedidoAgregar(int numeroPedido, string? observacion)
    {
        Pedido pedido = new Pedido(numeroPedido, observacion);
        Listapedios.Add(pedido);
        return true;
    }
    
    public bool ReasignarPedido(int codigoCadete1, int codigoPedido)
    {
        foreach (var pedido in Listapedios)
        {
            if(pedido.NumeroPedido == codigoPedido)
            {
                foreach (var cadete in Listaempleados)
                {
                    if(cadete.Id == codigoCadete1)
                    {
                        pedido.CambiarDatosCadete(cadete.Id, cadete.Nombre, cadete.Direccion, cadete.Telefono);
                        return true;
                    }
                }
            }
        }
        return false;
    }
    public bool CambiarEstado(int codigoPedido)
    {
        foreach (var pedido in Listapedios)
        {
            if(pedido.NumeroPedido == codigoPedido)
            {
                return pedido.CambiarEstado();
            }
        }
        return false;
    }
    public int JornalACobrarCantidad(int idcadete)
    {
        int cont = 0;
        foreach (var pedido in listapedidos)
        {
            if(pedido.Cadete.Id == idcadete)
            {
                cont++;
            }
        }
        return cont;
    }
    public bool AsignarCadeteAPedido(int idcadete, int idpedido)
    {
        foreach (var pedido in Listapedios)
        {
            if(pedido.NumeroPedido == idpedido)
            {
                foreach (var cadete in Listaempleados)
                {
                    if(cadete.Id == idcadete)
                    {
                        pedido.CambiarDatosCadete(cadete.Id, cadete.Nombre, cadete.Direccion, cadete.Telefono);
                        return true;
                    }
                }
            }
        }
        return false;
    }
    public Pedido BuscarPedido(int id)
    {
        foreach (var pedido in Listapedios)
        {
            if(pedido.NumeroPedido == id)
            {
                return pedido;
            }
        }
        return null;
    }
    public bool AsignarClienteAPedido(int idpedido,string nombreCliente, string direccion, int telefono, string datosreferencia)
    {
        foreach (var pedido in Listapedios)
        {
            if(pedido.NumeroPedido == idpedido)
            {
                pedido.CambiarDatosCliente(nombreCliente,direccion,telefono,datosreferencia);
                return true;
            }
        }
        return false;
    }
    public int EncontrarCadeteLibere()
    {
        foreach (var cadete in Listaempleados)
        {
            if(cadete.EstadoCadete == EstadoCadete.Libre)
            {
                return cadete.Id;
            }
        }
        return 0;
    }
}

