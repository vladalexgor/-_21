using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Задание_21
{
    //Имеется пустой участок земли (двумерный массив) и план сада, который необходимо реализовать. Эту задачу выполняют два садовника,
    //которые не хотят встречаться друг с другом. Первый садовник начинает работу с верхнего левого угла сада и перемещается слева направо, сделав ряд, он спускается вниз.
    //Второй садовник начинает работу с нижнего правого угла сада и перемещается снизу вверх, сделав ряд, он перемещается влево.
    //Если садовник видит, что участок сада уже выполнен другим садовником, он идет дальше. Садовники должны работать параллельно. Создать многопоточное приложение, моделирующее работу садовников.
    class Program
    {
        public class Garden
        {
            int n;
            public int N
            {
                get
                {
                    return n;
                }
                set
                {
                    if (value < 1)
                    {
                        n = 1;
                    }
                    else
                    {
                        n = value;
                    }
                }
            }
            int m;
            public int M
            {
                get
                {
                    return m;
                }
                set
                {
                    if (value < 1)
                    {
                        m = 1;
                    }
                    else
                    {
                        m = value;
                    }
                }
            }
            int[,] gardenField; 

            public Garden(int n1, int m1)
            {
                N = n1;
                M = m1;
                gardenField = new int[n, m];
            }
            public void Gardener1()
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (gardenField[i, j] == 0)
                        {
                            gardenField[i, j] = 1;
                        }
                    }
                    Thread.Sleep(50);
                }
            }
            public void Gardener2()
            {
                for (int j = (m-1); j > -1; j--)
                {
                    for (int i = (n-1); i > -1; i--)
                    {
                        if (gardenField[i, j] == 0)
                        {
                            gardenField[i, j] = 2;
                        }
                    }
                    Thread.Sleep(30);
                }
            }
            public void Print()
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write("{0,2}", gardenField[i, j]);
                    }
                    Console.WriteLine();
                }
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите размеры участка земли двумя целыми числами N х M:");
                int n = Convert.ToInt32(Console.ReadLine());
                int m = Convert.ToInt32(Console.ReadLine());
                Garden garden = new Garden(n, m);
                ThreadStart threadStart = new ThreadStart(garden.Gardener2);
                Thread thread = new Thread(threadStart);
                thread.Start();
                garden.Gardener1();
                garden.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Для завершения программы нажмите любую клавишу.");
            Console.ReadKey();
        }
    }
}
