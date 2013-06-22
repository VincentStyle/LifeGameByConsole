using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryBacterie;

namespace TestLibraryConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            // Test Monde
            // monde de 16 cases cad 4x / 4y
            
            //On créer des bacteries A
            for (int i = 0; i < 2; i++)
            {
                BacterieA uneBacterieA = new BacterieA();
                Monde.AjouterBacterie(uneBacterieA);
                Console.WriteLine("Une bactérie A entre dans le monde ! x = " + uneBacterieA.PositionX + " y = " + uneBacterieA.PositionY);
            }

            //Création bactérie B
            //for (int i = 0; i < 1; i++)
            //{
            //    BacterieB uneBacterieB = new BacterieB();
            //    Monde.AjouterBacterie(uneBacterieB);
            //    Console.WriteLine("Une bactérie B entre dans le monde !");
            //}



            //A présent ma liste Monde est créer les bactéries peuvent alors s'affronter !
            foreach (Bacterie unHabitant in Monde.LesHabitants) 
            {
               
                //Test deplacer
                //Console.WriteLine("La bactérie" + unHabitant.GetType() + " x = " + unHabitant.PositionX + " y = " + unHabitant.PositionY);
                //unHabitant.Deplacer();
                //Console.WriteLine("La bactérie" + unHabitant.GetType() + "C'est deplacer ! alélouya de x = " + unHabitant.PositionY + " y = " + unHabitant.PositionY);

                //unHabitant.Deplacer();
                //Console.WriteLine("La bactérie" + unHabitant.GetType() + "C'est deplacer ! alélouya de x = " + unHabitant.PositionY + " y = " + unHabitant.PositionY);

                //unHabitant.Deplacer();
                //Console.WriteLine("La bactérie" + unHabitant.GetType() + "C'est deplacer ! alélouya de x = " + unHabitant.PositionY + " y = " + unHabitant.PositionY);

                //unHabitant.Deplacer();
                //Console.WriteLine("La bactérie" + unHabitant.GetType() + "C'est deplacer ! alélouya de x = " + unHabitant.PositionY + " y = " + unHabitant.PositionY);

                //unHabitant.();

                //Test Regarder autour
                //List<Bacterie> lesVoisins = unHabitant.RegarderAutour(Monde.LesHabitants);
                //Console.WriteLine(" Moi bactérie "+ok+ unHabitant.GetType());
                //for (int i = 0; i < lesVoisins.Count;i++ )
                //{
                //    Console.WriteLine("Je vois la bacterie positionnée x =" + lesVoisins[i].PositionX + " et y = " + lesVoisins[i].PositionY);
                //}
                //ok++;

                //Test Reproduire
                List<Bacterie> lesVoisins = unHabitant.RegarderAutour(Monde.LesHabitants);
                foreach(Bacterie unVoisin in lesVoisins)
                {
                    if(unHabitant.PeuxSeduire(unVoisin))
                    {
                        unHabitant.Reproduire(unVoisin);
                    }
                }

                Console.WriteLine(" Premier boucle ");
            }

            foreach (Bacterie unHabitant in Monde.LesHabitants)
            {
                Console.WriteLine(" Bonjour ");
            }

                

             //BacterieB uneBacterieB = new BacterieB();
             //Monde.AjouterBacterie(uneBacterieB);


            //Console.WriteLine(uneBacterieA.PositionX);
            //Console.WriteLine(uneBacterieA.PositionY);

            ////Console.WriteLine(uneBacterieB.PositionX);
            ////Console.WriteLine(uneBacterieB.PositionY);
            //Console.WriteLine(uneBacterieA1.PositionX);
            //Console.WriteLine(uneBacterieA1.PositionY);

            //Console.WriteLine(uneBacterieA2.PositionX);
            //Console.WriteLine(uneBacterieA2.PositionY);

            //Console.WriteLine(uneBacterieA3.PositionX);
            //Console.WriteLine(uneBacterieA3.PositionY);

            Console.WriteLine("Tous va bien");
            Console.Read();

            /*Programme*/
        }
    }
}
