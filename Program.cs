// See https://aka.ms/new-console-template for more information
using System;
using CadeteriaUtilizar;
using ArchivosCSVUtilizar;
using CadeteUtilizar;
using System.ComponentModel.Design;
using PedidoUtilizar;

var archivo = new Archivo();
string ruta = "DatosCadeterias.csv";
string ruta1 = "DatosCadetes.csv";
var cadeterias = new Cadeteria();

if(archivo.ExisteArchivo(ruta))
{
   Console.WriteLine("Existe");
   cadeterias = archivo.LeerDatosCadeteria();
   if(archivo.ExisteArchivo(ruta1))
   {
    Console.WriteLine("Existe");
    cadeterias = archivo.LeerDatosCadetes(cadeterias);
   }
   else
   {
    Console.WriteLine("No hay cadetes trabajando debe agregar");
   }
   Menu(cadeterias);
}
else
{
    Console.WriteLine("Ingrese datos de cadeteria.");
}

void Menu(Cadeteria cadeteria)
{
    int cont;
    var archivo = new Archivo();
    do
    {
        Console.WriteLine("Bienvenido al sistema");
        Console.WriteLine("1- Dar alta pedido");
        Console.WriteLine("Y asignar pedido a cadete");
        Console.WriteLine("2- Cambiar de estado");
        Console.WriteLine("3- Reasignar pedido");
        Console.WriteLine("4- Cargar datos en informe y salir.");
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

                var pedido = cadeteria.CrearPedido(numeroPedido,observacion,nombreCliente,direccion,telefono,datosreferencia);
                Console.WriteLine("Pedido fue creado. Asignar pedido a un cadete.");
                cadeteria.AgregarPedidoCadete(pedido);
                Console.WriteLine("Pedido a sido asignado");
                break;
            case 2:
                Console.WriteLine("Ingrese codigo del cadete:");
                int numeroCadete = IngresarEntero();
                Console.WriteLine("Ingrese el numero del pedido:");
                int numero = IngresarEntero();
                if(cadeteria.CambiarEstado(numeroCadete,numero))
                {
                    Console.WriteLine("Cambios realizados.");
                }
                else
                {
                    Console.WriteLine("No se realizo cambios.");
                }
                break;
            case 3:
                Console.WriteLine("Ingresar codigo del cadete 1:");
                var codigoCadete1 = IngresarEntero();
                Console.WriteLine("Ingresar codigo del cadete 2");
                var codigoCadete2 = IngresarEntero();
                Console.WriteLine("Ingresar codigo del pedido: ");
                var codigoPedido = IngresarEntero();
                if(cadeteria.ReasignarPedido(codigoCadete1, codigoCadete2, codigoPedido))
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
                    List<Pedido> pedidosLeer = archivo.LeerInforme();
                    int contCantidad = 0; // Inicializar en 0
                    double montoTotal = 0.00;

                    foreach (var pedidoVer in pedidosLeer)
                    {
                        contCantidad++; // Incrementar el contador por cada pedido
                    }

                    montoTotal = 500.00 * contCantidad;

                    foreach (var cadete in cadeteria.Listaempleados)
                    {
                        int pedidosEntregadosPorCadete = cadete.JornalACobrarCantidad(); // Obtener la cantidad de pedidos entregados por el cadete
                        Console.WriteLine($"ID: {cadete.Id}\nNombre: {cadete.Nombre}\nCantidad de pedidos entregados: {pedidosEntregadosPorCadete}\nGanancia: {pedidosEntregadosPorCadete * 500.00}");
                    }

                    Console.WriteLine($"Total ganancias: {montoTotal}");
                break;
        }
    } while (cont != 4);
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