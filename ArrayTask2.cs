namespace AlgorithmicConstructions.Arrays
{
    /// <summary>
    /// Задание 2 (Среднее).
    /// Ввод размера и элементов массива, вывод в прямом и обратном
    /// порядке, сортировка по возрастанию.
    /// </summary>
    public static class ArrayTask2
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("=== Задание 2 (Массивы): Ввод и сортировка ===");

            // Ввод количества элементов
            int n;
            while (true)
            {
                Console.Write("Введите количество элементов массива: ");
                if (int.TryParse(Console.ReadLine(), out n) && n > 0)
                    break;
                Console.WriteLine("Некорректный ввод. Введите целое число > 0.");
            }

            // Ввод элементов
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                while (true)
                {
                    Console.Write($"Элемент [{i}]: ");
                    if (int.TryParse(Console.ReadLine(), out numbers[i]))
                        break;
                    Console.WriteLine("Ошибка! Введите целое число.");
                }
            }

            // Прямой порядок
            Console.WriteLine("\nМассив в прямом порядке:");
            Console.WriteLine(string.Join(", ", numbers));

            // Обратный порядок
            Console.WriteLine("\nМассив в обратном порядке:");
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                Console.Write(numbers[i]);
                if (i > 0) Console.Write(", ");
            }
            Console.WriteLine();

            // Сортировка
            Array.Sort(numbers);
            Console.WriteLine("\nМассив после сортировки по возрастанию:");
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}