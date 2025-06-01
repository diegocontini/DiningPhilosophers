using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningPhilosophers.Models
{
    internal class Filosofo(int id, string nome, Talher talherEsquerdo, Talher talherDireito)
    {
        private readonly int id = id;
        private readonly string nome = nome;
        private readonly Talher talherEsquerdo = talherEsquerdo;
        private readonly Talher talherDireito = talherDireito;


        public void Jantar()
        {
            while (true)
            {
                Pensar();
                Comer();
            }

        }

        private void Pensar()
        {

            Console.WriteLine($"Filosofo {nome} esta pensando...");
            Thread.Sleep(1000);
        }

        private void Comer() { 
        Console.WriteLine($"Filosofo {nome} esta comendo...");
            if (id % 2 == 0) {
                lock (talherDireito)
                {
                    lock (talherEsquerdo)
                    {
                        Console.WriteLine($"Filosofo {nome} pegou os talheres e esta comendo...");
                        Thread.Sleep(1000);
                        Console.WriteLine($"Filosofo {nome} terminou de comer e largou o talher esquerdo...");
                    }
                    Console.WriteLine($"Filosofo {nome} terminou de comer e largou o talher direito...");
                }
            } else
            {
                lock (talherEsquerdo)
                {
                    lock (talherDireito)
                    {
                        Console.WriteLine($"Filosofo {nome} pegou os talheres e esta comendo...");
                        Thread.Sleep(1000);
                        Console.WriteLine($"Filosofo {nome} terminou de comer e largou o talher direito...");
                    }
                    Console.WriteLine($"Filosofo {nome} terminou de comer e largou o talher esquerdo...");
                }
            }
           

        }

    }

}
