namespace ClienteUtilizar;
public class Cliente
{
    private string nombreCliente;
    private string direccion;
    private int telefono;
    private string? datosreferencia;

    public string NombreCliente { get => nombreCliente; set => nombreCliente = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public string? Datosreferencia { get => datosreferencia; set => datosreferencia = value; }

    public Cliente()
    {

    }
    public Cliente(string nombreCliente, string direccion, int telefono, string datosreferencia)
    {
        this.NombreCliente = nombreCliente;
        this.Direccion = direccion;
        this.Telefono = telefono;
        this.Datosreferencia = datosreferencia;
    }
}