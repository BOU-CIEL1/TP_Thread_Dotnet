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

            // Threads
            Thread main = Thread.CurrentThread;
            Thread.CurrentThread.Name = "Thread Principal";
            Thread A = new Thread(AfficheA);
            Thread B = new Thread(AfficheA);
            Thread C = new Thread(AfficheA);
            A.Name = "Thread A";
            B.Name = "Thread B";
            C.Name = "Thread C";
            A.Start();
            B.Start();
            C.Start();

            // Affichage des informations thread principal
            Console.WriteLine($"Thread principal\n N°: {main.ManagedThreadId}\n Etat: {main.ThreadState}\n Nom: {main.Name}\n");

            // Lancement des threads
            // new Thread(AfficheA).Start();

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
