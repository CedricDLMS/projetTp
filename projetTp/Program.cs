using ClasseLib;
using projetTp.Tools;
using System.Runtime.CompilerServices;
// See https://aka.ms/new-console-template for more information

var listeVehicule = new List<Vehicule>();
var listCamion = new List<Camion>();


listeVehicule.Add(new Voiture("PEUGEOT", 55));
listeVehicule.Add(new Voiture("PEUGEOT", 33));
listeVehicule.Add(new Voiture("PEUGEOT", 45));
listeVehicule.Add(new Voiture("PEUGEOT", 66));
listeVehicule.Add(new Voiture("Toyota", 55));
listeVehicule.Add(new Voiture("Porshe", 55));
listeVehicule.Add(new Voiture("London", 55));
listeVehicule.Add(new Camion("Camtar", 55,"OTU","4567"));

Builder.ReadAll(listeVehicule);

//Builder.SearchByNumero(listeVehicule);
Builder.DeleteMenu(listeVehicule);

Builder.ReadAll(listeVehicule);








