using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryBacterie
{
    class SuperBacterie : Bacterie
    {
        #region CONSTRUCTEUR

        public SuperBacterie(int positionX, int positionY, int dureeDeVie)
            : base(positionX, positionY, dureeDeVie)
        {
            this._dureeDeVie = 30;
            this._peutSeReproduire = true;
        }

        public SuperBacterie() : base() 
        { 
            /*Quand c'est un bébé ! */
        }

        #endregion

        #region METHODES

        public override void Deplacer()
        {
            int positionXFuture = this.PositionX;
            int positionYFuture = this.PositionY;

            bool peutSeDeplacer = false;
            // Instanciation d'un objet random
            Random randomPos = new Random();

            // Choix aléatoire d'une direction
            int pos = randomPos.Next(0, 7);

            switch (pos)
            {
                case 0: // Dans le cas où l'on va en haut
                    positionXFuture = this.PositionX + 0;
                    positionYFuture = this.PositionY - 1;

                    // On regarde si personne n'occupe l'endroit sur lequel on souhaite aller
                    peutSeDeplacer = PouvoirSeDeplacer(positionXFuture, positionYFuture);
                    break;

                case 1: // Dans le cas où l'on va en bas
                    positionXFuture = this.PositionX + 0;
                    positionYFuture = this.PositionY + 1;

                    // On regarde si personne n'occupe l'endroit sur lequel on souhaite aller
                    peutSeDeplacer = PouvoirSeDeplacer(positionXFuture, positionYFuture);
                    break;
                case 2: // Dans le cas où l'on va à droite
                    positionXFuture = this.PositionX + 1;
                    positionYFuture = this.PositionY + 0;

                    // On regarde si personne n'occupe l'endroit sur lequel on souhaite aller
                    peutSeDeplacer = PouvoirSeDeplacer(positionXFuture, positionYFuture);
                    break;

                case 3: // Dans le cas où l'on va à gauche
                    positionXFuture = this.PositionX - 1;
                    positionYFuture = this.PositionY + 0;

                    // On regarde si personne n'occupe l'endroit sur lequel on souhaite aller
                    peutSeDeplacer = PouvoirSeDeplacer(positionXFuture, positionYFuture);
                    break;

                case 4: // Dans le cas où l'on va en haut à gauche
                    positionXFuture = this.PositionX - 1;
                    positionYFuture = this.PositionY - 1;

                    // On regarde si personne n'occupe l'endroit sur lequel on souhaite aller
                    peutSeDeplacer = PouvoirSeDeplacer(positionXFuture, positionYFuture);
                    break;

                case 5: // Dans le cas où l'on va en haut à droite
                    positionXFuture = this.PositionX - 1;
                    positionYFuture = this.PositionY + 1;

                    // On regarde si personne n'occupe l'endroit sur lequel on souhaite aller
                    peutSeDeplacer = PouvoirSeDeplacer(positionXFuture, positionYFuture);
                    break;

                case 6: // Dans le cas où l'on va en bas à gauche
                    positionXFuture = this.PositionX + 1;
                    positionYFuture = this.PositionY - 1;

                    // On regarde si personne n'occupe l'endroit sur lequel on souhaite aller
                    peutSeDeplacer = PouvoirSeDeplacer(positionXFuture, positionYFuture);
                    break;

                case 7: // Dans le cas où l'on va en bas à droite
                    positionXFuture = this.PositionX + 1;
                    positionYFuture = this.PositionY + 1;

                    // On regarde si personne n'occupe l'endroit sur lequel on souhaite aller
                    peutSeDeplacer = PouvoirSeDeplacer(positionXFuture, positionYFuture);
                    break;
            }

            if (peutSeDeplacer)
            {
                this.PositionX = positionXFuture;
                this.PositionY = positionYFuture;
            }
        }

        public override bool PouvoirSeDeplacer(int positionX, int positionY)
        {
            bool peutSeDeplacer = false;

            foreach (Bacterie b in Monde.LesHabitants)
            {
                if (b.PositionX.Equals(positionX) && b.PositionY.Equals(positionY))
                {
                    peutSeDeplacer = false;
                }
                else
                {
                    peutSeDeplacer = true;
                }
            }

            return peutSeDeplacer;
        }

        public override void Manger(List<Bacterie> lesBacteriesVoisines)
        {
            bool aMange = false;
            int compteur = 0;

            while (!aMange || compteur < lesBacteriesVoisines.Count)
            {
                if (this.GetType() != lesBacteriesVoisines[compteur].GetType()) // On regarde si le type des bacterie est bien différent
                {
                    // On retire la bacterie qui vient d'être mangée du monde
                    Monde.SupprimerBacterie(lesBacteriesVoisines[compteur]);

                    // Il a bien mangé maintenant il faut digérer
                    aMange = true;
                }

                compteur++;
            }
        }

        public override void Reproduire(Bacterie laBacterieDeVosReves)
        {
            SuperBacterie bebeBacterie = new SuperBacterie();

            Monde.AjouterBacterie(bebeBacterie);
        }

        #endregion
    }
}
