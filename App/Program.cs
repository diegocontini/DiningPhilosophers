using DiningPhilosophers.Models;
using System.Threading.Tasks;

namespace DiningPhilosophers
{
    internal class Program
    {
        
        static async Task Main(string[] args)
        {
            int qtdFilosofos = 5;
            String[] arrNomes = { "Socrates", "Platão", "Aristóteles", "Epicuro", "Descartes" };
            Filosofo[] arrFilosofos = new Filosofo[qtdFilosofos];
            Talher[] arrTalheres = new Talher[qtdFilosofos];

            for (int i = 0; i < qtdFilosofos; i++)
            {
                arrTalheres[i] = new Talher(i);
            }

            for(int i = 0; i< qtdFilosofos; i++)
            {
                arrFilosofos[i] = new Filosofo(i, arrNomes[i], arrTalheres[i], arrTalheres[(i + 1)% qtdFilosofos]);
            }

            Thread[] threads = new Thread[qtdFilosofos];

            for(int i = 0; i < qtdFilosofos; i++)
            {
             
                threads[i] = new Thread(arrFilosofos[i].Jantar);
                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

        }
    }
}
