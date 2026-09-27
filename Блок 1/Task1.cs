namespace AlgorithmicConstructions.Tasks
{
    /// <summary>
    /// Задание 1 (Базовое).
    /// Запрашивает число N, выводит все числа от 1 до N, кратные 3,
    /// и находит их сумму. Использует while, do-while и for.
    /// </summary>
    public static class Task1
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("=== Задание 1: Числа, кратные 3 ===");
            Console.Write("Введите число N: ");

            if (!int.TryParse(Console.ReadLine(), out int n) || n < 1)
            {
                Console.WriteLine("Некорректное N. Должно быть целое число >= 1.");
                return;
            }

            Console.WriteLine("\n--- Цикл while ---");
            int i = 1;
            int sumWhile = 0;
            while (i <= n)
            {
                if (i % 3 == 0)
                {
                    Console.Write(i + " ");
                    sumWhile += i;
                }
                i++;
            }
            Console.WriteLine($"\nСумма: {sumWhile}");

            Console.WriteLine("\n--- Цикл do-while ---");
            i = 1;
            int sumDoWhile = 0;
            do
            {
                if (i % 3 == 0)
                {
                    Console.Write(i + " ");
                    sumDoWhile += i;
                }
                i++;
            } while (i <= n);
            Console.WriteLine($"\nСумма: {sumDoWhile}");

            Console.WriteLine("\n--- Цикл for ---");
            int sumFor = 0;
            for (int j = 1; j <= n; j++)
            {
                if (j % 3 == 0)
                {
                    Console.Write(j + " ");
                    sumFor += j;
                }
            }
            Console.WriteLine($"\nСумма: {sumFor}");
        }
    }
}