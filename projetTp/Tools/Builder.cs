using ClasseLib;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace projetTp.Tools
{
    public static class Builder
    {
        private static string originPath = Path.GetFullPath("../../../Data");
        private static string voitureNamePath = @"\VoituresData.json";
        private static string camionNamePath = @"\CamionsData.json";

        private static string voiturePath = originPath + voitureNamePath;
        private static string camionPath = originPath + camionNamePath;
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
        public static void VoitureCreator(this List<Vehicule> liste)
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
        public static void VoitureUpdate(Voiture voiture)
        {
            // -------- Renseigne la marque --------------
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Modification d'une Voiture");
            Console.ResetColor();
            Console.WriteLine("Veuillez renseigner les champs suivant : ");

            char vide = ' ';

            Console.WriteLine("Marque actuelle : Appuyez sur entrée pour laisser l'ancienne valeur");
            var newMarque = Console.ReadLine();
            // Check si cMarque contient un carachtere numérique
            while (newMarque.Any(char.IsDigit))
            {
                Console.WriteLine("La marque ne peut contenir de chiffres , renseignez à nouveau");
                newMarque = Console.ReadLine();
            }
            voiture.Marque = !string.IsNullOrEmpty(newMarque) || !string.IsNullOrWhiteSpace(newMarque) ? newMarque : voiture.Marque;

            // -------- Renseigne la Puissance --------------

            Console.WriteLine("Puissance : (Supérieur à 0 ou laissez vide pour conserver la valeur par défaut)");
            do
            {
                string cPuissanceS = Console.ReadLine(); // Lecture de l'entrée utilisateur

                // Si l'utilisateur appuie sur Entrée sans saisir de valeur, sort de la boucle sans changer la valeur de Puissance
                if (string.IsNullOrWhiteSpace(cPuissanceS))
                {
                    break;
                }

                // Essaie de convertir l'entrée en double et vérifie si elle est supérieure à 0
                else if (double.TryParse(cPuissanceS, out double cPuissance) && cPuissance > 0)
                {
                    voiture.Puissance = cPuissance; // Affecte la valeur valide à la propriété Puissance
                    break; // Sort de la boucle après avoir affecté une nouvelle valeur valide
                }
                else
                {
                    Console.WriteLine("La valeur entrée est invalide, veuillez recommencer avec un nombre supérieur à 0 ou laissez vide pour conserver la valeur par défaut :");
                }
            } while (true); // Continue de boucler jusqu'à ce qu'une entrée valide soit saisie ou que l'entrée soit vide


            //// -------- Renseigne le Modele --------------

            Console.WriteLine("Modele : Laissez vide pour conserver la valeur par défaut");
            string cModele = Console.ReadLine();
            voiture.Modele = !string.IsNullOrEmpty(cModele) || !string.IsNullOrWhiteSpace(cModele) ? cModele : voiture.Modele;
        }
        public static void CamionUpdate(Camion camion)
        {
            // -------- Renseigne la marque --------------
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Modification d'un Camion");
            Console.ResetColor();
            Console.WriteLine("Veuillez renseigner les champs suivant : ");

            char vide = ' ';

            Console.WriteLine("Marque : Appuyez sur entrée pour laisser l'ancienne valeur");
            var newMarque = Console.ReadLine();
            // Check si cMarque contient un carachtere numérique
            while (newMarque.Any(char.IsDigit))
            {
                Console.WriteLine("La marque ne peut contenir de chiffres , renseignez à nouveau");
                newMarque = Console.ReadLine();
            }
            camion.Marque = !string.IsNullOrEmpty(newMarque) || !string.IsNullOrWhiteSpace(newMarque) ? newMarque : camion.Marque;

            // -------- Renseigne la Poids --------------

            Console.WriteLine("Poids : (Supérieur à 0 ou laissez vide pour conserver la valeur par défaut)");
            do
            {
                string cPoids = Console.ReadLine(); // Lecture de l'entrée utilisateur

                // Si l'utilisateur appuie sur Entrée sans saisir de valeur, sort de la boucle sans changer la valeur de Puissance
                if (string.IsNullOrWhiteSpace(cPoids))
                {
                    break;
                }

                // Essaie de convertir l'entrée en double et vérifie si elle est supérieure à 0
                else if (double.TryParse(cPoids, out double Poids) && Poids > 0)
                {
                    camion.Poids = Poids; // Affecte la valeur valide à la propriété Puissance
                    break; // Sort de la boucle après avoir affecté une nouvelle valeur valide
                }
                else
                {
                    Console.WriteLine("La valeur entrée est invalide, veuillez recommencer avec un nombre supérieur à 0 ou laissez vide pour conserver la valeur par défaut :");
                }
            } while (true); // Continue de boucler jusqu'à ce qu'une entrée valide soit saisie ou que l'entrée soit vide


            //// -------- Renseigne le Modele --------------

            Console.WriteLine("Modèle : Laissez vide pour conserver la valeur par défaut");
            string cModele = Console.ReadLine();
            camion.Modele = !string.IsNullOrEmpty(cModele) || !string.IsNullOrWhiteSpace(cModele) ? cModele : camion.Modele;
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
            }
            else if (listePoids.Count() == 0)
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
                listeNew = liste.Where(c => c is Camion).ToList();
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

        public static void SearchMenu(List<Vehicule> liste)
        {
            bool keyInvalid;
            Console.WriteLine("Sur quel caractère chercher ?");
            do
            {
                keyInvalid = false;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1 : Marque, 2 : Modele, 3 : Numero, 4 : Puissance, 5 : Poids, 6 : Type");
                Console.ResetColor();
                var keyPressed = Console.ReadKey().Key;
                Console.WriteLine();
                keyInvalid = !(keyPressed == ConsoleKey.NumPad1 || keyPressed == ConsoleKey.D1
                || keyPressed == ConsoleKey.NumPad2 || keyPressed == ConsoleKey.D2
                || keyPressed == ConsoleKey.NumPad3 || keyPressed == ConsoleKey.D3
                || keyPressed == ConsoleKey.NumPad4 || keyPressed == ConsoleKey.D4
                || keyPressed == ConsoleKey.NumPad5 || keyPressed == ConsoleKey.D5
                || keyPressed == ConsoleKey.NumPad6 || keyPressed == ConsoleKey.D6);
                if (keyInvalid)
                {
                    Console.WriteLine("Touche non valide, veuillez réessayer.");
                }
                else
                {
                    // 1 : Marque
                    if (keyPressed == ConsoleKey.NumPad1 || keyPressed == ConsoleKey.D1)
                    {
                        SearchByMarque(liste);
                    }
                    // 2 : Modele
                    if (keyPressed == ConsoleKey.NumPad2 || keyPressed == ConsoleKey.D2)
                    {
                        SearchByModele(liste);
                    }
                    // 3 : Numéro
                    if (keyPressed == ConsoleKey.NumPad3 || keyPressed == ConsoleKey.D3)
                    {
                        SearchByNumero(liste);
                    }
                    // 4 : Puissance
                    if (keyPressed == ConsoleKey.NumPad4 || keyPressed == ConsoleKey.D4)
                    {
                        SearchByPuissance(liste);
                    }
                    // 5 : Poids
                    if (keyPressed == ConsoleKey.NumPad5 || keyPressed == ConsoleKey.D5)
                    {
                        SearchByPoids(liste);
                    }
                    // 6 : Type
                    if (keyPressed == ConsoleKey.NumPad6 || keyPressed == ConsoleKey.D6)
                    {
                        SearchByType(liste);
                    }
                }
            } while (keyInvalid);
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

        public static void UpdateVehicule(List<Vehicule> liste)
        {
            Console.WriteLine("Quel Véhicule souhaitez vous modifier ? Afin de le trouver, rentrez votre critère de recherche");
            Console.WriteLine("1 : Marque , 2 : Numéro, 3 : Modèle, 4 : Puissance, 5 : Poids, 6 : Type(Camion ou Voiture)");
            bool keyInvalid;
            do
            {
                keyInvalid = false;
                var keyPressed = Console.ReadKey().Key;
                Console.WriteLine();

                keyInvalid = !(keyPressed == ConsoleKey.NumPad1 || keyPressed == ConsoleKey.D1
                || keyPressed == ConsoleKey.NumPad2 || keyPressed == ConsoleKey.D2
                || keyPressed == ConsoleKey.NumPad3 || keyPressed == ConsoleKey.D3
                || keyPressed == ConsoleKey.NumPad4 || keyPressed == ConsoleKey.D4
                || keyPressed == ConsoleKey.NumPad5 || keyPressed == ConsoleKey.D5
                || keyPressed == ConsoleKey.NumPad6 || keyPressed == ConsoleKey.D6);
                if (keyInvalid)
                {
                    Console.WriteLine("Touche invalide, recommencez");
                }
                else
                {
                    // ---------- Option 1 : Marque -----------------
                    if (keyPressed == ConsoleKey.NumPad1 || keyPressed == ConsoleKey.D1)
                    {
                        var filtreByMarque = SearchByMarque(liste);
                        int idAModifierMa;
                        bool idIsValidMa = false;
                        while (!idIsValidMa)
                        {
                            Console.WriteLine("Le quel modifier ? Renseignez un ID");
                            if (int.TryParse(Console.ReadLine(), out idAModifierMa) && idAModifierMa >= 0 && idAModifierMa < filtreByMarque.Count)
                            {
                                var ElementAModifier = filtreByMarque.ElementAt(idAModifierMa);
                                if (ElementAModifier is Voiture)
                                {
                                    VoitureUpdate(ElementAModifier as Voiture);
                                }
                                else if (ElementAModifier is Camion)
                                {
                                    CamionUpdate(ElementAModifier as Camion);
                                }
                                idIsValidMa = true;
                            }
                            else
                            {
                                Console.WriteLine("ID invalide, en renseignez un valide");
                            }
                        }

                    }
                    // ---------- Option 2 : Numéro -----------------

                    if (keyPressed == ConsoleKey.NumPad2 || keyPressed == ConsoleKey.D2)
                    {
                        var filtreByNumero = SearchByNumero(liste);
                        int idAModifierMa;
                        bool idIsValidMa = false;
                        while (!idIsValidMa)
                        {
                            Console.WriteLine("Le quel modifier ? Renseignez un ID");
                            if (int.TryParse(Console.ReadLine(), out idAModifierMa) && idAModifierMa >= 0 && idAModifierMa < filtreByNumero.Count)
                            {
                                var ElementAModifier = filtreByNumero.ElementAt(idAModifierMa);
                                if (ElementAModifier is Voiture)
                                {
                                    VoitureUpdate(ElementAModifier as Voiture);
                                }
                                else if (ElementAModifier is Camion)
                                {
                                    CamionUpdate(ElementAModifier as Camion);
                                }
                                idIsValidMa = true;
                            }
                            else
                            {
                                Console.WriteLine("ID invalide, en renseignez un valide");
                            }
                        }
                    }
                    // ---------- Option 3 : Modèle -----------------

                    if (keyPressed == ConsoleKey.NumPad3 || keyPressed == ConsoleKey.D3)
                    {
                        var filtreByModele = SearchByModele(liste);
                        int idAModifierMa;
                        bool idIsValidMa = false;
                        while (!idIsValidMa)
                        {
                            Console.WriteLine("Le quel modifier ? Renseignez un ID");
                            if (int.TryParse(Console.ReadLine(), out idAModifierMa) && idAModifierMa >= 0 && idAModifierMa < filtreByModele.Count)
                            {
                                var ElementAModifier = filtreByModele.ElementAt(idAModifierMa);
                                if (ElementAModifier is Voiture)
                                {
                                    VoitureUpdate(ElementAModifier as Voiture);
                                }
                                else if (ElementAModifier is Camion)
                                {
                                    CamionUpdate(ElementAModifier as Camion);
                                }
                                idIsValidMa = true;
                            }
                            else
                            {
                                Console.WriteLine("ID invalide, en renseignez un valide");
                            }
                        }
                    }
                    // ---------- Option 4 : Puissance --------------
                    if (keyPressed == ConsoleKey.NumPad4 || keyPressed == ConsoleKey.D4)
                    {
                        var filtreByPuissance = SearchByPuissance(liste);
                        int idAModifierMa;
                        bool idIsValidMa = false;
                        while (!idIsValidMa)
                        {
                            Console.WriteLine("Le quel modifier ? Renseignez un ID");
                            if (int.TryParse(Console.ReadLine(), out idAModifierMa) && idAModifierMa >= 0 && idAModifierMa < filtreByPuissance.Count)
                            {
                                var ElementAModifier = filtreByPuissance.ElementAt(idAModifierMa);
                                if (ElementAModifier is Voiture)
                                {
                                    VoitureUpdate(ElementAModifier as Voiture);
                                }
                                else if (ElementAModifier is Camion)
                                {
                                    CamionUpdate(ElementAModifier as Camion);
                                }
                                idIsValidMa = true;
                            }
                            else
                            {
                                Console.WriteLine("ID invalide, en renseignez un valide");
                            }
                        }
                    }
                    // ---------- Option 5 : Poids ------------------
                    if (keyPressed == ConsoleKey.NumPad5 || keyPressed == ConsoleKey.D5)
                    {
                        var filtreByPoids = SearchByPoids(liste);
                        int idAModifierMa;
                        bool idIsValidMa = false;
                        while (!idIsValidMa)
                        {
                            Console.WriteLine("Le quel modifier ? Renseignez un ID");
                            if (int.TryParse(Console.ReadLine(), out idAModifierMa) && idAModifierMa >= 0 && idAModifierMa < filtreByPoids.Count)
                            {
                                var ElementAModifier = filtreByPoids.ElementAt(idAModifierMa);
                                if (ElementAModifier is Voiture)
                                {
                                    VoitureUpdate(ElementAModifier as Voiture);
                                }
                                else if (ElementAModifier is Camion)
                                {
                                    CamionUpdate(ElementAModifier as Camion);
                                }
                                idIsValidMa = true;
                            }
                            else
                            {
                                Console.WriteLine("ID invalide, en renseignez un valide");
                            }
                        }
                    }
                    // ---------- Option 6 : Type -------------------
                    if (keyPressed == ConsoleKey.NumPad6 || keyPressed == ConsoleKey.D6)
                    {
                        var filtreByType = SearchByType(liste);
                        int idAModifierMa;
                        bool idIsValidMa = false;
                        while (!idIsValidMa)
                        {
                            Console.WriteLine("Le quel modifier ? Renseignez un ID");
                            if (int.TryParse(Console.ReadLine(), out idAModifierMa) && idAModifierMa >= 0 && idAModifierMa < filtreByType.Count)
                            {
                                var ElementAModifier = filtreByType.ElementAt(idAModifierMa);
                                if (ElementAModifier is Voiture)
                                {
                                    VoitureUpdate(ElementAModifier as Voiture);
                                }
                                else if (ElementAModifier is Camion)
                                {
                                    CamionUpdate(ElementAModifier as Camion);
                                }
                                idIsValidMa = true;
                            }
                            else
                            {
                                Console.WriteLine("ID invalide, en renseignez un valide");
                            }
                        }
                    }
                }
            } while (keyInvalid);


        }

        public static void TriMenu(List<Vehicule> liste)
        {
            Console.WriteLine("Sur quelle caractère voulez vous trier ?");

            bool keyInvalid;
            do
            {
                keyInvalid = false;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1 : Marque, 2 : Modele, 3 : Numero, 4 : Puissance, 5 : Poids, 6 : Type");
                Console.ResetColor();
                var keyPressed = Console.ReadKey().Key;
                Console.WriteLine();
                keyInvalid = !(keyPressed == ConsoleKey.NumPad1 || keyPressed == ConsoleKey.D1
                || keyPressed == ConsoleKey.NumPad2 || keyPressed == ConsoleKey.D2
                || keyPressed == ConsoleKey.NumPad3 || keyPressed == ConsoleKey.D3
                || keyPressed == ConsoleKey.NumPad4 || keyPressed == ConsoleKey.D4
                || keyPressed == ConsoleKey.NumPad5 || keyPressed == ConsoleKey.D5
                || keyPressed == ConsoleKey.NumPad6 || keyPressed == ConsoleKey.D6);
                if (keyInvalid)
                {
                    Console.WriteLine("Touche non valide, veuillez réessayer.");
                }
                else
                {
                    // ------- 1 : Marque ---------
                    if (keyPressed == ConsoleKey.NumPad1 || keyPressed == ConsoleKey.D1)
                    {
                        var triByMarque = liste.OrderBy(x => x.Marque);
                        foreach (var item in triByMarque)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    // ------ 2 : Modele ---------
                    if (keyPressed == ConsoleKey.NumPad2 || keyPressed == ConsoleKey.D2)
                    {
                        var triByModele = liste.OrderBy(x => x.Modele);
                        foreach (var item in triByModele)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    // ----- 3 : Numero ----------
                    if (keyPressed == ConsoleKey.NumPad3 || keyPressed == ConsoleKey.D3)
                    {
                        var triByNumero = liste.OrderByDescending(x => x.Numero);
                        foreach (var item in triByNumero)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    // ---- 4 : Puissance ------
                    if (keyPressed == ConsoleKey.NumPad4 || keyPressed == ConsoleKey.D4)
                    {
                        var triByPuissance = liste.OfType<Voiture>().OrderBy(v => v.Puissance);
                        foreach (var item in triByPuissance)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    // ---- 5 : Poids -----------
                    if (keyPressed == ConsoleKey.NumPad5 || keyPressed == ConsoleKey.D5)
                    {
                        var triByPoids = liste.OfType<Camion>().OrderBy(v => v.Poids);
                        foreach (var item in triByPoids)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    // ---- 6 : Type ------------
                    if (keyPressed == ConsoleKey.NumPad6 || keyPressed == ConsoleKey.D6)
                    {
                        var triByType = liste.OrderBy(v => v.GetType().Name);
                        foreach (var item in triByType)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }
            } while (keyInvalid);
        }

        public static void OriginMenu(List<Vehicule> liste)
        {
            //Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("             BIENVENUE             ");
            Console.WriteLine("-----------------------------------");
            Console.ResetColor();

            bool keyInvalid;
            do
            {
                keyInvalid = false;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1 - Créer un Véhicule");
                Console.WriteLine("2 - Voir un Véhicule");
                Console.WriteLine("3 - Mettre à jour un Véhicule");
                Console.WriteLine("4 - Supprimer un Véhicule");
                Console.WriteLine("5 - Trier les Véhicules");
                Console.WriteLine("6 - Filtrer les Véhicules ");
                Console.WriteLine("7 - Voir tout les Véhicules ");
                Console.WriteLine("8 - Sauvegarder les véhicules");
                Console.ResetColor();
                var keyPressed = Console.ReadKey().Key;
                Console.WriteLine();
                keyInvalid = !(keyPressed == ConsoleKey.NumPad1 || keyPressed == ConsoleKey.D1
                || keyPressed == ConsoleKey.NumPad2 || keyPressed == ConsoleKey.D2
                || keyPressed == ConsoleKey.NumPad3 || keyPressed == ConsoleKey.D3
                || keyPressed == ConsoleKey.NumPad4 || keyPressed == ConsoleKey.D4
                || keyPressed == ConsoleKey.NumPad5 || keyPressed == ConsoleKey.D5
                || keyPressed == ConsoleKey.NumPad6 || keyPressed == ConsoleKey.D6
                || keyPressed == ConsoleKey.NumPad7 || keyPressed == ConsoleKey.D7
                || keyPressed == ConsoleKey.NumPad8 || keyPressed == ConsoleKey.D8);
                if (keyInvalid)
                {
                    Console.WriteLine("Touche non valide, veuillez réessayer.");
                }
                else
                {
                    // --------- 1 Creation ----------
                    if (keyPressed == ConsoleKey.NumPad1 || keyPressed == ConsoleKey.D1)
                    {
                        Console.WriteLine("Voulez vous créer une 1 : voiture ou un 2 : Camion ?");
                        bool choixInvalid;
                        do
                        {
                            choixInvalid = false;
                            var choixKey = Console.ReadKey().Key;
                            Console.WriteLine();
                            choixInvalid = !(choixKey == ConsoleKey.NumPad1 || choixKey == ConsoleKey.D1
                            || choixKey == ConsoleKey.NumPad2 || choixKey == ConsoleKey.D2);
                            if (choixInvalid)
                            {
                                Console.WriteLine("Choix invalide , recommencez");
                            }
                            else
                            {
                                // 1 : Voiture
                                if (choixKey == ConsoleKey.NumPad1 || choixKey == ConsoleKey.D1)
                                {
                                    VoitureCreator(liste);
                                }
                                // 2 : Camion
                                if (choixKey == ConsoleKey.NumPad2 || choixKey == ConsoleKey.D2)
                                {
                                    CamionCreator(liste);
                                }
                            }
                        } while (choixInvalid);
                    }
                    // --------- 2 : Voir Vehicule ---
                    if (keyPressed == ConsoleKey.NumPad2 || keyPressed == ConsoleKey.D2)
                    {
                        SearchMenu(liste);
                    }
                    // -------- 3 : Update -----------
                    if (keyPressed == ConsoleKey.NumPad3 || keyPressed == ConsoleKey.D3)
                    {
                        UpdateVehicule(liste);
                    }
                    // -- 4 : Supprimer un Véhicule --
                    if (keyPressed == ConsoleKey.NumPad4 || keyPressed == ConsoleKey.D4)
                    {
                        DeleteMenu(liste);
                    }
                    // --------- 5 : Tri -------------
                    if (keyPressed == ConsoleKey.NumPad5 || keyPressed == ConsoleKey.D5)
                    {
                        TriMenu(liste);
                    }
                    // -------- 6 : Filtrer ----------
                    if (keyPressed == ConsoleKey.NumPad6 || keyPressed == ConsoleKey.D6)
                    {
                        SearchMenu(liste);
                    }
                    // ------- 7 : Voir tout ---------
                    if (keyPressed == ConsoleKey.NumPad7 || keyPressed == ConsoleKey.D7)
                    {
                        ReadAll(liste);
                    }
                    // ------ 8 : Sauvegarder -------
                    if(keyPressed == ConsoleKey.NumPad8 || keyPressed == ConsoleKey.D8)
                    {
                        Sauvegarde(liste);
                    }
                }

            } while (keyInvalid);
        }

        public static void Sauvegarde(List<Vehicule> liste)
        {
            var option = new JsonSerializerOptions { WriteIndented = true };
            // Creation de deux listes pour camion et voiture
            List<Camion> camionListe = liste.Where(c => c is Camion).Cast<Camion>().ToList();
            List<Voiture> voitureListe = liste.Where(v => v is Voiture).Cast<Voiture>().ToList();

            if (camionListe.Count > 0)
            {
                File.WriteAllText(camionPath,JsonSerializer.Serialize(camionListe,option));
            }
            if (voitureListe.Count > 0)
            {
                File.WriteAllText(voiturePath, JsonSerializer.Serialize(voitureListe, option));
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sauvegarde effectué avec succés");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void LoadCamions(List<Vehicule> liste)
        {
            List<Camion> camionListe = JsonSerializer.Deserialize<List<Camion>>(File.ReadAllText(camionPath)).ToList();
            foreach (var item in camionListe)
            {
                liste.Add(item);
            }
        }
        public static void LoadVoitures(List<Vehicule> liste)
        {
            List<Voiture> camionListe = JsonSerializer.Deserialize<List<Voiture>>(File.ReadAllText(voiturePath)).ToList();
            foreach (var item in camionListe)
            {
                liste.Add(item);
            }
        }
    }
}
