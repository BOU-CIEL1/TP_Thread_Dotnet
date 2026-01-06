using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TP_Thread_Dotnet
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Thread principal
            Thread main = Thread.CurrentThread;
            Thread.CurrentThread.Name = "Thread Principal";

            // Affichage des informations thread principal
            Console.WriteLine($"Thread principal\n N°: {main.ManagedThreadId}\n Etat: {main.ThreadState}\n Nom: {main.Name}\n");

            // Autres Threads
            Thread A = new Thread(AfficheA);
            Thread A2 = new Thread(AfficheA);
            Thread A3 = new Thread(AfficheA);
            A.Name = "Thread A";
            A2.Name = "Thread A2";
            A3.Name = "Thread A3";
            /*A.Start();
            A2.Start();
            A3.Start();*/

            CTest TestB = new CTest();
            Thread B = new Thread(TestB.AfficheB);
            B.Name = "Thread B";
            //B.Start();

            CTest TestC = new CTest();
            Thread C = new Thread(TestC.AfficheC);
            Thread C2 = new Thread(TestC.AfficheC);
            C.Name = "Thread C";
            C2.Name = "Thread C2";
            C.Start();
            C.Join();
            Console.WriteLine("Fin du programme C, début du programme C2");
            C2.Start();
            C2.Join();
            
            // Afficher "fin du programme" lorsque tous les threads ont fini leur exécution
            Console.WriteLine("Fin du programme C2");

            //new Thread (AfficheA).Start();

        }

        static void AfficheA()
        {            
            
            // Affiche toutes les secondes "AfficheA thread:" suivi du nom du thread qui exécute la tâche
            while (true)
            {
                Console.WriteLine($"AfficheA thread: {Thread.CurrentThread.Name}");
                // Bloque le thread pendant 1000ms = 1s
                Thread.Sleep(1000);
            }
        }
    }
}
