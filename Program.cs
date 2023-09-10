﻿// See https://aka.ms/new-console-template for more information
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
string rutaF ="";
string rutaFC ="";
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
                Menu(cadeterias, rutaF,rutaFC, archivoC);
            }
            else
            {
                Console.WriteLine("Ingrese cadeteria");
            }
            break;
        case 2:
            rutaF = rutaJson;
            rutaFC = rutaJson1;
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
                Menu(cadeterias, rutaF,rutaFC, archivoJ);
            }
            else
            {
                Console.WriteLine("Ingrese cadeteria");
                Cadeteria cadeteria = new Cadeteria("Los panchos", 123456);
                archivoJ.CargarDatosCadeterias(cadeteria, rutaF);
            }
            break;
        default:
            break;
    }
} while (op != 1 && op != 2);

void Menu(Cadeteria cadeteria, string ruta, string rutaC, AccesoADatos archivo)
{
    int cont;
    do
    {
        Console.WriteLine("Bienvenido al sistema");
        Console.WriteLine("1- Dar alta pedido");
        Console.WriteLine("2- Asignar pedido a cadete");
        Console.WriteLine("3- Cambiar de estado");
        Console.WriteLine("4- Reasignar pedido");
        Console.WriteLine("5- Cargar datos en informe y salir.");
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
                if(cadeteria.Listaempleados.Count == 0)
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
                    archivo.CargarDatosCadetes(cadeteria, rutaC);
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
                    var rand= new Random();
                    int idC = rand.Next(1,cadeteria.Listaempleados.Count);
                    Console.Write("Ingrese el ID del pedido a asignar: ");
                    int idp = IngresarEntero();
                    if(cadeteria.AsignarCadeteAPedido(idC, idp))
                    {
                        Console.WriteLine("Pedido asignado");
                    }
                    else
                    {
                        Console.WriteLine("Pedido no asignado, revisar id del pedido.");
                    }
                }
                break;
            case 3:
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
                break;
            case 4:
                Console.WriteLine("Ingresar codigo del cadete al que desea asignarle el pedido:");
                var codigoCadete1 = IngresarEntero();
                Console.WriteLine("Ingresar codigo del pedido: ");
                var codigoPedido = IngresarEntero();
                if(cadeteria.ReasignarPedido(codigoCadete1,codigoPedido))
                {
                    Console.WriteLine("Pedido reasignado.");
                }
                else
                {
                    Console.WriteLine("El pedido no se pudo reasignar.");
                }
                break;
            default:
                    Console.WriteLine("Muchas gracias por elegirnos.");
                    string rutaIn = "Informe.Json";
                    archivo.CargarInforme(cadeteria.Listapedios, rutaIn);
                    List<Pedido> pedidosLeer = archivo.LeerInforme(rutaIn);
                    int contCantidad = 0; // Inicializar en 0
                    double montoTotal = 0.00;
                    var ruta2 = "Informe.csv";

                    foreach (var pedidoVer in pedidosLeer)
                    {
                        contCantidad++; // Incrementar el contador por cada pedido
                    }

                    montoTotal = 500.00 * contCantidad;
                    if(contCantidad != 0 && archivo.ExisteArchivo(ruta2))
                    {
                        foreach (var cadete in cadeteria.Listaempleados)
                        {
                            int pedidosEntregadosPorCadete = cadeteria.JornalACobrarCantidad(cadete.Id); // Obtener la cantidad de pedidos entregados por el cadete
                            double cantidadPedidos = Convert.ToDouble(pedidosEntregadosPorCadete);
                            Console.WriteLine($"ID: {cadete.Id}\nNombre: {cadete.Nombre}\nCantidad promedio de pedidos entregados: {cantidadPedidos/contCantidad}\nGanancia: {cantidadPedidos * 500.00}");
                            
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hoy no se vendieron productos.");
                    }
                    Console.WriteLine($"Total ganancias: {montoTotal}");
                    
                break;
        }
    } while (cont != 5);
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