using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TP_Thread_Dotnet
{
    public class CTest
    {
        private int div;
        private object _locker = new object();
        EventWaitHandle _waitHandle = new AutoResetEvent(false);
        private int result;
        public int Calcul(int val)
        {
            div = val;
            if (div != 0)
            {
                Thread.Sleep(1);
                return (100 / div);
            };
            return 0;
        }
        
        public void AfficheB()
        {
            // Affiche toutes les secondes "AfficheA thread:" suivi du nom du thread qui exécute la tâche
            while (true)
            {
                div = 10;
                lock (_locker)
                {
                    Console.WriteLine($"AfficheB thread: {Thread.CurrentThread.Name}; Résultat Calcul: {Calcul(div)}");
                }
                // Bloque le thread pendant 1000ms = 1s
                Thread.Sleep(1000);
            }

        }

        public void AfficheC()
        {
            for (int i = 0; i < 100; i++)
            {
                div = 10;
                lock (_locker)
                {
                    Console.WriteLine($"AfficheC thread: {Thread.CurrentThread.Name}; Numéro: {Thread.CurrentThread.ManagedThreadId}; Valeur itération: {i}; Résultat Calcul: {Calcul(div)}");
                }

                //Console.WriteLine($"AfficheC thread: {Thread.CurrentThread.Name}; Numéro: {Thread.CurrentThread.ManagedThreadId}; Valeur itération: {i}");
                //Thread.Sleep(1000);
            }
        }

        public void CalculF()
        {
            // Fait un calcul et signale la disponibilité du résultat
            Console.WriteLine($"{Thread.CurrentThread.Name} : Début du calcul...");
            Thread.Sleep(1000);
            result = 1 + 2;
            Console.WriteLine($"{Thread.CurrentThread.Name} : Calcul terminé! Envoi du signal.");
            _waitHandle.Set();
        }

        public void AfficheD()
        {
            // Attends le signal du thread précédent pour afficher le résultat
            Console.WriteLine($"{Thread.CurrentThread.Name} : En attente du résultat...");
            _waitHandle.WaitOne();
            Console.WriteLine($"{Thread.CurrentThread.Name} : Résultat reçu = {result} ");
        }
    }
}
