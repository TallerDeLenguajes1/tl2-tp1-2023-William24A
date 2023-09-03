using CadeteriaUtilizar;
using CadeteUtilizar;
using PedidoUtilizar;

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

    public void CargarInforme(Cadeteria cadeteria)
    {
        string ruta = "Informe.csv";
        try
        {
            using (StreamWriter writer = new StreamWriter(ruta))
            {
                var total = 0.00;
                foreach (var cadete in cadeteria.Listaempleados)
                {
                    writer.WriteLine($"{cadete.Id},{cadete.Nombre},{cadete.Telefono},{CantidadPedido(cadete)},{cadete.JornalACobrar()}");
                    total += cadete.JornalACobrar();    
                }     
                writer.WriteLine($"Total = {total}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al escribir datos: " + ex.Message);
        }
    }
    private int CantidadPedido(Cadete cadete)
    {
        int cont = 0;
        foreach (var pedido in cadete.Listapedido)
        {
            if(pedido.Estado)
            {
                cont++;
            }
        }
        return cont;
    }
}