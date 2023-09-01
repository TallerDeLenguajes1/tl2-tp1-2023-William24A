// See https://aka.ms/new-console-template for more information
using System;
using CadeteriaUtilizar;
using ArchivosCSVUtilizar;
using CadeteUtilizar;

var archivo = new Archivo();
string ruta = "DatosCadeterias.csv";
string ruta1 = "DatosCadetes.csv";
var ListadeCadeterias = new List<Cadeteria>();

if(archivo.ExisteArchivo(ruta))
{
    ListadeCadeterias = archivo.LeerDatosCadeteria();
    string nombreCadeteria;
    Console.WriteLine("Existe");
    Console.WriteLine("Ingrese nombre de la cadeteria: ");
    nombreCadeteria = Console.ReadLine();
    
    for(int i = 0; i<ListadeCadeterias.Count ; i++)
    {
        if(ListadeCadeterias[i].Nombre == nombreCadeteria)
        {
            if(archivo.ExisteArchivo(ruta1))
            {
                ListadeCadeterias[i] = archivo.LeerDatosCadetes(ListadeCadeterias[i]);
            }
            else
            {
                Console.WriteLine("No existen archivo.");
                
                Cadete cadete = new Cadete(1,"Javier","su casa", 123456);
                ListadeCadeterias[i].AgregarCadete(cadete);
                Cadete cadete1 = new Cadete(2,"William","su casa", 134556);
                ListadeCadeterias[i].AgregarCadete(cadete1);
                archivo.CargarDatosCadetes(ListadeCadeterias[i]);
            }
        }
        else
        {
            Console.WriteLine("No existe la cadeteria.");
        }
    }
}
else
{
    Cadeteria cadeteria = new Cadeteria("ELPancho",1234545);
    
    ListadeCadeterias.Add(cadeteria);
    archivo.CargarDatosCadeterias(ListadeCadeterias);
}