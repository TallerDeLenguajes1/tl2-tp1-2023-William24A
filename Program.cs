// See https://aka.ms/new-console-template for more information
using CadeteriaUtilizar;
using ArchivosUtilizar;
using PedidoUtilizar;
using CadeteUtilizar;

AccesoADatos archivoC = new AccesoCSV();
AccesoADatos archivoJ = new AccesoJSON();

string ruta = "DatosCadeterias.csv";
string ruta1 = "DatosCadetes.csv";
string rutaJson = "DatosCadeterias.Json";
string rutaJson1 = "DatosCadetes.Json";
string rutaIC ="Informe.csv";
string rutaiJ ="Informe.Json";
string rutaF ="";
string rutaFC ="";
string rutaI ="";
var cadeterias = new Cadeteria();
var op = 0;
do
{
    Console.WriteLine("Que tipo de archivo desea utilizar:");
    Console.WriteLine("1-CSV");
    Console.WriteLine("2-Json");
    Console.Write("Opcion: ");
    op = IngresarEntero();
    switch (op)
    {
        case 1:
            rutaF = ruta;
            rutaFC = ruta1;
            rutaI = rutaIC;
            if(archivoC.ExisteArchivo(rutaF))
            {
                Console.WriteLine("Existe");
                cadeterias = archivoC.LeerDatosCadeteria(rutaF);
                if(archivoC.ExisteArchivo(rutaFC))
                {
                    Console.WriteLine("Existe");
                    cadeterias = archivoC.LeerDatosCadetes(cadeterias,rutaFC);
                }
                else
                {
                    Console.WriteLine("No hay cadetes trabajando debe agregar");
                }
                Menu(cadeterias, rutaF,rutaFC, rutaI, archivoC);
            }
            else
            {
                Console.Write("Ingrese nombre de cadeteria: ");
                string nombre = Console.ReadLine();
                Console.Write("Ingrese telefono de cadeteria: ");
                int telefono = IngresarEntero();
                cadeterias = new Cadeteria(nombre, telefono);
                archivoC.CargarDatosCadeterias(cadeterias, rutaF);
                Menu(cadeterias, rutaF,rutaFC, rutaI, archivoC);
            }
            break;
        case 2:
            rutaF = rutaJson;
            rutaFC = rutaJson1;
            rutaI = rutaiJ;
            if(archivoJ.ExisteArchivo(rutaF))
            {
                Console.WriteLine("Existe");
                cadeterias = archivoJ.LeerDatosCadeteria(rutaF);
                if(archivoC.ExisteArchivo(rutaFC))
                {
                    Console.WriteLine("Existe");
                    cadeterias = archivoJ.LeerDatosCadetes(cadeterias,rutaFC);
                }
                else
                {
                    Console.WriteLine("No hay cadetes trabajando debe agregar");
                }
                Menu(cadeterias, rutaF,rutaFC, rutaI, archivoJ);
            }
            else
            {
                Console.Write("Ingrese nombre de cadeteria: ");
                string nombre = Console.ReadLine();
                Console.Write("Ingrese telefono de cadeteria: ");
                int telefono = IngresarEntero();
                cadeterias = new Cadeteria(nombre, telefono);
                archivoJ.CargarDatosCadeterias(cadeterias, rutaF);
                Menu(cadeterias, rutaF,rutaFC, rutaI, archivoJ);
            }
            break;
        default:
            break;
    }
} while (op != 1 && op != 2);

