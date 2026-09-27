namespace AlgorithmicConstructions.Arrays
{
    /// <summary>
    /// Задание 4 (Работа с исключениями).
    /// Ввод массива из 5 элементов с обработкой FormatException,
    /// OverflowException и IndexOutOfRangeException.
    /// </summary>
    public static class ArrayTask4
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("=== Задание 4 (Массивы): Обработка исключений ===");

            int[] numbers = new int[5];

            // Ввод с обработкой исключений
            for (int i = 0; i < numbers.Length; i++)
            {
                bool valid = false;
                while (!valid)
                {
                    Console.Write($"Введите элемент [{i}]: ");
                    string? input = Console.ReadLine();

                    try
                    {
                        numbers[i] = int.Parse(input ?? "");
                        valid = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("  Ошибка: введено не число (FormatException).");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("  Ошибка: число слишком большое (OverflowException).");
                    }
                }
            }

            Console.WriteLine("\nВведённый массив:");
            Console.WriteLine(string.Join(", ", numbers));

            // Демонстрация IndexOutOfRangeException
            Console.WriteLine("\nПопытка обратиться к элементу по индексу 10:");
            try
            {
                int value = numbers[10];
                Console.WriteLine($"Значение: {value}");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"  Ошибка: индекс вне границ массива. {ex.Message}");
            }

            // Безопасный вывод с проверкой индекса
            Console.WriteLine("\nБезопасный вывод всех элементов:");
            for (int i = 0; i < numbers.Length; i++)
            {
                try
                {
                    Console.WriteLine($"  [{i}] = {numbers[i]}");
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"  Ошибка на индексе {i}: {ex.Message}");
                }
            }
        }
    }
}