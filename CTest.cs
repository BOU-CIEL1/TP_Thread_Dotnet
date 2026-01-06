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
                Console.WriteLine($"AfficheB thread: {Thread.CurrentThread.Name}");
                // Bloque le thread pendant 1000ms = 1s
                Thread.Sleep(1000);
            }

        }

        public void AfficheC()
        {
            for (int i = 0; i < 100; i++)
            {
                div = 0;
                Console.WriteLine($"AfficheC thread: {Thread.CurrentThread.Name}; Numéro: {Thread.CurrentThread.ManagedThreadId}; Valeur itération: {i}; Résultat Calcul: {Calcul(div)}");
        
                //Console.WriteLine($"AfficheC thread: {Thread.CurrentThread.Name}; Numéro: {Thread.CurrentThread.ManagedThreadId}; Valeur itération: {i}");
                //Thread.Sleep(1000);
            }
        }
    }
}
