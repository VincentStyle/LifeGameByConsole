using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryBacterie
{
    public static class Monde
    {
        //#region A REVOIR
        //private static readonly Monde _leMonde = new Monde();

        //private List<Bacterie> _lesBacteries = new List<Bacterie>();

        //private int nbColonne;

        //private int nbLigne;

        //private int tailleCase;

        //public static Monde LeMonde
        //{
        //    get { return Monde._leMonde; }
        //} 

        //private Monde() { }

        //public int CountBacterie(List<Bacterie> lstBacteries)
        //{

        //    return 0;
        //}
        //#endregion

        #region CHAMPS

        //Propriétés
        private static List<Bacterie> _lesHabitants = new List<Bacterie>();

        public static List<Bacterie> LesHabitants
        {
            get { return Monde._lesHabitants; }
            set { Monde._lesHabitants = value; }
        }
        private static int _laTailleDuMonde;

        public static int LaTailleDuMonde
        {
            get { return Monde._laTailleDuMonde; }
            set { Monde._laTailleDuMonde = value; }
        }
        private static bool _supprematie = false;

        public static bool Supprematie
        {
            get { return Monde._supprematie; }
            set { Monde._supprematie = value; }
        }

        //Constructeur
        //public Monde(int laTailleDuMonde, int nbBacterieA, int nbBacterieB)
        //{
        //    //On renseigne la taille du monde

        //    //On remplie la liste avec les bactéries 
        //    for (int i = 1; i <= nbBacterieA; i++)
        //    {
        //        BacterieA uneBacterieA = new BacterieA();
        //        //this._lesHabitants.Add(uneBacterieA);
        //    }
        //    for (int i = 1; i <= nbBacterieB; i++)
        //    {
        //        BacterieB uneBacterieB = new BacterieB();
        //        //this._lesHabitants.Add(uneBacterieB);
        //    }

        //    //Fonction pour mélanger la liste

        //}

        //Méthodes

        #endregion

        #region METHODES

        //public static string IlNenResteraQuun()
        //{
        //    //Tantqu'il n'y a pas qu'une seule espèce de bactérie
        //    while (this._supprematie == false)
        //    {
        //        //On parcours la liste
        //        foreach (Bacterie laBacterie in _lesHabitants)
        //        {
        //            //Controle des papiers s'il vous plait
        //            laBacterie.ControleIdentite();
        //            //Si la bactérie se déplace
        //            if (laBacterie.Deplacer())
        //            {
        //                //On liste les bactérie proches
        //                List<Bacterie> lesBacteriesProches = laBacterie.RegarderAutour();
        //                //Si la liste est pleinne
        //                if (lesBacteriesProches.empty() == false)
        //                {
        //                    foreach (Bacterie laBacterieProche in lesBacteriesProches)
        //                    {
        //                        if (laBacterie.Seduction(laBacterieProche))//Si la bactérie est séduite alors
        //                        {
        //                            laBacterie.Reproduire(laBacterieProche);//Baby blue
        //                            //Sortir de la boucle
        //                            break;
        //                        }
        //                    }

        //                    //On test à présent si nous nous sommes reproduit si non Manger !
        //                    if (laBacterie._peutSeReproduire == false)
        //                    {
        //                        //Parmis la liste de bacterie proche random est en prendre une !
        //                        Bacterie laBacterieQuiNaPasDeChance = LesBacteriesProches;
        //                        laBacterie.Manger(laBacterieQuiNaPasDeChance);
        //                        //On doit supprimer la bacterie de la liste aussi si elle a ete mangé.
        //                    }
        //                }
        //            }
        //            //le tour pour la bactérie est fini elle perd une vie
        //            laBacterie._dureeDeVie--;
        //            //A la fin du tour on vérifie qu'il y a toujours 2 types de bactéries dans la liste
        //            this.Recensement();

        //        }
        //        //Annonce du gagnant
        //        return "Le monde est à présent gouverner par ";
        //    }
        //}//Fin méthode laVie..

        //On vérifie la présence des bactéries
        //public static void Recensement()
        //{
        //    Bacterie laBacterieTest = _lesHabitants[1];
        //    foreach (Bacterie laBacterie in _lesHabitants)
        //    {
        //        //Si il la liste ne contient qu'un seul type de bactérie alors
        //        if (laBacterieTest.GetType() != laBacterie.GetType())
        //        {
        //            break;
        //        }
        //        //Sinon
        //        //Je ne suis pas tres sur de cette ligne la
        //        Monde._supprematie = true;

        //    }
        //}

        public static void AjouterBacterie(Bacterie nvBacterie)
        {
            Monde.LesHabitants.Add(nvBacterie);
        }

        public static void SupprimerBacterie(Bacterie bacterieSupr)
        {
            Monde.LesHabitants.Remove(bacterieSupr);
        }

        public static void EnregistrerEvenements()
        {

        }

        public static int CountBacterieA(List<Bacterie> lesHabitants)
        {
            return 0;
        }

        public static int CountBacterieB(List<Bacterie> lesHabitants)
        {
            return 0;
        }

        #endregion
    }
}
