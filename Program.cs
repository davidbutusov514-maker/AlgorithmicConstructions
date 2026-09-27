using AlgorithmicConstructions.Strings;
using AlgorithmicConstructions.Tasks;

namespace AlgorithmicConstructions
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Основные конструкции C# ===");
                Console.WriteLine();
                Console.WriteLine("1. Задание 1 (Базовое): числа кратные 3");
                Console.WriteLine("2. Задание 2 (Среднее): Угадай число");
                Console.WriteLine("3. Задание 3 (Сложное): To-Do List");
                Console.WriteLine("4. Задание 4 (Продвинутое): Сортировки");
                Console.WriteLine("5. Задание 1 (Строки): информация о строке");
                Console.WriteLine("6. Задание 2 (Строки): телефонные номера");
                Console.WriteLine("7. Задание 3 (Строки): анализатор текста");
                Console.WriteLine("8. Задание 4 (Строки): парсинг \"Имя:Значение\"");
                Console.WriteLine();
                Console.WriteLine("0. Выход");
                Console.Write("Выберите задание: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": Task1.Run(); break;
                    case "2": Task2.Run(); break;
                    case "3": Task3.Run(); break;
                    case "4": Task4.Run(); break;
                    case "5": StringTask1.Run(); break;
                    case "6": StringTask2.Run(); break;
                    case "7": StringTask3.Run(); break;
                    case "8": StringTask4.Run(); break;
                    case "0": return;
                    default:
                        Console.WriteLine("Неверный выбор");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }
    }
}