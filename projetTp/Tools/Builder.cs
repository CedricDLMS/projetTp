using ClasseLib;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace projetTp.Tools
{
	public static class Builder
	{
		//public static bool contientUnChiffre(this string chaine) { return chaine.Any(char.IsDigit); }

		// Creation de Camion et Voiture en les ajoutant à une liste de Véhicule donnée
		public static void CamionCreator(this List<Vehicule> liste)
		{

			// -------- Renseigne la marque --------------
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("Création d'un Camion");
			Console.ResetColor();
			Console.WriteLine("Veuillez renseigner les champs suivant : ");
			Console.WriteLine("Marque : *obligatoire");
			string cMarque = Console.ReadLine();
			char vide = ' ';

			// Check si cMarque est vide ou non, recommence tant que vide care obligatoire

			while (string.IsNullOrEmpty(cMarque) || string.IsNullOrWhiteSpace(cMarque) || cMarque.Any(char.IsDigit))
			{
				Console.WriteLine("La marque ne peut pas etre vide, ou contenir de chiffre, renseignez à nouveau la marque");
				cMarque = Console.ReadLine();
			}
			// -------- Renseigne le poids --------------

			Console.WriteLine("Veuillez renseigner les champs suivant : ");
			Console.WriteLine("Poids : *obligatoire ( Supérieur à 0 ) ");
			double cPoids;

			// Check si cPoids est > à 0 et Valide 

			while (!(Double.TryParse(Console.ReadLine(), out cPoids)) || cPoids <= 0)
			{
				Console.WriteLine("Le poid rentrée est invalide, veuillez recommencer");
			}

			// -------- Renseigne le Modele --------------

			Console.WriteLine("Veuillez renseigner les champs suivant : ");
			Console.WriteLine("Modele : * Obligatoire ");
			string cModele = Console.ReadLine();
			while (string.IsNullOrEmpty(cModele) || string.IsNullOrWhiteSpace(cModele))
			{
				Console.WriteLine("Le modele doit être renseigné");
				Console.WriteLine("Modele : ");
				cModele = Console.ReadLine();
			}

			// -------- Renseigne le Numero --------------

			Console.WriteLine("Veuillez renseigner les champs suivant : ");
			Console.WriteLine("Numéro : Obligatoire,Entre 4 et 6 charactères, Non vide, Pas de charactères spéciaux ");
			string cNumero = Console.ReadLine();
			// TESTE LE NUMERO
			while (cNumero.Length < 4 || cNumero.Length > 6 || string.IsNullOrWhiteSpace(cNumero) || string.IsNullOrEmpty(cNumero) || cNumero.Any(char.IsSymbol) || cNumero.Any(char.IsPunctuation))
			{
				if (string.IsNullOrEmpty(cNumero) || string.IsNullOrWhiteSpace(cNumero))
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Numéro vide ou composé d'especes, veuillez recommencer :");
					Console.ForegroundColor = ConsoleColor.White;
					cNumero = Console.ReadLine();
				}
				if (cNumero.Length < 4 || cNumero.Length > 6)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Numéro de Taille Invalide, veuillez recommencer :");
					Console.ForegroundColor = ConsoleColor.White;
					cNumero = Console.ReadLine();
				}
				if (cNumero.Any(char.IsSymbol) || cNumero.Any(char.IsPunctuation))
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Numéro contient des charactères spéciaux, veuillez recommencer :");
					Console.ForegroundColor = ConsoleColor.White;
					cNumero = Console.ReadLine();
				}
			}

			// Rajoute le nouveau camion créer à la liste de Véhicule demandé

			liste.Add(new Camion(cMarque, cPoids, cModele, cNumero));
			//liste.Add(newItem);
			Console.WriteLine("Véhicule Crée");

		}
		public static void VoitureCreator(List<Vehicule> liste)
		{

			// -------- Renseigne la marque --------------
			Console.ForegroundColor = ConsoleColor.DarkBlue;
			Console.WriteLine("Création d'une Voiture");
			Console.ResetColor();
			Console.WriteLine("Veuillez renseigner les champs suivant : ");
			Console.WriteLine("Marque : *obligatoire");
			string cMarque = Console.ReadLine();
			char vide = ' ';

			// Check si cMarque est vide ou non, recommence tant que vide care obligatoire

			while (string.IsNullOrEmpty(cMarque) || string.IsNullOrWhiteSpace(cMarque) || cMarque.Any(char.IsDigit))
			{
				Console.WriteLine("La marque ne peut pas etre vide, ou contenir de chiffre, renseignez à nouveau la marque");
				cMarque = Console.ReadLine();
			}
			// -------- Renseigne la Puissance --------------

			Console.WriteLine("Veuillez renseigner les champs suivant : ");
			Console.WriteLine("Puissance : *obligatoire ( Supérieur à 0 ) ");
			double cPuissance;

			// Check si cPuissance est > à 0 et Valide 

			while (!(Double.TryParse(Console.ReadLine(), out cPuissance)) || cPuissance <= 0)
			{
				Console.WriteLine("Le poid rentrée est invalide, veuillez recommencer");
			}

			// -------- Renseigne le Modele --------------

			Console.WriteLine("Veuillez renseigner les champs suivant : ");
			Console.WriteLine("Modele : * Obligatoire ");
			string cModele = Console.ReadLine();
			while (string.IsNullOrEmpty(cModele) || string.IsNullOrWhiteSpace(cModele))
			{
				Console.WriteLine("Le modele doit être renseigné");
				Console.WriteLine("Modele : ");
				cModele = Console.ReadLine();
			}

			// -------- Renseigne le Numero --------------

			Console.WriteLine("Veuillez renseigner les champs suivant : ");
			Console.WriteLine("Numéro : *Obligatoire entre 4 et 6 charactères, pas charactère spéciaux ");
			string cNumero = Console.ReadLine();
			// TESTE LE NUMERO
			while (cNumero.Length < 4 || cNumero.Length > 6 || string.IsNullOrWhiteSpace(cNumero) || string.IsNullOrEmpty(cNumero) || cNumero.Any(char.IsSymbol) || cNumero.Any(char.IsPunctuation))
			{
				if (string.IsNullOrEmpty(cNumero) || string.IsNullOrWhiteSpace(cNumero))
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Numéro vide ou composé d'especes, veuillez recommencer :");
					Console.ForegroundColor = ConsoleColor.White;
					cNumero = Console.ReadLine();
				}
				if (cNumero.Length < 4 || cNumero.Length > 6)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Numéro de Taille Invalide, veuillez recommencer :");
					Console.ForegroundColor = ConsoleColor.White;
					cNumero = Console.ReadLine();
				}
				if (cNumero.Any(char.IsSymbol) || cNumero.Any(char.IsPunctuation))
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Numéro contient des charactères spéciaux, veuillez recommencer :");
					Console.ForegroundColor = ConsoleColor.White;
					cNumero = Console.ReadLine();
				}
			}



			// Rajoute la nouvelle voiture crée à la liste de Véhicules demandé

			liste.Add(new Voiture(cMarque, cPuissance, cModele, cNumero));
			//liste.Add(newItem);
			Console.WriteLine("Véhicule Crée");

		}

		// Permet de lire tout les véhicule d'une liste donnée
		public static void ReadAll(List<Vehicule> liste)
		{
			foreach (var item in liste)
			{
				Console.WriteLine(item);
			}
		}
		// Filtre par marque dans une liste temporaire
		public static List<Vehicule> SearchByMarque(List<Vehicule> liste)
		{
			Console.WriteLine("Veuillez Renseigner la Marque du véhicule");
			var Marque = Console.ReadLine();

			// Applique le filtre en fonction de la marque 

			var listeMarque = liste.Where(v => v.Marque.ToLower() == Marque.ToLower()); // Creation d'une liste Temporaire
			Console.WriteLine("Voici votre résultat : ");
			int i = 0;
			// Affiche tout les items avec ce nom de marque
			if (listeMarque.Count() > 0)
			{
				foreach (var item in listeMarque)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.Write($"ID : {i}"); // Affiche l'ID en jaune
					Console.ResetColor();
					Console.WriteLine($" | {item}");
					i++;
				}
			}
			else if (listeMarque.Count() == 0)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Aucun Résultat correspondant. ");
				Console.ResetColor();
				listeMarque = SearchByMarque(liste); // Change listeMarque dans le cas ou des erreurs sont commises
			}
			// Retourne la liste pour etre utilisé ailleur :DDDDD
			return listeMarque.ToList();
		}
		// Filtre par Modele dans une liste temporaire
		public static List<Vehicule> SearchByModele(List<Vehicule> liste)
		{
			Console.WriteLine("Veuillez Renseigner le Modele du véhicule");
			var Modele = Console.ReadLine();

			// Applique le filtre en fonction de la Modele 

			var listeModele = liste.Where(v => v.Modele.ToLower() == Modele.ToLower()); // Creation d'une liste Temporaire
			Console.WriteLine("Voici votre résultat : ");
			int i = 0;
			// Affiche tout les items avec ce nom de Modele
			if (listeModele.Count() > 0)
			{
				foreach (var item in listeModele)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.Write($"ID : {i}"); // Affiche l'ID en jaune
					Console.ResetColor();
					Console.WriteLine($" | {item}");
					i++;
				}
			}
			else if (listeModele.Count() == 0)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Aucun Résultat correspondant. ");
				Console.ResetColor();
				listeModele = SearchByModele(liste); // Change listeModele dans le cas ou des erreurs sont commises
			}
			// Retourne la liste pour etre utilisé ailleur :DDDDD
			return listeModele.ToList();
		}
		// Filtre par Numéro
		public static List<Vehicule> SearchByNumero(List<Vehicule> liste)
		{
			Console.WriteLine("Veuillez Renseigner le Numéro du véhicule");
			var Numero = Console.ReadLine();

			// Applique le filtre en fonction de la marque 

			var listeNumero = liste.Where(v => v.Numero.ToLower() == Numero.ToLower()); // Creation d'une liste Temporaire
			Console.WriteLine("Voici votre résultat : ");
			int i = 0;
			// Affiche tout les items avec ce nom de marque
			if (listeNumero.Count() > 0)
			{
				foreach (var item in listeNumero)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.Write($"ID : {i}"); // Affiche l'ID en jaune
					Console.ResetColor();
					Console.WriteLine($" | {item}");
					i++;
				}
			}
			else if (listeNumero.Count() == 0)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Aucun Résultat correspondant. ");
				Console.ResetColor();
				listeNumero = SearchByNumero(liste); //Change listeNumero dans le cas ou des erreurs sont commises
			}
			// Retourne la liste pour etre utilisé ailleur :DDDDD
			return listeNumero.ToList();
		}
		// Filtre par Puissance
		public static List<Vehicule> SearchByPuissance(List<Vehicule> liste)
		{
			Console.WriteLine("Veuillez Renseigner la Puissance du véhicule");
			double Puissance;
			// Check que puissance soit bien renseigné
			while (!(Double.TryParse(Console.ReadLine(), out Puissance)) || Puissance <= 0)
			{
				Console.WriteLine("Le poid rentrée est invalide, veuillez recommencer");
			}

			// Applique le filtre en fonction de la Puissance 

			var listePuissance = liste.OfType<Voiture>().Where(v => v.Puissance == Puissance).ToList<Vehicule>(); // Creation d'une liste Temporaire
			Console.WriteLine("Voici votre résultat : ");
			int i = 0;
			// Affiche tout les items avec ce nom de marque
			if (listePuissance.Count() > 0)
			{
				foreach (var item in listePuissance)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.Write($"ID : {i}"); // Affiche l'ID en jaune
					Console.ResetColor();
					Console.WriteLine($" | {item}");
					i++;
				}
			}
			else if (listePuissance.Count() == 0)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Aucun Résultat correspondant. ");
				Console.ResetColor();
				listePuissance = SearchByPuissance(liste);
			}
			// Retourne la liste pour etre utilisé ailleur :DDDDD
			return listePuissance.ToList<Vehicule>();
		}
		// Filtre par Poids
		public static List<Vehicule> SearchByPoids(List<Vehicule> liste)
		{
			Console.WriteLine("Veuillez Renseigner le Poids du véhicule");
			double Poids;
			// Check que puissance soit bien renseigné
			while (!(Double.TryParse(Console.ReadLine(), out Poids)) || Poids <= 0)
			{
				Console.WriteLine("Le poid rentrée est invalide, veuillez recommencer");
			}

			// Applique le filtre en fonction de la Puissance 

			var listePoids = liste.OfType<Camion>().Where(v => v.Poids == Poids).ToList<Vehicule>(); // Creation d'une liste Temporaire
			Console.WriteLine("Voici votre résultat : ");
			int i = 0;
			// Affiche tout les items avec ce nom de marque
			if (listePoids.Count() > 0)
			{
				foreach (var item in listePoids)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.Write($"ID : {i}"); // Affiche l'ID en jaune
					Console.ResetColor();
					Console.WriteLine($" | {item}");
					i++;
				}
			}else if (listePoids.Count() == 0)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Aucun Résultat correspondant. ");
				Console.ResetColor();
				listePoids = SearchByPoids(liste);
			}
			// Retourne la liste pour etre utilisé ailleur :DDDDD
			return listePoids.ToList<Vehicule>();
		}
		// Filtre par Type
		public static List<Vehicule> SearchByType(List<Vehicule> liste)
		{
			Console.WriteLine("Veuillez Renseigner le Type du véhicule ( 1 : Camion , 2 : Voiture )");
			var Type = Console.ReadLine();
			int selection;
			var listeTypeVoiture = liste.OfType<Voiture>().ToList<Voiture>;
			var listTypeCamion = liste.OfType<Camion>().ToList<Camion>;
			var listeNew = new List<Vehicule>();
			int i = 0;
			bool isValideParse = Int32.TryParse(Type, out selection);
			bool isValidSection = selection == 1 || selection == 2;
			bool isValide = isValideParse && isValidSection;
			// Effectue la boucle tant que la valeur voiture ou camtar est fausse 
            while (!isValideParse || !isValidSection)
			{
				Console.WriteLine("Le type renseigné n'est pas bon , sélectionnez 1 pour camion ou 2 pour voiture ");
				Type = Console.ReadLine();
                isValideParse = Int32.TryParse(Type, out selection);
                isValidSection = selection == 1 || selection == 2;
            }
			if (selection == 1)
			{
				listeNew = liste.Where(c => c is Camion ).ToList();
			}
			if (selection == 2)
			{
                listeNew = liste.Where(v => v is Voiture).ToList();
            }
			// Les affiche
			foreach (var item in listeNew)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write($"ID : {i}"); // Affiche l'ID en jaune
				Console.ResetColor();
				Console.WriteLine($" | {item}");
				i++;
			}

			return listeNew.ToList();
		}

		// Permet de supprimer en fonction de critères choisis
		public static void DeleteMenu(List<Vehicule> liste)
		{
			Console.WriteLine("Quelle Infos connaissez vous sur le véhicule à supprimer ?");
			Console.WriteLine("1 : Marque , 2 : Numéro, 3 : Modèle, 4 : Puissance, 5 : Poids, 6 : Type(Camion ou Voiture)");
			var keyPressed = Console.ReadKey().Key;
			Console.WriteLine();
			// ---------- Option 1 : Marque -----------------
			if (keyPressed == ConsoleKey.NumPad1 || keyPressed == ConsoleKey.D1)
			{
				var monFiltreMa = SearchByMarque(liste);
				int idASupprimerMa;
				// Suppression 
				bool idValideMa = false;
				// Boucle qui itère tant que l'ID renseigné n'est pas valide
				while (!idValideMa)
				{
					Console.WriteLine("Le quel supprimer ? Renseigner un ID : ");
					if (int.TryParse(Console.ReadLine(), out idASupprimerMa) && idASupprimerMa >= 0 && idASupprimerMa < monFiltreMa.Count)
					{
						// Convertir l'ID renseigné en l'objet correspondant
						var elementASupprimer = monFiltreMa.ElementAt(idASupprimerMa);

						// Supprime L'élément Correspondant dans la liste initiale
						liste.Remove(elementASupprimer);

						Console.WriteLine("Élément supprimé avec succès.");
						idValideMa = true;
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("ID invalide, veuiller renseigner un ID Valide : ");
						Console.ResetColor();
					}
				}
			}
			// ---------- Option 2 : Numéro -----------------
			if (keyPressed == ConsoleKey.NumPad2 || keyPressed == ConsoleKey.D2)
			{
				var MonFiltreN = SearchByNumero(liste);
				int idASupprimerN;
				bool idValideN = false;
				// Boucle qui itère tant que l'ID renseigné n'est pas valide
				while (!idValideN)
				{
					Console.WriteLine("Le quel supprimer ? Renseigner un ID : ");
					if (int.TryParse(Console.ReadLine(), out idASupprimerN) && idASupprimerN >= 0 && idASupprimerN <= MonFiltreN.Count)
					{
						// Convertir l'ID renseigné en l'objet correspondant
						var elementASupprimer = MonFiltreN.ElementAt(idASupprimerN);

						// Supprime L'élément Correspondant dans la liste initiale
						liste.Remove(elementASupprimer);

						Console.WriteLine("Élément supprimé avec succès.");
						idValideN = true;
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("ID invalide, veuiller renseigner un ID Valide : ");
						Console.ResetColor();
					}
				}
			}
			// ---------- Option 3 : Modèle -----------------
			if (keyPressed == ConsoleKey.NumPad3 || keyPressed == ConsoleKey.D3)
			{
				var monFiltreMo = SearchByModele(liste);
				int idASupprimerMo;
				// Suppression 
				bool idValideMo = false;
				// Boucle qui itère tant que l'ID renseigné n'est pas valide
				while (!idValideMo)
				{
					Console.WriteLine("Le quel supprimer ? Renseigner un ID : ");
					if (int.TryParse(Console.ReadLine(), out idASupprimerMo) && idASupprimerMo >= 0 && idASupprimerMo < monFiltreMo.Count)
					{
						// Convertir l'ID renseigné en l'objet correspondant
						var elementASupprimer = monFiltreMo.ElementAt(idASupprimerMo);

						// Supprime L'élément Correspondant dans la liste initiale
						liste.Remove(elementASupprimer);

						Console.WriteLine("Élément supprimé avec succès.");
						idValideMo = true;
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("ID invalide, veuiller renseigner un ID Valide : ");
						Console.ResetColor();
					}

				}
			}
			// ---------- Option 4 : Puissance --------------
			if (keyPressed == ConsoleKey.NumPad4 || keyPressed == ConsoleKey.D4)
			{
				var monFiltrePui = SearchByPuissance(liste);
				int idASupprimerPui;
				// Suppression 
				bool idValidePui = false;
				// Boucle qui itère tant que l'ID renseigné n'est pas valide
				while (!idValidePui)
				{
					Console.WriteLine("Le quel supprimer ? Renseigner un ID : ");
					if (int.TryParse(Console.ReadLine(), out idASupprimerPui) && idASupprimerPui >= 0 && idASupprimerPui < monFiltrePui.Count)
					{
						// Convertir l'ID renseigné en l'objet correspondant
						var elementASupprimer = monFiltrePui.ElementAt(idASupprimerPui);

						// Supprime L'élément Correspondant dans la liste initiale
						liste.Remove(elementASupprimer);

						Console.WriteLine("Élément supprimé avec succès.");
						idValidePui = true;
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("ID invalide, veuiller renseigner un ID Valide : ");
						Console.ResetColor();
					}
				}
			}
			// ---------- Option 5 : Poids ------------------
			if (keyPressed == ConsoleKey.NumPad5 || keyPressed == ConsoleKey.D5)
			{
				{
					var monFiltrePoid = SearchByPoids(liste);
					int idASupprimerPoid;
					// Suppression 
					bool idValidePoid = false;
					// Boucle qui itère tant que l'ID renseigné n'est pas valide
					while (!idValidePoid)
					{
						Console.WriteLine("Le quel supprimer ? Renseigner un ID : ");
						if (int.TryParse(Console.ReadLine(), out idASupprimerPoid) && idASupprimerPoid >= 0 && idASupprimerPoid < monFiltrePoid.Count)
						{
							// Convertir l'ID renseigné en l'objet correspondant
							var elementASupprimer = monFiltrePoid.ElementAt(idASupprimerPoid);

							// Supprime L'élément Correspondant dans la liste initiale
							liste.Remove(elementASupprimer);

							Console.WriteLine("Élément supprimé avec succès.");
							idValidePoid = true;
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("ID invalide, veuiller renseigner un ID Valide : ");
							Console.ResetColor();
						}
					}
				}
			}
			// Option 6 : Type
			if (keyPressed == ConsoleKey.NumPad6 || keyPressed == ConsoleKey.D6)
			{
				var monFiltreType = SearchByType(liste);
				int idASupprimerType;
				bool idValideType = false;
				while (!idValideType)
				{
					Console.WriteLine("Le quel supprimer ? Renseigner un ID : ");
					if (int.TryParse(Console.ReadLine(), out idASupprimerType) && idASupprimerType >= 0 && idASupprimerType < monFiltreType.Count)
					{
						// Convertir l'ID renseigné en l'objet correspondant
						var elementASupprimer = monFiltreType.ElementAt(idASupprimerType);

						// Supprime L'élément Correspondant dans la liste initiale
						liste.Remove(elementASupprimer);

						Console.WriteLine("Élément supprimé avec succès.");
						idValideType = true;
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("ID invalide, veuiller renseigner un ID Valide : ");
						Console.ResetColor();
					}

				}
			}
		}
	}
}
