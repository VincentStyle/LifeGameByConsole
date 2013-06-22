using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryBacterie
{
    public abstract class Bacterie
    {
        #region CHAMPS

        // Donne la position en X de l'individu
        protected int _positionX;

        // Donne la position en Y de l'individu
        protected int _positionY;

        // Age d'une bacterie
        //protected int _age;

        protected string _sexe;

        // Durée de vie (20 itérations)
        protected int _dureeDeVie;

        // Vrai s'il peut se reporduire faux sinon
        protected bool _peutSeReproduire;

        // Compteur de 3 itérations avant de pouvoir se reproduire
        protected int _dureeAvantReproduction;

        // Bool oui Adulte 10-20 non enfant 1-10
        protected bool _majorite;

        // Nombre de case que la bactérie peut parcourir
        protected int _distance;

        // Est ce que la bactérie est immobile True ou False Gros!
        protected bool _estImmobile;

        // permet de savoir si la bacterie a été mangé
        private bool _estMort;

        // Points experiences accumulés pour devenir superBacterie
        protected int _pointExp;

#endregion

        #region ACCESSEURS

        public int PositionX
        {
            get { return _positionX; }
            set { _positionX = value; }
        }

        public int PositionY
        {
            get { return _positionY; }
            set { _positionY = value; }
        }

        public int DureeDeVie
        {
            get { return _dureeDeVie; }
            set { _dureeDeVie = value; }
        }

        public string Sexe
        {
            get { return _sexe; }
            set { _sexe = value; }
        }

        public bool PeutSeReproduire
        {
            get { return _peutSeReproduire; }
            set { _peutSeReproduire = value; }
        }

        public int DureeAvantReproduction
        {
            get { return _dureeAvantReproduction; }
            set { _dureeAvantReproduction = value; }
        }

        public bool Majorite
        {
            get { return _majorite; }
            set { _majorite = value; }
        }

        public int Distance
        {
            get { return _distance; }
            set { _distance = value; }
        }

        public bool EstImmobile
        {
            get { return _estImmobile; }
            set { _estImmobile = value; }
        }

        public bool EstMort
        {
            get { return _estMort; }
            set { _estMort = value; }
        }

        public int PointExp
        {
            get { return _pointExp; }
            set { _pointExp = value; }
        }

        #endregion

        #region ENUMERATIONS

        // Enumeration pour définir le sexe de la bacterie
        //public enum Sexe
        //{
        //    Male,
        //    Femelle
        //}

        #endregion

        #region CONSTRUCTEURS

        public Bacterie()
        {   
            Random randomX = new Random();
            Random randomY = new Random();

            this._positionX = randomX.Next(0, 100);
            this._positionY = randomY.Next(0, 100);
            this._dureeDeVie = 20;
            this._peutSeReproduire = true;
            this._dureeAvantReproduction = 0;
            this._majorite = false;
            this._distance = 3;
            this._estImmobile = false;
        }

        //public Bacterie(int dureeDeVie, bool estImmobile)
        //{
        //    this._dureeDeVie = 20;
        //    this._peutSeReproduire = true;
        //    this._estImmobile = estImmobile;
        //}

        #endregion

        #region METHODES

        public List<Bacterie> RegarderAutour(List<Bacterie> lstHabitants)
        {
            /*On récupère dans une liste toutes les bacteries voisines de la bacterie courante*/
            List<Bacterie> liste = new List<Bacterie>();

            // Retourne une liste null s'il n'y a personne autour
            return liste;
        }

        public abstract Bacterie Manger(List<Bacterie> lesBacteriesVoisines);

        public abstract Bacterie Reproduire(List<Bacterie> lesBacteriesVoisines);

        public abstract void Deplacer();

        public abstract bool PouvoirSeDeplacer(int positionX, int positionY);

        #endregion
    }
}
