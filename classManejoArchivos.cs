using CadeteriaUtilizar;
using CadeteUtilizar;
using PedidoUtilizar;
using ClienteUtilizar;
using System.Text;

namespace ArchivosCSVUtilizar;
class Archivo
{
    public Cadeteria LeerDatosCadeteria()
    {
        string ruta = "DatosCadeterias.csv";
        Cadeteria cadeteria = new Cadeteria();
        try
        {   
            using(StreamReader reader = new StreamReader(ruta))
            {
                while(!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] dato = line.Split(',');

                    cadeteria.Nombre = dato[0];
                    cadeteria.Telefono = int.Parse(dato[1]);
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
    public void CargarDatosCadeterias(Cadeteria cadeteria)
    {
        string ruta = "DatosCadeterias.csv";
        try
        {
            using (StreamWriter writer = new StreamWriter(ruta))
            {
                    writer.WriteLine($"{cadeteria.Nombre},{cadeteria.Telefono}");
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
    List<Pedido> listaPedido = new List<Pedido>();
    
    try
    {
        using (StreamReader reader = new StreamReader(ruta))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] dato = line.Split(',');
                
                if (dato.Length >= 7) // Asegura que hay suficientes campos en la línea
                {
                    Pedido pedido = new Pedido();
                    pedido.NumeroPedido = int.Parse(dato[0]);
                    pedido.Observacion = dato[1];
                    
                    // Crea una instancia de Cliente y asigna sus propiedades
                    pedido.Cliente = new Cliente();
                    {
                        pedido.Cliente.NombreCliente = dato[3];
                        pedido.Cliente.Direccion = dato[4];
                        pedido.Cliente.Telefono = int.Parse(dato[5]);
                        pedido.Cliente.Datosreferencia = dato[6];
                    };
                    
                    pedido.Estado = bool.Parse(dato[7]);
                    listaPedido.Add(pedido);
                }
            }
        }
        return listaPedido;
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error al leer datos: " + ex.Message);
        return listaPedido;
    }
}
    public void CargarInforme(Pedido pedido)
    {
        string ruta = "Informe.csv";
        try
        {
            using (FileStream fs = new FileStream(ruta, FileMode.Append, FileAccess.Write))
            {
                
                    var data = $"{pedido.NumeroPedido},{pedido.Observacion},{pedido.Cliente.NombreCliente},{pedido.Cliente.Direccion},{pedido.Cliente.Telefono},{pedido.Cliente.Datosreferencia},{pedido.Estado}\n";   
                    byte[] bytes = Encoding.UTF8.GetBytes(data);
                    fs.Write(bytes, 0, bytes.Length);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al escribir datos: " + ex.Message);
        }
    }
}