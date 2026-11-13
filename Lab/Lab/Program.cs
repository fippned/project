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
                        ShowAbout();
                        Pause();
                        break;
                    case "2":
                        ShowCostTable();
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
 
        // Довідка: тема, сутність, поля з типами
        static void ShowAbout()
        {
            Console.WriteLine("Тема: Автосервіс");
            Console.WriteLine("Головна сутність: Замовлення на ремонт");
            Console.WriteLine("Довідник: Вид робіт");
            Console.WriteLine("Полів: 8");
            Console.WriteLine("  int      номер замовлення");
            Console.WriteLine("  string   марка авто");
            Console.WriteLine("  string   держномер");
            Console.WriteLine("  int      код виду робіт (з довідника)");
            Console.WriteLine("  DateTime дата прийому");
            Console.WriteLine("  double   вартість робіт");
            Console.WriteLine("  double   вартість запчастин");
            Console.WriteLine("  string   статус");
            Console.WriteLine("Підсумкова величина: сума по кожному виду робіт за місяць.");
        }
 
        // Табулювання: вартість ремонту залежно від кількості годин
        static void ShowCostTable()
        {
            double from = 0.5;     // початок проміжку, год
            double to = 5.0;       // кінець проміжку, год
            double step = 0.5;     // крок, год
            double rate = 450;     // вартість нормо-години, грн
 
            Console.WriteLine("Вартість ремонту залежно від тривалості робіт");
            Console.WriteLine($"{"Годин",8}{"Роботи, грн",16}{"З запчастинами",18}");
 
            // 1e-9 — запас на похибку дробових чисел, щоб не зникла остання стрічка
            for (double h = from; h <= to + 1e-9; h += step)
            {
                double work = h * rate;
                double total = work + work * 0.15 + 200; // запчастини: 15% від робіт + 200 грн
                Console.WriteLine($"{h,8:F2}{work,16:F2}{total,18:F2}");
            }
        }
 
    }
}