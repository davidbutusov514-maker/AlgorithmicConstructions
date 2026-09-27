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
                Console.WriteLine("=== Основные алгоритмические конструкции в C# ===");
                Console.WriteLine("1. Задание 1 (Базовое): числа кратные 3");
                Console.WriteLine("2. Задание 2 (Среднее): Угадай число");
                Console.WriteLine("3. Задание 3 (Сложное): To-Do List");
                Console.WriteLine("4. Задание 4 (Продвинутое): Сортировки");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите задание: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": Task1.Run(); break;
                    case "2": Task2.Run(); break;
                    case "3": Task3.Run(); break;
                    case "4": Task4.Run(); break;
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