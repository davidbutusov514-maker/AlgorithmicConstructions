namespace AlgorithmicConstructions.Arrays
{
    /// <summary>
    /// Задание 1 (Базовое).
    /// Массив из 10 случайных чисел. Найти сумму, произведение,
    /// количество чётных и количество чисел больше среднего.
    /// </summary>
    public static class ArrayTask1
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("=== Задание 1 (Массивы): Статистика массива ===");

            Random rand = new Random();
            int[] numbers = new int[10];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rand.Next(1, 21); // от 1 до 20
            }

            Console.WriteLine("Массив: " + string.Join(", ", numbers));

            // Сумма
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            // Произведение
            long product = 1;
            for (int i = 0; i < numbers.Length; i++)
            {
                product *= numbers[i];
            }

            // Количество чётных
            int evenCount = 0;
            foreach (int n in numbers)
            {
                if (n % 2 == 0) evenCount++;
            }

            // Среднее арифметическое
            double average = (double)sum / numbers.Length;

            // Количество больше среднего
            int greaterThanAverage = 0;
            foreach (int n in numbers)
            {
                if (n > average) greaterThanAverage++;
            }

            Console.WriteLine($"\nСумма: {sum}");
            Console.WriteLine($"Произведение: {product}");
            Console.WriteLine($"Количество чётных: {evenCount}");
            Console.WriteLine($"Среднее арифметическое: {average:F2}");
            Console.WriteLine($"Количество чисел больше среднего: {greaterThanAverage}");
        }
    }
}