using ClasseLib;
using projetTp.Tools;
using System.Runtime.CompilerServices;
// See https://aka.ms/new-console-template for more information

var listeVehicule = new List<Vehicule>();
var listCamion = new List<Camion>();

Builder.LoadCamions(listeVehicule);
Builder.LoadVoitures(listeVehicule);



while (true)
{
    Builder.OriginMenu(listeVehicule);
}










