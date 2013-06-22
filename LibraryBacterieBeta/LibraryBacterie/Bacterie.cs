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

        protected int _sexe;

        // Durée de vie (20 itérations)
        protected int _dureeDeVie;

        // Vrai s'il peut se reporduire faux sinon
        protected bool _peutSeReproduire;

        // Compteur de 3 itérations avant de pouvoir se reproduire
        protected int _dureeAvantReproduction;

        // Bool oui Adulte 10-20 non enfant 1-10
        protected bool _majorite;

        // Nombre de case que la bactérie peut parcourir
        //protected int _distance;

        // Est ce que la bactérie est immobile True ou False Gros!
        protected bool _estImmobile;

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

        public int Sexe
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

        //public int Distance
        //{
        //    get { return _distance; }
        //    set { _distance = value; }
        //}

        public bool EstImmobile
        {
            get { return _estImmobile; }
            set { _estImmobile = value; }
        }

        public int PointExp
        {
            get { return _pointExp; }
            set { _pointExp = value; }
        }

        #endregion

        #region CONSTRUCTEURS

        public Bacterie()
        {
            bool isOk = false;

            if (!Monde.LesHabitants.Count.Equals(0))
            {
                while (!isOk)
                {
                    Random randomX = new Random();
                    Random randomY = new Random();
                    this._positionX = randomX.Next(0, 2);
                    this._positionY = randomY.Next(0, 2);

                    isOk = this.PlaceLibre(this._positionX, this._positionY);
                }

            }
            else 
            {
                Random randomX = new Random();
                Random randomY = new Random();
                this._positionX = randomX.Next(0, 2);
                this._positionY = randomY.Next(0, 2);
            }
            
            this._dureeDeVie = 20;
            this._peutSeReproduire = true;
            this._dureeAvantReproduction = 0;
            this._majorite = false;
            //this._distance = 3;
            this._estImmobile = false;

            Random randomSexe = new Random();
            this._sexe = randomSexe.Next(0, 1);
        }

        public Bacterie(int positionX, int positionY, int dureeDeVie)
        {
            this._dureeDeVie = 30;
            this._positionX = positionX;
            this._positionY = positionY;
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
            //Création liste qui sera retournée
            List<Bacterie> lstBacteriesProches = new List<Bacterie>();

            //Parcours de la liste lstHabitants
            foreach (Bacterie unHabitant in lstHabitants)
            {
                if ( this.PositionX != unHabitant.PositionX && this.PositionY != unHabitant.PositionY)
                {
                    //On test si la position X se trouvent au dessus/au milieu/dessous de l'objet instancié 
                    if (this.PositionX == unHabitant.PositionX || this.PositionX - 1 == unHabitant.PositionX || this.PositionX + 1 == unHabitant.PositionX)
                    {
                        //On test si la position Y se trouvent au dessus/au milieu/dessous de l'objet instancié 
                        if (this.PositionY == unHabitant.PositionY || this.PositionY - 1 == unHabitant.PositionY || this.PositionY + 1 == unHabitant.PositionY)
                        {
                            //On ajoute à la liste
                            lstBacteriesProches.Add(unHabitant);
                        }
                    }
                }
               
            }

            return lstBacteriesProches;
        }

        public abstract void Reproduire(Bacterie laBacterieDeVosReves);

        public void ControleIdentite()
        {
            //Si l'age de la bacterie est en dessous de 10 alors 
            if (this.DureeDeVie <= 10)
            {
                this.Majorite = true;
            }
            //Si la bacterie s'est reproduite dernierement alors c'est faux
            if (this.PeutSeReproduire == false)
            {
                //Apres la reproduction on utilise un compteur pour debloquer la bacterie
                if (this.DureeAvantReproduction == 1)
                {
                    this.EstImmobile = false;
                }

                //Si le compteur est à 0 
                if (this.DureeAvantReproduction == 0)
                {
                    this.PeutSeReproduire = true;
                    this.DureeAvantReproduction = 3;
                }
                else //Sinon on baisse le compteur
                {
                    //de base a 3
                    this.DureeAvantReproduction--;
                }
            }
        }// A vérifier ! 

        public abstract void Deplacer();

        public abstract bool PouvoirSeDeplacer(int positionX, int positionY);

        public abstract void Manger(List<Bacterie> lesBacteriesVoisines);

        public bool PeuxSeduire(Bacterie laBacterieCelibataire)
        {
            if (this.Majorite == true && laBacterieCelibataire.Majorite == true && this.Sexe != laBacterieCelibataire.Sexe && this.GetType() == laBacterieCelibataire.GetType() && this.PeutSeReproduire == true && laBacterieCelibataire.PeutSeReproduire == true)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public bool PlaceLibre(int positionX, int positionY)
        {
            // Permet de savoir si la bacterie peut se déplacer à l'endroit désigné
            bool estLibre = false;

            // On vérifie qu'aucune bacterie occupe l'endroit sur lequel on veut aller
            foreach (Bacterie b in Monde.LesHabitants)
            {
                if (b.PositionX.Equals(positionX) && b.PositionY.Equals(positionY))
                {
                    estLibre = false;
                    break;
                }
                else
                {
                    estLibre = true;
                }
            }

            return estLibre;
        }
        #endregion
    }
}
