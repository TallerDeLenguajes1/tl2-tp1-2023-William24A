// See https://aka.ms/new-console-template for more information
using System;
using CadeteriaUtilizar;
using ArchivosCSVUtilizar;
var archivo = new Archivo();
string ruta = "DatosCadeterias.csv";
var ListadeCadeterias = new List<Cadeteria>();

if(archivo.ExisteArchivo(ruta)){
    ListadeCadeterias = archivo.LeerDatosCadeteria();
    Console.WriteLine("Existe");
    foreach(var item in ListadeCadeterias){
        Console.WriteLine(item.Nombre);
    }
}else{
    Cadeteria cadeteria = new Cadeteria("ELPancho",1234545);
    
    ListadeCadeterias.Add(cadeteria);
    archivo.CargarDatosCadeterias(ListadeCadeterias);
}