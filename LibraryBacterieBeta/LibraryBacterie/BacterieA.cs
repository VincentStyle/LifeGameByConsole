using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryBacterie
{
    public class BacterieA : Bacterie
    {
        #region METHODES

        public override void Deplacer()
        {
            // Pour réxupérer les futures coordonnées
            int positionXFuture = this.PositionX;
            int positionYFuture = this.PositionY;

            // Permet de savoir si la bacterie peut se déplacer à l'endroit désigné
            bool peutSeDeplacer = false;

            // Instanciation d'un objet random
            Random randomdirection = new Random();

            // Choix aléatoire d'une direction
            int direction = randomdirection.Next(0, 1);


            switch (direction)
            {
                case 0: // Dans le cas où l'on va à droite
                    positionXFuture = this.PositionX + 2;
                    positionYFuture = this.PositionY + 1;

                    // On regarde si personne n'occupe l'endroit sur lequel on souhaite aller
                    peutSeDeplacer = PouvoirSeDeplacer( positionXFuture, positionYFuture);
                    break;

                case 1: // Dans le cas où l'on va à gauche
                    positionXFuture = this.PositionX + 2;
                    positionYFuture = this.PositionY - 1;

                    // On regarde si personne n'occupe l'endroit sur lequel on souhaite aller
                    peutSeDeplacer = PouvoirSeDeplacer(positionXFuture, positionYFuture);
                    break;
            }

            if (peutSeDeplacer) // Si la palce est libre, alors on l'occupe
            {
                this.PositionX = positionXFuture;
                this.PositionY = positionYFuture;
            }
        }

        public override void Manger(List<Bacterie> lesBacteriesVoisines)
        {
            bool aMange = false;
            int compteur = 0;

            while (compteur < lesBacteriesVoisines.Count)
            {
                if (this.GetType() != lesBacteriesVoisines[compteur].GetType()) // On regarde si le type des bacterie est bien différent
                {

                    if (this.Majorite && !lesBacteriesVoisines[compteur].Majorite) // On regarde si la bacterie qui veut manger est bien adulte et que la bacterie à manger est enfant
                    {
                        // Gagne 1 point experience pour devenir super bacterie
                        this.PointExp += 1;

                        // On retire la bacterie qui vient d'être mangée du monde
                        Monde.SupprimerBacterie(lesBacteriesVoisines[compteur]);

                        // Il a bien mangé maintenant il faut digérer
                        compteur = lesBacteriesVoisines.Count;
                    }
                }

                compteur++;
            }

            if(!aMange) // On retire les point d'xp
            {   
                this.PointExp = 0;
            }
        }
        
        public override bool PouvoirSeDeplacer(int positionX, int positionY)
        {
            // Permet de savoir si la bacterie peut se déplacer à l'endroit désigné
            bool peutSeDeplacer = false;

            /* Si la valeur de X où de Y fait sortir la bacterie du monde,
             * alors on l'a fait apparaître à l'autre extrêmité du monde*/
            if (positionX > Monde.LaTailleDuMonde) 
            {
                positionX = positionX - Monde.LaTailleDuMonde;
            }

            if (positionY > Monde.LaTailleDuMonde)
            {
                positionY = positionY - Monde.LaTailleDuMonde;
            }
            else if (positionY < 0)
            {
                positionY = Monde.LaTailleDuMonde + positionY;
            }

            // On vérifie qu'aucune bacterie occupe l'endroit sur lequel on veut aller
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

        public override void Reproduire(Bacterie laBacterieDeVosReves)
        {
            this.DureeDeVie--;
            laBacterieDeVosReves.DureeDeVie--;

            this.PeutSeReproduire = false;
            laBacterieDeVosReves.PeutSeReproduire = false;

            this.EstImmobile = true;
            laBacterieDeVosReves.EstImmobile = true;

            BacterieA bebeBacterie = new BacterieA();

            Monde.AjouterBacterie(bebeBacterie);
        }

        #endregion
    }
}
