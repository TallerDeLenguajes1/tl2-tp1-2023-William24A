namespace CadeteriaUtilizar;
using CadeteUtilizar;
using PedidoUtilizar;

class Cadeteria 
{
    private string nombre;
    private int telefono;
    private List<Cadete> listaempleados;
    public Cadeteria(string nombre, int telefono)
    {
        this.nombre = nombre;
        this.telefono= telefono;
        listaempleados = new List<Cadete>();
    }
    
}