void Menu(Cadeteria cadeteria, string ruta, string rutaC, string rutaI, AccesoADatos archivo)
{
    int cont;
    do
    {
        Console.WriteLine("Bienvenido al sistema");
        Console.WriteLine("1- Dar alta pedido");
        Console.WriteLine("2- Asignar pedido a cadete");
        Console.WriteLine("3- Ingresar cadete");
        Console.WriteLine("4- Cambiar de estado de pedido");
        Console.WriteLine("5- Reasignar pedido");
        Console.WriteLine("6- Cancelar pedido");
        Console.WriteLine("7- Eliminar cadete");
        Console.WriteLine("8- Ver pedidos.");
        Console.WriteLine("9- Ver cadetes.");
        Console.WriteLine("10- Cargar datos en informe y salir.");
        Console.Write("Ingrese opcion:");
        cont = IngresarEntero();
        switch (cont)
        {
            case 1:
                Console.Write("Ingrese el numero de pedido: ");
                int numeroPedido = IngresarEntero();
                Console.Write("Ingrese la observacion sobre el pedido: ");
                string observacion = Console.ReadLine();
                Console.Write("Ingrese el nombre del cliente: ");
                string nombreCliente = Console.ReadLine(); 
                Console.Write("Ingrese la direccion del cliente: ");
                string direccion = Console.ReadLine(); 
                Console.Write("Ingrese el numero de telefono del cliente: ");
                int telefono = IngresarEntero();
                Console.Write("Ingrese datos que referencien la casa del cliente: ");
                string datosreferencia = Console.ReadLine();

                cadeteria.CrearPedidoAgregar(numeroPedido,observacion);
                cadeteria.AsignarClienteAPedido(numeroPedido,nombreCliente,direccion,telefono,datosreferencia);
                Console.WriteLine("Pedido fue creado.");
                break;
            case 2:
                if(cadeteria.ExistePedido())
                {
                    if(!cadeteria.ExisteCadete())
                    {
                        Console.WriteLine("No existen cadetes.");
                        Console.WriteLine("Ingresar datos del cadete");
                        Console.Write("ID: ");
                        var id = IngresarEntero();
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Direccion: ");
                        string direccionC = Console.ReadLine();
                        Console.Write("Telefono: ");
                        int telefonoC = IngresarEntero();

                        cadeteria.CrearCadeteAgregar(id,nombre,direccionC,telefonoC);
                        Console.Write("Ingrese el ID del pedido a asignar: ");
                        int idp = IngresarEntero();
                        if(cadeteria.AsignarCadeteAPedido(id, idp))
                        {
                            Console.WriteLine("Pedido asignado");
                        }
                        else
                        {
                            Console.WriteLine("Pedido no asignado, revisar id del pedido.");
                        }
                    }
                    else
                    {
                        Console.Write("Ingrese el ID del pedido a asignar: ");
                        int idp = IngresarEntero();
                        if(cadeteria.AsignarCadeteAPedido(cadeteria.EncontrarCadeteLibere(), idp))
                        {
                            Console.WriteLine("Pedido asignado");
                        }
                        else
                        {
                            Console.WriteLine("Pedido no asignado, revisar id del pedido.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No existen pedidos. Ingrese alguno.");
                }
                break;
            case 3:
                    Console.WriteLine("Ingresar datos del cadete");
                    Console.Write("ID: ");
                    var idC = IngresarEntero();
                    Console.Write("Nombre: ");
                    string nombreC = Console.ReadLine();
                    Console.Write("Direccion: ");
                    string direccionCa = Console.ReadLine();
                    Console.Write("Telefono: ");
                    int telefonoCa = IngresarEntero();

                    cadeteria.CrearCadeteAgregar(idC,nombreC,direccionCa,telefonoCa);
                    Console.WriteLine("Datos cargados.");
                break;
            case 4:
                if(cadeteria.ExistePedido())
                {
                    Console.WriteLine("Ingrese el numero del pedido:");
                    int numero = IngresarEntero();
                    if(cadeteria.CambiarEstado(numero))
                    {
                        Console.WriteLine("Cambios realizados.");
                    }
                    else
                    {
                        Console.WriteLine("No se realizo cambios.");
                    }
                }
                else 
                {
                    Console.WriteLine("No existen pedidos. Ingrese alguno.");
                }   
                break;
            case 5:
                if(cadeteria.ExisteCadete() && cadeteria.ExistePedido())
                {
                    Console.WriteLine("Ingresar codigo del cadete al que desea asignarle el pedido:");
                    var codigoCadete1 = IngresarEntero();
                    Console.WriteLine("Ingresar codigo del pedido: ");
                    var codigoPedido = IngresarEntero();
                    if(cadeteria.AsignarCadeteAPedido(codigoCadete1,codigoPedido))
                    {
                        Console.WriteLine("Pedido reasignado.");
                    }
                    else
                    {
                        Console.WriteLine("El pedido no se pudo reasignar.");
                    }
                }
                else
                {
                    Console.WriteLine("No existe o pedido o cadetes. Ingrese alguno");
                }
                break;
            case 6:
                if(cadeteria.ExistePedido())
                {
                    Console.WriteLine("Ingrese codigo de pedido: ");
                    if(cadeteria.CancelarPedido(IngresarEntero()))
                    {
                        Console.WriteLine("Pedido cancelado.");
                    }
                    else
                    {
                        Console.WriteLine("El pedido no existe.");
                    }
                }
                else
                {
                    Console.WriteLine("No existe pedido cargado. Cargue pedido.");
                }
                break;
            case 7:
                if(cadeteria.ExisteCadete())
                {
                    Console.WriteLine("Ingrese el id del cadete: ");
                    cadeteria.EliminarCadete(IngresarEntero());
                }
                else
                {
                    Console.WriteLine("No existen cadetes ingresados. Debe ingresar cadetes.");
                }
                break;
            case 8:
                if(cadeteria.ExistePedido())
                {
                    Console.WriteLine(cadeteria.InformePedidos());
                }
                else
                {
                    Console.WriteLine("No existe pedido cargado. Cargue pedido.");
                }
                break;
            case 9:
                if(cadeteria.ExisteCadete())
                {
                    Console.WriteLine(cadeteria.InformeCadetes());
                }
                else
                {
                    Console.WriteLine("No existen cadetes ingresados. Debe ingresar cadetes.");
                }
                break;
            default:
                    archivo.CargarDatosCadetes(cadeteria, rutaC);
                    Console.WriteLine("Muchas gracias por elegirnos.");
                    archivo.CargarInforme(cadeteria.RetornarListaEntregados(), rutaI); //corregir, recibe toda la lista de pedidos cuando deberia selecionar los que tiene true en sus estados
                    List<Pedido> pedidosLeer = archivo.LeerInforme(rutaI);
                    double montoTotal;
                    
                    montoTotal = 500.00 * pedidosLeer.Count;

                    if(montoTotal != 0 && archivo.ExisteArchivo(rutaI))
                    {
                        foreach (var cadete in cadeteria.Listaempleados)
                        {
                            int pedidosEntregadosPorCadete = cadeteria.JornalACobrarCantidad(cadete.Id); // Obtener la cantidad de pedidos entregados por el cadete
                            double cantidadPedidos = Convert.ToDouble(pedidosEntregadosPorCadete);
                            Console.WriteLine($"ID: {cadete.Id}\nNombre: {cadete.Nombre}\nCantidad promedio de pedidos entregados: {cantidadPedidos/pedidosLeer.Count}\nGanancia: {cantidadPedidos * 500.00}");
                            
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hoy no se vendieron productos.");
                    }
                    Console.WriteLine($"Total ganancias: {montoTotal}");
                    
                break;
        }
    } while (cont != 10);
}

int IngresarEntero()
{   
    int num;
    if(int.TryParse(Console.ReadLine(), out num)){
        return num;
    }else{
        return -1111;
    }
}