using CadeteriaUtilizar;
using CadeteUtilizar;
using PedidoUtilizar;

namespace ArchivosCSVUtilizar;
class Archivo
{
    public List<Cadeteria> LeerDatosCadeteria()
    {
        string ruta = "DatosCadeterias.csv";
        List<Cadeteria> cadeterias = new List<Cadeteria>();
        try
        {   
            using(StreamReader reader = new StreamReader(ruta))
            {
                while(!reader.EndOfStream)
                {
                    Cadeteria cadeteria = new Cadeteria();
                    string line = reader.ReadLine();
                    string[] dato = line.Split(',');

                    cadeteria.Nombre = dato[0];
                    cadeteria.Telefono = int.Parse(dato[1]);
                    cadeterias.Add(cadeteria);
                }
            }  
            return cadeterias;          
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al escribir datos: " + ex.Message);
            return cadeterias;
        }

    }
    public Cadeteria LeerDatosCadetes(Cadeteria cadeteria)
    {
        string ruta = "DatosCadetes.csv";
        try
        {   
            using(StreamReader reader = new StreamReader(ruta))
            {
                while(!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] dato = line.Split(',');
                    Cadete cadete = new Cadete();
                    cadete.Id = int.Parse(dato[0]);
                    cadete.Nombre = dato[1];
                    cadete.Direccion = dato[2];
                    cadete.Telefono = int.Parse(dato[3]);
                    cadeteria.AgregarCadete(cadete);
                }
            }  
            return cadeteria;          
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al escribir datos: " + ex.Message);
            return cadeteria;
        }

    }
    public void CargarDatosCadeterias(List<Cadeteria> cadeterias)
    {
        string ruta = "DatosCadeterias.csv";
        try
        {
            using (StreamWriter writer = new StreamWriter(ruta))
            {
                foreach (var item in cadeterias)
                {
                    writer.WriteLine($"{item.Nombre},{item.Telefono}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al escribir datos: " + ex.Message);
        }
    }

    public void CargarDatosCadetes(Cadeteria cadeteria)
    {
        string ruta = "DatosCadetes.csv";
        try
        {
            using (StreamWriter writer = new StreamWriter(ruta))
            {
                foreach (var item in cadeteria.Listaempleados)
                {
                    writer.WriteLine($"{item.Id},{item.Nombre},{item.Direccion},{item.Telefono}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al escribir datos: " + ex.Message);
        }
    }

    public bool ExisteArchivo(string ruta)
    {
        if (File.Exists(ruta))
        {
            if (!string.IsNullOrWhiteSpace(File.ReadAllText(ruta)))
            {
                Console.WriteLine("El archivo existe y contiene contenido.");
                return true;
            }
            else
            {
                Console.WriteLine("El archivo existe pero está vacío.");
                return false;
            }
        }
        else
        {
            Console.WriteLine("El archivo no existe.");
            return false;
        }
    }

    public List<Pedido> LeerInforme()
    {
        string ruta = "Informe.csv";
        List<Pedido> listaPedido= new List<Pedido>();
        try
        {   
            using(StreamReader reader = new StreamReader(ruta))
            {
                while(!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] dato = line.Split(',');
                    Pedido pedido = new Pedido();
                    pedido.NumeroPedido = int.Parse(dato[0]);
                    pedido.Observacion = dato[1];
                    pedido.Cliente.NombreCliente = dato[3];
                    pedido.Cliente.Direccion = dato[4];
                    pedido.Cliente.Telefono = int.Parse(dato[5]);
                    pedido.Cliente.Datosreferencia = dato[6];
                    pedido.Estado = bool.Parse(dato[7]);
                    listaPedido.Add(pedido);
                }
            }  
            return listaPedido;          
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al escribir datos: " + ex.Message);
            return listaPedido;
        }

    }
    public void CargarInforme(Pedido pedido)
    {
        string ruta = "Informe.csv";
        try
        {
            using (StreamWriter writer = new StreamWriter(ruta))
            {
                
                    writer.WriteLine($"{pedido.NumeroPedido},{pedido.Observacion},{pedido.Cliente.NombreCliente},{pedido.Cliente.Direccion},{pedido.Cliente.Telefono},{pedido.Cliente.Datosreferencia},{pedido.Estado}");   
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al escribir datos: " + ex.Message);
        }
    }
}