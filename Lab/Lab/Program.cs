using System;
using System.Text;
 
namespace AutoService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            bool running = true;
 
            while (running)
            {
                Console.WriteLine("=== Автосервіс ===");
                Console.WriteLine("1 — довідка про програму");
                Console.WriteLine("2 — таблиця вартості ремонту за годинами");
                Console.WriteLine("3 — звіт: виторг за видами робіт і днями тижня");
                Console.WriteLine("0 — вихід");
                Console.Write("Ваш вибір: ");
 
                string choice = Console.ReadLine();
                Console.WriteLine();
 
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Цей пункт буде реалізовано в наступній частині.");
                        Pause();
                        break;
                    case "2":
                        Console.WriteLine("Цей пункт буде реалізовано в наступній частині.");
                        Pause();
                        break;
                    case "3":
                        Console.WriteLine("Цей пункт буде реалізовано в наступній частині.");
                        Pause();
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("До побачення.");
                        break;
                    default:
                        Console.WriteLine("Немає такого пункту. Спробуйте ще раз.");
                        Pause();
                        break;
                }
            }
        }
 
        // Пауза й очищення екрана після дії
        static void Pause()
        {
            Console.WriteLine("\nНатисніть будь-яку клавішу...");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}