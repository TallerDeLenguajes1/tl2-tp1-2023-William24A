namespace ClienteUtilizar;
class Cliente
{
    private string nombreCliente;
    private string direccion;
    private int telefono;
    private string? datosreferencia;
    public Cliente(string nombreCliente, string direccion, int telefono, string datosreferencia)
    {
        this.nombreCliente = nombreCliente;
        this.direccion = direccion;
        this.telefono = telefono;
        this.datosreferencia = datosreferencia;
    }
    public void getDireccion()
    {
        Console.WriteLine($"Direccion: {direccion} \nReferencia: {datosreferencia}");
    }
    public void getDatos()
    {
        Console.WriteLine($"Nombre: {nombreCliente}\nTelefono: {telefono}");
    }
}