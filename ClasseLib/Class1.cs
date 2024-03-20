namespace ClasseLib
{
    public class Vehicule
    {
        private string _marque;
        private string _modele;
        private string _numero;

        public string Marque {  get { return _marque; } set {  _marque = value; } }
        public string Modele { get { return _modele; } set { _modele = value; } }
        public string Numero 
        { 
            get { return _numero; } 
            set 
            {
                if ( value.Length < 4 || value.Length > 6 )
                {
                    throw new Exception("Numero Lenght Must be Between 4 and 6");
                }
                else
                {
                    _numero = value; 
                }
            } 
        }
        // Constructeur Vehicule
        public Vehicule() { }
        public Vehicule(string marque,string modele = "NR", string numero = "000000" ) 
        {
            Marque = marque;
            Modele = modele;
            Numero = numero;
        }

        public override string ToString()
        {
            return $"Marque : {Marque}  Modele : {Modele} Numero: {Numero} ";
        }
    }
    public class Camion : Vehicule
    {
        private double _poids;
        public double Poids
        {
            get { return _poids; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Poids doit être supérieur à 0");
                }
                else
                {
                    _poids = value;
                }
            }
        }
        // Constructeur du Camion
        public Camion() { }
        public Camion(string marque, double poids, string modele = "NR", string numero = "000000") : base( marque, modele,numero )
        {
            Poids = poids;
        }

        public override string ToString()
        {
            return " CAMION | " + base.ToString()+ $" Poids : {Poids}";
        }
    }
    public class Voiture : Vehicule
    {
        private double _puissance;
        public double Puissance
        {
            get { return _puissance; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Poids doit être supérieur à 0");
                }
                else
                {
                    _puissance = value;
                }
            }
        }
        // Constructeur Voiture 
        public Voiture(string marque, double puissance, string modele = "Non renseignée", string numero = "00000") : base(marque, modele, numero)
        {
            Puissance = puissance;
        }
        public override string ToString()
        {
            return "VOITURE | " + base.ToString() + $" Puissance : {Puissance}";
        }
    }

}
