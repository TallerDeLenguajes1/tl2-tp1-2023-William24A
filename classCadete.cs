namespace CadeteUtilizar;
using PedidoUtilizar;
public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private int telefono;
    

    public int Id { get => id; }
    public string Nombre { get => nombre; }
    public string Direccion { get => direccion; }
    public int Telefono { get => telefono; }
   
    public Cadete()
    {
    }

    public Cadete(int id, string nombre, string direccion, int telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        
    }
     public void CambiarDatos(int id, string nombre, string direccion, int telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
    }


}