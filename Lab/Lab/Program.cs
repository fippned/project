using System;
using System.Text;

namespace AutoService
{
    internal class Program
    {
        // Довідник видів робіт (для таблиці з двома входами)
        static readonly string[] WorkTypes =
        {
            "Діагностика", "Заміна мастила", "Гальма",
            "Ходова", "Двигун", "Електрика"
        };

        // Середня вартість одного замовлення за видом робіт, грн
        static readonly double[] WorkPrices = { 300, 450, 800, 1200, 3500, 900 };

        static readonly string[] Days = { "Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Нд" };

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
                        ShowWorkloadTable();
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

        // Таблиця з двома входами: рядки — види робіт, стовпці — дні тижня
        static void ShowWorkloadTable()
        {
            int rows, cols;

            if (!ReadSize("Кількість рядків (видів робіт)", WorkTypes.Length, out rows))
                return;
            if (!ReadSize("Кількість стовпців (днів тижня)", Days.Length, out cols))
                return;

            Console.WriteLine();
            Console.WriteLine("Виторг за видами робіт і днями тижня, грн");

            // Шапка
            Console.Write($"{"",-16}");
            for (int c = 0; c < cols; c++)
            {
                Console.Write($"{Days[c],9}");
            }
            Console.WriteLine($"{"Разом",12}");

            double[] colTotals = new double[cols];
            double grandTotal = 0;

            for (int r = 0; r < rows; r++)
            {
                Console.Write($"{WorkTypes[r],-16}");
                double rowTotal = 0; // підсумок рядка — свій для кожного рядка

                for (int c = 0; c < cols; c++)
                {
                    int orders = ((r + 2) * (c + 3) + c) % 5 + 1; // кількість замовлень
                    double sum = orders * WorkPrices[r];

                    Console.Write($"{sum,9:F0}");
                    rowTotal += sum;
                    colTotals[c] += sum;
                }

                Console.WriteLine($"{rowTotal,12:F0}");
                grandTotal += rowTotal;
            }

            // Рядок підсумків
            Console.Write($"{"Разом",-16}");
            for (int c = 0; c < cols; c++)
            {
                Console.Write($"{colTotals[c],9:F0}");
            }
            Console.WriteLine($"{grandTotal,12:F0}");
        }

        // Читає розмір таблиці; false, якщо ввід неправильний
        static bool ReadSize(string prompt, int max, out int value)
        {
            Console.Write($"{prompt} (1–{max}): ");
            string text = Console.ReadLine();

            if (!int.TryParse(text, out value))
            {
                Console.WriteLine("Помилка: потрібно ввести ціле число.");
                return false;
            }
            if (value <= 0)
            {
                Console.WriteLine("Помилка: число має бути більшим за нуль.");
                return false;
            }
            if (value > max)
            {
                Console.WriteLine($"Помилка: максимум — {max}.");
                return false;
            }
            return true;
        }
    }
}